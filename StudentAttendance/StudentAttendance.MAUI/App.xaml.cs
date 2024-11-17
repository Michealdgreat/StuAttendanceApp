using StudentAttendance.MAUI.Interfaces;
using StudentAttendance.MAUI.MVVM.ViewModels;
using StudentAttendance.MAUI.MVVM.Views;
using StudentAttendanceApp.MVVM.Views;

namespace StudentAttendance.MAUI
{
    public partial class App : Application
    {
        public App(IServiceProvider provider)
        {
            InitializeComponent();
            var viewModel = provider.GetService<ScanViewModel>();
            MainPage = new ScanPage(viewModel);
        }
    }

}
