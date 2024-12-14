using StudentAttendanceApp.MVVM.ViewModels;

namespace StudentAttendanceApp.MVVM.Views
{
    public partial class CourseDetailsPage : ContentPage
    {
        public CourseDetailsPage(CourseDetailsViewModel courseDetailsViewModel)
        {
            InitializeComponent();
            BindingContext = courseDetailsViewModel;
        }
    }
}
