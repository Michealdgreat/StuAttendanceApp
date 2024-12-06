using CommunityToolkit.Maui;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.AspNetCore.SignalR.Client;
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



            builder.Services.AddSingleton<ProfilePage>();
            builder.Services.AddSingleton<RegisterPage>();
            builder.Services.AddSingleton<ScanPage>();
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<HomePage>();
            builder.Services.AddSingleton<IndexPage>();
            builder.Services.AddSingleton<TapInNowPage>();

            builder.Services.AddTransient<ProfileViewModel>();
            builder.Services.AddTransient<RegisterViewModel>();
            builder.Services.AddTransient<ScanViewModel>();
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<HomeViewModel>();
            builder.Services.AddTransient<IndexViewModel>();
            builder.Services.AddTransient<TapInNowViewModel>();


            builder.Services.AddSingleton<CommonService>();
            builder.Services.AddSingleton<ITokenService, TokenService>();
            builder.Services.AddSingleton<GetService>();
            builder.Services.AddSingleton<PostService>();
            //builder.Services.AddSingleton<HubConnection>();

            builder.Services.AddHttpClient<PostService>();



#if DEBUG
            builder.Logging.AddDebug();
#endif
            var app = builder.Build();

            ServiceProvider = app.Services;
            return app;
        }
    }
}
