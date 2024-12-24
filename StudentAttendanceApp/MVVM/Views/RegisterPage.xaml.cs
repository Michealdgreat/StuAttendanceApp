using StudentAttendanceApp.MVVM.ViewModels;

namespace StudentAttendanceApp.MVVM.Views
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage(RegisterViewModel registerViewModel)
        {
            InitializeComponent();
            BindingContext = registerViewModel;
        }

        private void ContentPage_Disappearing(object sender, EventArgs e)
        {
            if (BindingContext is RegisterViewModel viewModel)
            {
                viewModel.CancelRegister();
            }

        }
    }
}
