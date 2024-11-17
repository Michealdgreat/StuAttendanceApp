using StudentAttendance.MAUI.MVVM.Views;
using StudentAttendance.MAUI.MVVM.ViewModels;

namespace StudentAttendance.MAUI.MVVM.Views
{
    public partial class MainPage : BaseContentPage
    {
        private readonly MainViewModel mainvm;

        public MainPage(MainViewModel mainvm) : base(mainvm)
        {
            InitializeComponent();
            this.mainvm = mainvm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            mainvm.ExecuteOnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            mainvm.ExecuteOnDisappearing();
        }
        //SemanticScreenReader.Announce();
    }
}
