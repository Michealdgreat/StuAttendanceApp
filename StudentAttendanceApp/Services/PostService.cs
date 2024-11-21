using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StudentAttendanceApp.Services
{
    public class PostService(HttpClient httpClient, ITokenService tokenService)
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly ITokenService _tokenService = tokenService;

        private static readonly JsonSerializerOptions JsonSerializerOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public async Task<TResponse?> PostAsync<TRequest, TResponse>(TRequest data, string endpoint)
        {
            try
            {
                var jwtToken = await _tokenService.GetTokenAsync();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

                var json = JsonSerializer.Serialize(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(endpoint, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<TResponse>(responseData, JsonSerializerOptions);
                    return result;
                }
                else
                {
                    return default;
                }
            }
            catch (Exception)
            {
                return default;
            }
        }

        public async Task<TResponse?> PostAsyncFromForm<TResponse>(HttpContent content, string endpoint)
        {

            try
            {
                var jwtToken = await _tokenService.GetTokenAsync();
                _httpClient.Timeout = TimeSpan.FromMinutes(5);
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

                using var cts = new CancellationTokenSource(300000);

                var response = await _httpClient.PostAsync(endpoint, content, cts.Token);

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<TResponse>(responseData, JsonSerializerOptions);
                    return result;
                }
            }
            catch (HttpRequestException)
            {
                return default;
            }
            catch (Exception)
            {
                return default;
            }

            return default;
        }


    }
}
