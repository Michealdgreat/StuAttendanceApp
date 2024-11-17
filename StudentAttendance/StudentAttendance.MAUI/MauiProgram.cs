//#if ANDROID||iOS
//using StudentAttendance.MAUI.Platforms;
//#endif

using CommunityToolkit.Maui;
using StudentAttendance.MAUI.Interfaces;
using StudentAttendance.MAUI.MVVM.ViewModels;

namespace StudentAttendance.MAUI
{
    public static class MauiProgram
    {
        public static MauiAppBuilder builder;

        public static MauiApp CreateMauiApp()
        {
            builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            //#if ANDROID || iOS
            //                        builder.Services.AddTransient<Interfaces.INfcService, NfcService>();
            //#endif
            builder.Services.AddTransient<INfcService, NfcService>();
            builder.Services.AddTransient<BaseViewModel>();

            return builder.Build();
        }
    }

}
