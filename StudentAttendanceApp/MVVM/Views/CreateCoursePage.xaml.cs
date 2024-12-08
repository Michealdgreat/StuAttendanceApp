using StudentAttendanceApp.MVVM.ViewModels;

namespace StudentAttendanceApp.MVVM.Views
{
    public partial class CreateCoursePage : ContentPage
    {
        public CreateCoursePage(CreateCourseViewModel createCourseViewModel)
        {
            InitializeComponent();
            BindingContext = createCourseViewModel;

        }
    }
}
