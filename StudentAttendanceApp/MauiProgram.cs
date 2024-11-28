using CommunityToolkit.Maui;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using SkiaSharp.Views.Maui.Controls.Hosting;
using StudentAttendanceApp.MVVM.ViewModels;
using StudentAttendanceApp.MVVM.Views;
using StudentAttendanceApp.Services;

namespace StudentAttendanceApp
{
    public static class MauiProgram
    {
        public static IServiceProvider? ServiceProvider { get; private set; }
        public static MauiApp CreateMauiApp()
        {


            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseSkiaSharp()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Nunito-Black.ttf", "StudentBlackFont");
                    fonts.AddFont("Nunito-Bold.ttf", "StudentBoldFont");
                    fonts.AddFont("Nunito-ExtraBold.ttf", "StudentExtraBoldFont");
                    fonts.AddFont("Nunito-Medium.ttf", "StudentMediumFont");
                    fonts.AddFont("Nunito-Regular.ttf", "StudentRegularFont");
                    fonts.AddFont("Nunito-SemiBold.ttf", "StudentSemiBoldFont");
                    fonts.AddFont("Nunito-Light.ttf", "StudentLightFont");
                    fonts.AddFont("StudentAttendanceIconFonts.ttf", "StudentIconFont");

                });



            builder.Services.AddTransient<ProfilePage>();
            builder.Services.AddTransient<RegisterPage>();
            builder.Services.AddTransient<ScanPage>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<HomePage>();
            builder.Services.AddTransient<IndexPage>();
            builder.Services.AddTransient<TapInNowPage>();



            builder.Services.AddSingleton<ProfileViewModel>();
            builder.Services.AddSingleton<RegisterViewModel>();
            builder.Services.AddSingleton<ScanViewModel>();
            builder.Services.AddSingleton<LoginViewModel>();
            builder.Services.AddSingleton<HomeViewModel>();
            builder.Services.AddSingleton<IndexViewModel>();
            builder.Services.AddSingleton<TapInNowViewModel>();



            builder.Services.AddSingleton<CommonService>();
            builder.Services.AddSingleton<ITokenService, TokenService>();
            builder.Services.AddSingleton<GetService>();
            builder.Services.AddSingleton<PostService>();



#if DEBUG
            builder.Logging.AddDebug();
#endif
            var app = builder.Build();

            ServiceProvider = app.Services;
            return app;
        }
    }
}
