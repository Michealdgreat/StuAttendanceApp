using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using StudentAttendanceApp.MVVM.Models;
using StudentAttendanceApp.Services;
using StudentAttendanceApp.MVVM.Views;
using Microsoft.Maui.Controls;
using StudentAttendanceApp.MVVM.ViewModels.Base; // Assuming you're using .NET MAUI; use Xamarin.Forms if applicable

namespace StudentAttendanceApp.MVVM.ViewModels
{
    public partial class RegisterViewModel : BaseViewModel
    {
        // Observable Properties
        [ObservableProperty]
        private string? firstName;

        [ObservableProperty]
        private string? lastName;

        [ObservableProperty]
        private string? email;

        [ObservableProperty]
        private string? group;

        [ObservableProperty]
        private string? tagId;

        [ObservableProperty]
        private string? department;

        [ObservableProperty]
        private int userRole;

        [ObservableProperty]
        private bool groupFieldVisibility = false;

        [ObservableProperty]
        private bool loadingIndicator = false;

        [ObservableProperty]
        private bool registerButtonVisibility = true;

        [ObservableProperty]
        private bool departmentFieldVisibility = false;

        [ObservableProperty]
        private string? selectedRole;

        public ObservableCollection<string> UserRoles { get; set; }

        private readonly PostService _postService;

        private CancellationTokenSource? _cancellationTokenSource;

        private readonly LoginViewModel _loginViewModel;

        public RegisterViewModel(PostService postService, LoginViewModel loginViewModel)
        {

            UserRoles = new ObservableCollection<string> { "Student", "Teacher" };
            SelectedRole = UserRoles.FirstOrDefault()!;
            UserRole = 0;
            UpdateFieldVisibility();

            _postService = postService;
            _loginViewModel = loginViewModel;
        }


        partial void OnSelectedRoleChanged(string? value)
        {
            UpdateFieldVisibility();
        }


        private void UpdateFieldVisibility()
        {
            GroupFieldVisibility = false;
            DepartmentFieldVisibility = false;

            if (SelectedRole == "Student")
            {
                UserRole = 0;
                Department = string.Empty;
                GroupFieldVisibility = true;
                DepartmentFieldVisibility = false;
            }
            else if (SelectedRole == "Teacher")
            {
                UserRole = 1;
                Group = string.Empty;
                DepartmentFieldVisibility = true;
                GroupFieldVisibility = false;
            }
        }


        [RelayCommand]
        public async Task RegisterButtonAsync(CancellationToken ct)
        {

            if (LoadingIndicator)
                return;

            LoadingIndicator = true;
            RegisterButtonVisibility = false;


            _cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(ct);
            var cancellationToken = _cancellationTokenSource.Token;

            try
            {
                var registerModel = new RegisterModel
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Email = Email,
                    TagId = TagId,
                    UserRole = UserRole,
                    StudentGroup = Group,
                    Department = Department,
                    AvatarUrl = string.Empty,
                    CreatedAt = DateTime.UtcNow,
                };

                await RegisterUserAsync(registerModel, cancellationToken);
            }
            catch (OperationCanceledException)
            {

            }
            catch (Exception)
            {

            }
            finally
            {

                LoadingIndicator = false;
                RegisterButtonVisibility = true;

                _cancellationTokenSource?.Dispose();
                _cancellationTokenSource = null;
            }
        }


        public void CancelRegister()
        {
            if (_cancellationTokenSource != null && !_cancellationTokenSource.IsCancellationRequested)
            {
                _cancellationTokenSource.Cancel();
            }
        }


        public async Task RegisterUserAsync(RegisterModel userRegisterModel, CancellationToken cancellationToken)
        {
            try
            {
                var responseObject = await _postService.PostAsync<RegisterModel, PostResponseMessage>(
                    userRegisterModel, EndPoints.RegisterUserEndpoint, cancellationToken);

                if (responseObject != null)
                {
                    if (responseObject.Status == 10)
                    {
                        await Shell.Current.DisplayAlert("Required", "All fields are required.", "OK");
                        TagId = null;
                    }
                    else if (responseObject.Status == 200)
                    {

                        FirstName = null;
                        LastName = null;
                        Email = null;
                        TagId = null;
                        UserRole = 0;
                        Group = null;
                        Department = null;

                        await Shell.Current.DisplayAlert("SUCCESS", "Account created successfully! You can now log in.", "OK");


                        await Shell.Current.GoToAsync($"///{nameof(LoginPage)}");
                    }
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "Something went wrong while processing your request. Please try again.", "OK");
                }
            }
            catch (OperationCanceledException)
            {

                throw;
            }
            catch (Exception)
            {
                await Shell.Current.DisplayAlert("Error", "Something went wrong while processing your request. Please try again.", "OK");
            }
        }
    }
}