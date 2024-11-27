using StudentAttendanceApp.MVVM.ViewModels;

namespace StudentAttendanceApp.MVVM.Views
{
    public partial class HomePage : ContentPage
    {
        private readonly LoginViewModel _loginViewModel;

        public HomePage(LoginViewModel loginViewModel)
        {
            InitializeComponent();
            _loginViewModel = loginViewModel;
        }

        private async void Login_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage(_loginViewModel), true);
        }

        private async void Register_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage(), true);
        }
    }
}
