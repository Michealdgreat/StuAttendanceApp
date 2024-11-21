using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StudentAttendanceApp.Services
{
    public class GetService(ITokenService tokenService)
    {

        private static readonly JsonSerializerOptions JsonSerializerOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };
        private readonly ITokenService _tokenService = tokenService;

        public async Task<TResponse?> GetByOne<TResponse, TParameter>(TParameter parameter, string endPoint)
        {
            try
            {
                var jwtToken = await _tokenService.GetTokenAsync();

                using var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

                var response = await client.GetAsync($"{endPoint}{parameter}");

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

        public async Task<ObservableCollection<T>?> GetListOfFiles<T, U>(U parameter, string endPoint)
        {
            try
            {
                var jwtToken = await _tokenService.GetTokenAsync();

                using var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

                var response = await client.GetAsync($"{endPoint}{parameter}");

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();

                    var result = JsonSerializer.Deserialize<ObservableCollection<T>>(responseData, JsonSerializerOptions);

                    if (result != null)
                    {

                        return result = new ObservableCollection<T>(
                            result.OrderByDescending(orderByThisProperty => orderByThisProperty!.GetType().GetProperty("UploadDate")?.GetValue(orderByThisProperty, null))
                        );
                    }

                    return default;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public async Task<ObservableCollection<T>?> GetList<T, U>(U parameter, string endPoint)
        {
            try
            {
                var jwtToken = await _tokenService.GetTokenAsync();

                using var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

                var response = await client.GetAsync($"{endPoint}{parameter}");

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();

                    return JsonSerializer.Deserialize<ObservableCollection<T>>(responseData, JsonSerializerOptions);


                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
