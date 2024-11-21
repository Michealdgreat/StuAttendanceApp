using StudentAttendanceApp.Services;

namespace StudentAttendanceApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            #region FORM HELPER
            //Borderless editor
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
                handler.PlatformView.BorderThickness = new Thickness(0);
#endif
                }
            });
            #endregion
            return new Window(new AppShell());
        }
    }
}