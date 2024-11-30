using StudentAttendanceApp.MVVM.ViewModels;

namespace StudentAttendanceApp.MVVM.Views
{
    public partial class HomePage : ContentPage
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly RegisterViewModel _registerViewModel;

        public HomePage(LoginViewModel loginViewModel, RegisterViewModel registerViewModel)
        {
            InitializeComponent();
            _loginViewModel = loginViewModel;
            _registerViewModel = registerViewModel;

        }

        private async void Login_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage(_loginViewModel), true);
        }

        private async void Register_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage(_registerViewModel), true);
        }
    }
}
