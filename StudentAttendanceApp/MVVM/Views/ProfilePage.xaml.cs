using StudentAttendanceApp.MVVM.ViewModels;

namespace StudentAttendanceApp.MVVM.Views
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage(ProfileViewModel profileViewModel)
        {
            InitializeComponent();
            BindingContext = profileViewModel;
        }
    }
}
