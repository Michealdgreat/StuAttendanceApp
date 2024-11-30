using StudentAttendanceApp.MVVM.ViewModels;
using StudentAttendanceApp.MVVM.Views;
using StudentAttendanceApp.Services;

namespace StudentAttendanceApp
{
    public partial class App : Application
    {
        private readonly LoginViewModel loginViewModel;

        public App(LoginViewModel loginViewModel)
        {
            InitializeComponent();
            this.loginViewModel = loginViewModel;
            #region FORM HELPER
            // Borderless editor
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(FormHelper), (handler, view) =>
            {
                if (view is FormHelper)
                {
#if __ANDROID__
                    handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#elif __IOS__
                    handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif __WINDOWS__
                    handler.PlatformView.FontWeight = Microsoft.UI.Text.FontWeights.Thin;
                    handler.PlatformView.BorderThickness = new Microsoft.Maui.Graphics.MauiThickness(0);
#endif
                }
            });

            #endregion
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {

            return new Window(new NavigationPage(new HomePage(loginViewModel)));
        }

        //protected override void OnStart()
        //{
        //}

        //protected override void OnSleep()
        //{
        //}

        //protected override void OnResume()
        //{
        //}
    }
}