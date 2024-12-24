using AsyncAwaitBestPractices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.SignalR.Client;
using StudentAttendanceApp.MVVM.Models;
using StudentAttendanceApp.MVVM.ViewModels.Base;
using StudentAttendanceApp.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;

namespace StudentAttendanceApp.MVVM.ViewModels
{
    [QueryProperty(nameof(CourseId), "CourseId")]
    [QueryProperty(nameof(CourseName), "CourseName")]
    public partial class TapInNowViewModel : BaseViewModel
    {
        private readonly GetService _getService;
        private readonly ITokenService _tokenService;
        private readonly PostService _postService;
        private HubConnection _hubConnection;

        [ObservableProperty]
        private string? tagId;

        [ObservableProperty]
        private ObservableCollection<SessionDto> sessions;

        [ObservableProperty]
        private SessionDto? selectedSession;

        [ObservableProperty]
        private Guid courseId;

        [ObservableProperty]
        private Guid userSigningInId;

        [ObservableProperty]
        private bool lockContent = true;

        [ObservableProperty]
        private bool isCourseReady = false;

        [ObservableProperty]
        private bool readTagId = true;

        [ObservableProperty]
        private bool displayTagId = false;

        [ObservableProperty]
        private string? courseName;

        public TapInNowViewModel(GetService getService, ITokenService tokenService, PostService postService)
        {
            Sessions = new ObservableCollection<SessionDto>();
            _getService = getService;
            _tokenService = tokenService;
            _postService = postService;
            InitializeSignalR();
        }

        public void ClearData()
        {
            TagId = string.Empty;
        }

        partial void OnTagIdChanged(string? value)
        {
            ReadTagId = false;
            DisplayTagId = true;
        }

        private async void InitializeSignalR()
        {

            try
            {
                _hubConnection = new HubConnectionBuilder()
                    .WithUrl(EndPoints.loginHubEndPoint)
                .Build();

                _hubConnection.On<string>("ReceiveTagId", (tagId) =>
                {
                    TagId = tagId;
                });

                await _hubConnection.StartAsync();
            }
            catch (HttpRequestException)
            {

            }
            catch (Exception)
            {

            }
        }


        partial void OnCourseIdChanged(Guid value)
        {
            LoadCurrentSessions(value).SafeFireAndForget();
        }

        private async Task LoadCurrentSessions(Guid courseId)
        {

            try
            {


                var userTokenDetails = await _tokenService.GetUserDetailsFromToken();
                var sessions = await _getService.GetList<SessionDto, dynamic>(courseId, EndPoints.GetSessionByCourseId);

                if (sessions != null && sessions.Any())
                {
                    Sessions.Clear();

                    var lastSession = sessions.Last();

                    Sessions.Add(lastSession);

                    SelectedSession = lastSession;

                    LockContent = false;
                    IsCourseReady = true;
                }

            }
            catch (Exception)
            {

            }
        }

        [RelayCommand]
        public async Task TapInAsync(CancellationToken cancellationToken)
        {
            if (SelectedSession == null) return;
            try
            {

                if (TagId != null)
                {
                    var hashPass = Sha256Hasher.Hash(TagId);

                    var userdetails = await _getService.GetByOne<UserDtoForClaims, dynamic>(tagId, EndPoints.GetUserByTagIdEndPoint);

                    UserSigningInId = userdetails.UserId;
                }

                var attendance = new AttendanceModel
                {
                    AttendanceId = Guid.NewGuid(),
                    SessionId = SelectedSession.SessionId,
                    StudentId = UserSigningInId,
                    SignInAt = DateTime.Now
                };

                await _postService.PostAsync<AttendanceModel, PostResponseMessage>(attendance, EndPoints.CreateAttendanceRecord, cancellationToken);
            }
            catch (Exception)
            {


            }
        }

        [RelayCommand]
        public async Task LeaveAsync(CancellationToken cancellationToken)
        {
            if (SelectedSession == null) return;

            try
            {

                if (TagId != null)
                {
                    var hashPass = Sha256Hasher.Hash(TagId);

                    var userdetails = await _getService.GetByOne<UserDtoForClaims, dynamic>(tagId, EndPoints.GetUserByTagIdEndPoint);

                    UserSigningInId = userdetails.UserId;
                }


                var attendance = new AttendanceModel
                {
                    AttendanceId = Guid.NewGuid(),
                    SessionId = SelectedSession.SessionId,
                    StudentId = UserSigningInId,
                    SignOutAt = DateTime.Now
                };

                await _postService.PostAsync<AttendanceModel, PostResponseMessage>(attendance, EndPoints.UpdateAttendanceRecord, cancellationToken);
            }
            catch (Exception)
            {


            }

        }
    }
}