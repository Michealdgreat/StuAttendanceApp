using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.SignalR.Client;
using StudentAttendanceApp.MVVM.Models;
using StudentAttendanceApp.MVVM.ViewModels.Base;
using StudentAttendanceApp.MVVM.Views;
using StudentAttendanceApp.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace StudentAttendanceApp.MVVM.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        private readonly ITokenService _tokenService;
        private readonly CommonService _commonService;
        private readonly GetService _getService;
        private HubConnection? _hubConnection;

        [ObservableProperty]
        private string? tagId;

        [ObservableProperty]
        private bool isPasswordVisible = true;

        [ObservableProperty]
        private bool loadingIndicator = false;

        [ObservableProperty]
        private bool loginButtonVisibility = true;

        // Manage a single CancellationTokenSource
        private CancellationTokenSource? _cancellationTokenSource;

        public LoginViewModel(ITokenService tokenService, CommonService commonService, GetService getService)
        {
            _tokenService = tokenService;
            _commonService = commonService;
            _getService = getService;
            InitializeSignalR();
        }

        [RelayCommand]
        public void ViewTagid()
        {
            IsPasswordVisible = !IsPasswordVisible;
        }

        private async void InitializeSignalR()
        {
            try
            {
                _hubConnection = new HubConnectionBuilder()
                    .WithUrl(EndPoints.loginHubEndPoint)
                    .Build();

                _hubConnection.On<string>("ReceiveTagId", (tagId) =>
                {
                    TagId = tagId;
                });

                await _hubConnection.StartAsync();
            }
            catch (HttpRequestException)
            {
                // Handle specific exceptions if needed
            }
            catch (Exception)
            {
                // Handle other exceptions
            }
        }

        [RelayCommand]
        public async Task LoginButtonAsync()
        {
            // Prevent multiple concurrent login attempts
            if (LoadingIndicator)
                return;

            LoadingIndicator = true;
            LoginButtonVisibility = false;

            // Initialize a new CancellationTokenSource for this operation
            _cancellationTokenSource = new CancellationTokenSource();
            var ct = _cancellationTokenSource.Token;

            try
            {
                var loginModel = new LoginModel
                {
                    tagId = TagId,
                };

                // Use the managed cancellation token
                var jwtToken = await AuthenticateUser(loginModel, ct);

                if (jwtToken != null)
                {
                    await _tokenService.SaveTokenAsync(jwtToken);

                    var userTokenDetails = await _tokenService.GetUserDetailsFromToken();
                    // Load user data for profile view
                    var user = await _getService.GetByOne<UserModel, dynamic>(userTokenDetails.UserId, EndPoints.GetUserByIdEndPoint);

                    if (user == null)
                    {
                        return;
                    }

                    TagId = string.Empty;

                    // Reset UI indicators
                    LoadingIndicator = false;
                    LoginButtonVisibility = true;

                    _commonService?.InitializeAppShell();
                    await Shell.Current.GoToAsync($"///{nameof(ProfilePage)}", true, new Dictionary<string, object>
                    {
                        { "UserDetails", user }
                    });
                }
                else
                {
                    // Handle unsuccessful login
                    // Optionally, show an error message to the user
                }
            }
            catch (OperationCanceledException)
            {
               
            }
            catch (Exception)
            {
              
            }
            finally
            {
               
                LoadingIndicator = false;
                LoginButtonVisibility = true;

                _cancellationTokenSource.Dispose();
                _cancellationTokenSource = null;
            }
        }

        // Method to cancel the ongoing login operation
        public void CancelLogin()
        {
            if (_cancellationTokenSource != null && !_cancellationTokenSource.IsCancellationRequested)
            {
                _cancellationTokenSource.Cancel();
            }
        }

        private static async Task<string?> AuthenticateUser(LoginModel loginModel, CancellationToken cancellationToken)
        {
            try
            {
                using var client = new HttpClient();
                var json = JsonSerializer.Serialize(loginModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Use the cancellation token with the request
                var response = await client.PostAsync(EndPoints.loginEndPoint, content, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    // Pass the cancellation token to ReadAsStringAsync
                    var responseData = await response.Content.ReadAsStringAsync(cancellationToken);
                    return responseData;
                }
                else
                {
                    // Optionally, handle different status codes
                    return null;
                }
            }
            catch (OperationCanceledException)
            {
                // Optionally handle cancellation
                throw;
            }
            catch (Exception)
            {
                // Optionally, log the exception
                return null;
            }
        }
    }
}