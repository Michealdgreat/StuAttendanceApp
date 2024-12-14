using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;
using StudentAttendanceApp.MVVM.Models;
using StudentAttendanceApp.Services;
using StudentAttendanceApp.MVVM.ViewModels.Base;

namespace StudentAttendanceApp.MVVM.ViewModels
{
    [QueryProperty(nameof(CourseId), "CourseId")]

    public partial class CreateSessionViewModel : BaseViewModel
    {
        // based on selected course
        [ObservableProperty]
        private Guid courseId;

        [ObservableProperty]
        private DateTime date = DateTime.Now;

        [ObservableProperty]
        private TimeSpan startAt = TimeSpan.Zero;

        [ObservableProperty]
        private TimeSpan endAt = TimeSpan.Zero;

        [ObservableProperty]
        private string? name;

        [ObservableProperty]
        private bool isLoading;

        [ObservableProperty]
        private string? message;

        [ObservableProperty]
        private bool isMessageVisible;

        private readonly PostService _postService;

        public CreateSessionViewModel(PostService postService)
        {
            _postService = postService;
        }

        [RelayCommand]
        private async Task CreateSessionAsync()
        {
            IsLoading = true;
            IsMessageVisible = false;

            var newSession = new SessionModel
            {
                SessionId = Guid.NewGuid(),
                CourseId = CourseId,
                Name = Name,
                Date = Date,
                StartAt = StartAt,
                EndAt = EndAt
            };

            try
            {

                var response = await _postService.PostAsync<SessionModel, PostResponseMessage>(
                    newSession, EndPoints.CreateSession);

                if (response != null && response.Status == 200)
                {

                    Name = string.Empty;
                    Message = "Session created successfully!";
                }
                else
                {
                    Message = "Failed to create the session. Please try again.";
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