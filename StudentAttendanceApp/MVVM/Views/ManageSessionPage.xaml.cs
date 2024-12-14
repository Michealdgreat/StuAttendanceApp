using StudentAttendanceApp.MVVM.ViewModels;

namespace StudentAttendanceApp.MVVM.Views
{
    public partial class ManageSessionPage : ContentPage
    {
        public ManageSessionPage(ManageSessionViewModel manageSessionViewModel)
        {
            InitializeComponent();
            BindingContext = manageSessionViewModel;
        }
    }
}
