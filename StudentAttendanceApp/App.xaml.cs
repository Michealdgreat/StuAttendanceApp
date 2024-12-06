using StudentAttendanceApp.MVVM.Models;
using StudentAttendanceApp.MVVM.ViewModels;
using StudentAttendanceApp.MVVM.Views;
using StudentAttendanceApp.Services;

namespace StudentAttendanceApp
{
    public partial class App : Application
    {
        private readonly LoginViewModel loginViewModel;
        private readonly RegisterViewModel _registerViewModel;
        private readonly ITokenService _tokenService;
        private readonly CommonService _commonService;
        private readonly GetService _getService;
        private readonly HomeViewModel _homeViewModel;

        public App(LoginViewModel loginViewModel, RegisterViewModel registerViewModel, ITokenService tokenService, CommonService commonService, GetService getService, HomeViewModel homeViewModel)
        {
            InitializeComponent();
            this.loginViewModel = loginViewModel;
            _registerViewModel = registerViewModel;
            _tokenService = tokenService;
            _commonService = commonService;
            _getService = getService;
            _homeViewModel = homeViewModel;
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

            return new Window(new NavigationPage(new StartUpPage(loginViewModel, _registerViewModel, _tokenService, _commonService, _getService, _homeViewModel)));
        }

        //protected override async void OnStart()
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