using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;
using StudentAttendanceApp.MVVM.Models;
using StudentAttendanceApp.Services;
using StudentAttendanceApp.MVVM.ViewModels.Base;

namespace StudentAttendanceApp.MVVM.ViewModels
{
    public partial class CreateCourseViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string? courseName;

        [ObservableProperty]
        private bool isLoading;

        [ObservableProperty]
        private string? message;

        [ObservableProperty]
        private bool isMessageVisible;

        private readonly PostService _postService;

        public CreateCourseViewModel(PostService postService)
        {
            _postService = postService;
        }

        [RelayCommand]
        private async Task CreateCourseAsync(CancellationToken cancellationToken)
        {
            IsLoading = true;
            IsMessageVisible = false;

            var newCourse = new CourseModel
            {
                CourseId = Guid.NewGuid(),
                CourseName = CourseName,
                CreatedAt = DateTime.UtcNow
            };

            try
            {

                var response = await _postService.PostAsync<CourseModel, PostResponseMessage>(
                    newCourse, EndPoints.CreateCourse, cancellationToken);

                if (response != null && response.Status == 200)
                {

                    CourseName = string.Empty;
                    Message = "Course created successfully!";
                }
                else
                {
                    Message = "Failed to create the course. Please try again.";
                }
            }
            catch (Exception ex)
            {
                Message = $"An error occurred: {ex.Message}";
            }
            finally
            {
                IsLoading = false;
                IsMessageVisible = true;
            }
        }
    }
}