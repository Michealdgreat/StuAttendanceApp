using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentAttendanceApp.MVVM.ViewModels.Base;
using StudentAttendanceApp.MVVM.Views;
using StudentAttendanceApp.Services;
using System.ComponentModel;

namespace StudentAttendanceApp.MVVM.ViewModels
{
    public partial class LoginViewModel() : BaseViewModel
    {

        [RelayCommand]
        public async Task LoginButton()
        {
            var commonService = MauiProgram.ServiceProvider!.GetService<CommonService>();

            commonService?.InitializeAppShell();
            await Shell.Current.GoToAsync($"///{nameof(ProfilePage)}", true);
        }
    }
}
