using StudentAttendanceApp.MVVM.ViewModels;

namespace StudentAttendanceApp.MVVM.Views
{
    public partial class TapInNowPage : ContentPage
    {
        public TapInNowPage(TapInNowViewModel tapInNowViewModel)
        {
            InitializeComponent();
            BindingContext = tapInNowViewModel;
        }
    }
}
