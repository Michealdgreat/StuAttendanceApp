using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace StudentAttendanceApp
{
    public static class MauiProgram
    {
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

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
