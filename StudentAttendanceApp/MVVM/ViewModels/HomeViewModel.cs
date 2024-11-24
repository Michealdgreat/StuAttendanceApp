using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentAttendanceApp.MVVM.ViewModels.Base;
using StudentAttendanceApp.MVVM.Views;
using System.ComponentModel;

namespace StudentAttendanceApp.MVVM.ViewModels
{
    public partial class HomeViewModel : BaseViewModel
    {



        [RelayCommand]
        public async Task LoginYourAccount()
        {
            // await Shell.Current.GoToAsync(nameof(LoginPage));
        }

        [RelayCommand]
        public async Task RegisterForAnAccount()
        {
            //await Shell.Current.GoToAsync(nameof(RegisterPage));
        }
    }
}
