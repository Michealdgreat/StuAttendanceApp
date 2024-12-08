using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentAttendanceApp.MVVM.ViewModels.Base;
using StudentAttendanceApp.MVVM.Views;
using System.ComponentModel;

namespace StudentAttendanceApp.MVVM.ViewModels
{
    public partial class IndexViewModel : BaseViewModel
    {



        [RelayCommand]
        private async Task CreateCourse()
        {
            await Shell.Current.GoToAsync(nameof(CreateCoursePage));
        }


        [RelayCommand]
        private async Task CreateSession()
        {
            await Shell.Current.GoToAsync(nameof(CreateSessionPage));
        }

    }
}
