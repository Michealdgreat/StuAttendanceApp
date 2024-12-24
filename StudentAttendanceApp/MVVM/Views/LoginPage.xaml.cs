using StudentAttendanceApp.MVVM.ViewModels;

namespace StudentAttendanceApp.MVVM.Views
{
    public partial class LoginPage : ContentPage
    {


        public LoginPage(LoginViewModel loginViewModel)
        {
            InitializeComponent();
            BindingContext = loginViewModel;

        }

        private void ContentPage_Disappearing(object sender, EventArgs e)
        {
            if (BindingContext is LoginViewModel loginViewModel)
            {

                loginViewModel.CancelLogin();

            }
        }
    }
}
