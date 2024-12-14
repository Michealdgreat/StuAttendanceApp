using StudentAttendanceApp.MVVM.ViewModels;

namespace StudentAttendanceApp.MVVM.Views
{
    public partial class ManageCoursePage : ContentPage
    {
        public ManageCoursePage(ManageCourseViewModel manageCourseViewModel)
        {
            InitializeComponent();
            BindingContext = manageCourseViewModel;
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            if (BindingContext is ManageCourseViewModel viewModel)
            {
                
                viewModel.FetchCoursesCommand.Execute(null);
            }
        }
    }
}
