using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentAttendanceApp.MVVM.Models;
using StudentAttendanceApp.MVVM.ViewModels.Base;
using StudentAttendanceApp.MVVM.Views;
using StudentAttendanceApp.Services;
using System;
using System.Collections.ObjectModel;

namespace StudentAttendanceApp.MVVM.ViewModels
{
    public partial class ManageCourseViewModel : BaseViewModel
    {
        private readonly GetService _getService;
        private readonly ITokenService _tokenService;

        [ObservableProperty]
        private ObservableCollection<CourseModel> courses;

        [ObservableProperty]
        private bool doUserHaveAnyCourse = false;

        [ObservableProperty]
        private bool showCourses = true;

        public ManageCourseViewModel(GetService getService, ITokenService tokenService)
        {
            Courses = new ObservableCollection<CourseModel>();
            _getService = getService;
            _tokenService = tokenService;
        }

        [RelayCommand]
        public async Task FetchCoursesAsync()
        {
            try
            {
                var userTokenDetails = await _tokenService.GetUserDetailsFromToken();

                var coursesList = await _getService.GetList<CourseModel, dynamic>(userTokenDetails.UserId, EndPoints.GetCoursesByTeacherId);
                if (coursesList != null && coursesList.Count > 0)
                {
                    Courses = coursesList;
                    ShowCourses = true;
                    DoUserHaveAnyCourse = false;
                }
                else
                {
                    ShowCourses = false;
                    DoUserHaveAnyCourse = true;
                }
            }
            catch (Exception)
            {
                ShowCourses = false;
                DoUserHaveAnyCourse = true;
            }
        }

        [RelayCommand]
        public async Task CourseTapped(CourseModel tappedModel)
        {
            if (tappedModel == null) return;

            await Shell.Current.GoToAsync(nameof(CourseDetailsPage), true, new Dictionary<string, object>
            {
                { "CourseDetails", tappedModel }
            });
        }
    }
}