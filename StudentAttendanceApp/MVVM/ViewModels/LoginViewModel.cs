using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
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
    public partial class LoginViewModel(ITokenService tokenService, CommonService commonService, GetService getService) : BaseViewModel
    {
        private readonly ITokenService _tokenService = tokenService;
        private readonly CommonService _commonService = commonService;
        private readonly GetService _getService = getService;

        [ObservableProperty]
        private string? tagId;

        [RelayCommand]
        public async Task LoginButton()
        {
            //var commonService = MauiProgram.ServiceProvider!.GetService<CommonService>();

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

                    //preloading user data
                    var user = await _getService.GetByOne<UserModel, dynamic>(userTokenDetails.UserId, EndPoints.GetUserByIdEndPoint);

                    WeakReferenceMessenger.Default.Send(new UserMessage(user));


                    _commonService?.InitializeAppShell();
                    await Shell.Current.GoToAsync($"///{nameof(ProfilePage)}", true);
                }
            }
            catch (Exception)
            {


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
