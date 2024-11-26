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
    }
}
