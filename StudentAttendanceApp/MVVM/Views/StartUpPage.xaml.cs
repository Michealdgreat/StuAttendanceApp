using StudentAttendanceApp.MVVM.Models;
using StudentAttendanceApp.MVVM.ViewModels;
using StudentAttendanceApp.Services;

namespace StudentAttendanceApp.MVVM.Views
{

    public partial class StartUpPage : ContentPage
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly RegisterViewModel _registerViewModel;
        private readonly ITokenService _tokenService;
        private readonly CommonService _commonService;
        private readonly GetService _getService;
        private readonly HomeViewModel _homeViewModel;

        public StartUpPage(LoginViewModel loginViewModel, RegisterViewModel registerViewModel, ITokenService tokenService, CommonService commonService, GetService getService, HomeViewModel homeViewModel)
        {
            InitializeComponent();

            _loginViewModel = loginViewModel;
            _registerViewModel = registerViewModel;
            _tokenService = tokenService;
            _commonService = commonService;
            _getService = getService;
            _homeViewModel = homeViewModel;

        }
        private async void ContentPage_Loaded(object sender, EventArgs e)
        {
            try
            {
                var userToken = await _tokenService.GetTokenAsync();
                var mainPage = Application.Current?.Windows[0];
                if (mainPage == null) return;

                if (!string.IsNullOrEmpty(userToken))
                {
                    var userTokenDetails = await _tokenService.GetUserDetailsFromToken();
                    var user = await _getService.GetByOne<UserModel, dynamic>(userTokenDetails.UserId, EndPoints.GetUserByIdEndPoint);
                    _commonService?.InitializeAppShell();
                    await Shell.Current.GoToAsync($"///{nameof(ProfilePage)}", true, new Dictionary<string, object>
            {
                { "UserDetails", user }
            });
                }
                else
                {
                    mainPage.Page = new NavigationPage(new HomePage(_loginViewModel, _registerViewModel));
                }
            }
            catch (Exception ex)
            {
                _homeViewModel.LoadingIndicator = false;
                _homeViewModel.HomePageContentVisibility = true;
                var mainPage = Application.Current?.Windows[0];
                if (mainPage != null)
                {
                    mainPage.Page = new NavigationPage(new HomePage(_loginViewModel, _registerViewModel));
                }
            }
        }
    }

}