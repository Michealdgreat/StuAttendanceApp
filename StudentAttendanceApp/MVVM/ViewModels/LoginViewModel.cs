using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using Microsoft.AspNetCore.SignalR.Client;
using StudentAttendanceApp.MVVM.Models;
using StudentAttendanceApp.MVVM.ViewModels.Base;
using StudentAttendanceApp.MVVM.ViewModels.Messenger;
using StudentAttendanceApp.MVVM.Views;
using StudentAttendanceApp.Services;
using System.ComponentModel;
using System.Text;
using System.Text.Json;

namespace StudentAttendanceApp.MVVM.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        private readonly ITokenService _tokenService;
        private readonly CommonService _commonService;
        private readonly GetService _getService;
        private HubConnection _hubConnection;


        [ObservableProperty]
        private string? tagId;

        [ObservableProperty]
        private bool isPasswordVisible = true;

        [ObservableProperty]
        private bool loadingIndicator = false;

        [ObservableProperty]
        private bool loginButtonVisibility = true;

        public LoginViewModel(ITokenService tokenService, CommonService commonService, GetService getService)
        {
            _tokenService = tokenService;
            _commonService = commonService;
            _getService = getService;
            InitializeSignalR();
        }

        [RelayCommand]
        public void viewTagid()
        {
            if (IsPasswordVisible == false)
            {
                IsPasswordVisible = true;
            }
            else
            {
                IsPasswordVisible = false;
            }
        }

        private async void InitializeSignalR()
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

        [RelayCommand]
        public async Task LoginButton()
        {
            //var commonService = MauiProgram.ServiceProvider!.GetService<CommonService>();

            LoadingIndicator = true;
            LoginButtonVisibility = false;

            try
            {
                var loginModel = new LoginModel
                {
                    TagId = TagId,
                };

                var jwtToken = await AuthenticateUser(loginModel);


                if (jwtToken != null)
                {
                    await _tokenService.SaveTokenAsync(jwtToken);

                    var userTokenDetails = await _tokenService.GetUserDetailsFromToken();

                    //loading user data for profile view
                    var user = await _getService.GetByOne<UserModel, dynamic>(userTokenDetails.UserId, EndPoints.GetUserByIdEndPoint);

                    TagId = string.Empty;
                    LoadingIndicator = false;
                    LoginButtonVisibility = true;

                    _commonService?.InitializeAppShell();
                    await Shell.Current.GoToAsync($"///{nameof(ProfilePage)}", true, new Dictionary<string, object>
        {
                        { "UserDetails", user }
                    });
                    //WeakReferenceMessenger.Default.Send(new ValueChangedMessage<UserModel>(user));

                }
            }
            catch (Exception)
            {
                LoadingIndicator = false;
                LoginButtonVisibility = true;

            }


        }


        private static async Task<string> AuthenticateUser(LoginModel loginModel)
        {
            try
            {
                using var client = new HttpClient();
                var json = JsonSerializer.Serialize(loginModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(EndPoints.loginEndPoint, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    return responseData;
                }
                else
                {
                    return null!;

                }
            }
            catch (Exception)
            {
                return null!;

            }
        }
    }
}
