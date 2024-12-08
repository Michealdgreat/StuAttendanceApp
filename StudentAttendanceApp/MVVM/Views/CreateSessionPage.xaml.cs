using StudentAttendanceApp.MVVM.ViewModels;

namespace StudentAttendanceApp.MVVM.Views
{
    public partial class CreateSessionPage : ContentPage
    {
        public CreateSessionPage(CreateSessionViewModel createSessionViewModel)
        {
            InitializeComponent();
            BindingContext = createSessionViewModel;

        }
    }
}
