using StudentAttendanceApp.MVVM.ViewModels;
using StudentAttendanceApp.Services;

namespace StudentAttendanceApp.MVVM.Views
{
    public partial class ProfilePage : ContentPage
    {
        private readonly ITokenService _tokenService;
        private readonly RegisterViewModel _registerViewModel;
        private readonly LoginViewModel _loginViewModel;
        private readonly HomeViewModel _homeViewModel;

        public ProfilePage(ProfileViewModel profileViewModel, ITokenService tokenService, RegisterViewModel registerViewModel, LoginViewModel loginViewModel, HomeViewModel homeViewModel)
        {
            InitializeComponent();
            BindingContext = profileViewModel;
            _tokenService = tokenService;
            _registerViewModel = registerViewModel;
            _loginViewModel = loginViewModel;
            _homeViewModel = homeViewModel;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            _tokenService.DeleteToken();

            var mainPage = Application.Current!.Windows[0].Page;

            bool answer = await mainPage.DisplayAlert("Logout!", "Are you sure you want to logout?", "Yes", "No");

            if (answer == true)
            {
                Application.Current!.Windows[0].Page = new NavigationPage(new HomePage(_loginViewModel, _registerViewModel));

                _homeViewModel.LoadingIndicator = true;
                _homeViewModel.HomePageContentVisibility = false;
            }
            else
            {

            }
        }

    }
}
