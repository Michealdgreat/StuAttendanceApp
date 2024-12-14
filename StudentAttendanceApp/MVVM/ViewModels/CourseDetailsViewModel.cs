using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentAttendanceApp.MVVM.Models;
using StudentAttendanceApp.MVVM.ViewModels.Base;
using StudentAttendanceApp.MVVM.Views;

namespace StudentAttendanceApp.MVVM.ViewModels
{
    [QueryProperty(nameof(CourseDetails), "CourseDetails")]
    public partial class CourseDetailsViewModel : BaseViewModel
    {
        [ObservableProperty]
        private CourseModel? courseDetails;

        [RelayCommand]
        private async Task NavigateToCreateSessionAsync()
        {
            if (CourseDetails != null)
            {
                var navigationParameter = new Dictionary<string, object> { { "CourseId", CourseDetails.CourseId } };
                await Shell.Current.GoToAsync("CreateSessionPage", navigationParameter);
            }
        }


        [RelayCommand]
        private async Task GotoTapInView()
        {
            await Shell.Current.GoToAsync(
                $"///{nameof(TapInNowPage)}",
                new Dictionary<string, object>
                {
            { "CourseId", courseDetails.CourseId },
            { "CourseName", courseDetails.CourseName }
                });
        }
    }
}