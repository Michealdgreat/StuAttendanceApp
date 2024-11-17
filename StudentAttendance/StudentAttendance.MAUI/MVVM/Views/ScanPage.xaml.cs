

using StudentAttendance.MAUI.MVVM.ViewModels;
using StudentAttendance.MAUI.MVVM.Views;

namespace StudentAttendanceApp.MVVM.Views
{
    public partial class ScanPage : ContentPage
    {
        private readonly ScanViewModel scanViewModel;

        public ScanPage(ScanViewModel scanViewModel)
        {
            InitializeComponent();
            BindingContext = scanViewModel;
            this.scanViewModel = scanViewModel;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await scanViewModel.StartListening();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            scanViewModel.StopListening();
        }
    }
}
