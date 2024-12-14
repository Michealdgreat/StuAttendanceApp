using StudentAttendanceApp.MVVM.Views;

namespace StudentAttendanceApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(ScanPage), typeof(ScanPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
            Routing.RegisterRoute(nameof(StartUpPage), typeof(StartUpPage));
            Routing.RegisterRoute(nameof(CreateCoursePage), typeof(CreateCoursePage));
            Routing.RegisterRoute(nameof(CreateSessionPage), typeof(CreateSessionPage));
            Routing.RegisterRoute(nameof(ManageCoursePage), typeof(ManageCoursePage));
            Routing.RegisterRoute(nameof(ManageSessionPage), typeof(ManageSessionPage));
            Routing.RegisterRoute(nameof(CourseDetailsPage), typeof(CourseDetailsPage));



        }
    }
}
