namespace StudentAttendanceApp.MVVM.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private async void Login_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage(), true);
        }

        private async void Register_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage(), true);
        }
    }
}
