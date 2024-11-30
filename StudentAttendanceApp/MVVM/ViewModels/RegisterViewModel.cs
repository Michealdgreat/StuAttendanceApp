using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using StudentAttendanceApp.MVVM.ViewModels.Base;
using System.Collections.ObjectModel;
using StudentAttendanceApp.MVVM.Models;
using StudentAttendanceApp.Services;
using StudentAttendanceApp.MVVM.Views;


namespace StudentAttendanceApp.MVVM.ViewModels
{
    public partial class RegisterViewModel : BaseViewModel
    {

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
        private bool departmentFieldVisibility = false;

        public ObservableCollection<String> UserRoles { get; set; }

        [ObservableProperty]
        private string? selectedRole;
        private readonly PostService _postService;
        private readonly LoginViewModel _loginViewModel;

        public RegisterViewModel(PostService postService, LoginViewModel loginViewModel)
        {
            UserRoles = ["Student", "Teacher"];
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

            if (SelectedRole == "Teacher")
            {
                UserRole = 1;
                Group = string.Empty;
                DepartmentFieldVisibility = true;
                GroupFieldVisibility = false;
            }
        }

        [RelayCommand]
        private async Task RegisterButton()
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

            await RegisterUserAsync(registerModel);
        }


        public async Task RegisterUserAsync(RegisterModel userRegisterModel)
        {


            try
            {

                var responseObject = await _postService.PostAsync<RegisterModel, PostResponseMessage>(
                    userRegisterModel, EndPoints.RegisterUserEndpoint);

                if (responseObject != null)
                {
                    if (responseObject.Status == 10)
                    {

                        var mainPage = Application.Current!.Windows[0].Page;
                        await mainPage.DisplayAlert("Required", " fields required", "OK");
                    }

                    if (responseObject.Status == 200)
                    {

                        FirstName = null;
                        LastName = null;
                        Email = null;
                        TagId = null;
                        UserRole = 0;
                        Group = null;
                        Department = null;

                        var mainPage = Application.Current!.Windows[0].Page;
                        await mainPage.DisplayAlert("SUCCESS", "Account created successfully, you can login now!", "OK");

                        await mainPage.Navigation.PushAsync(new LoginPage(_loginViewModel));



                    }



                }
                else
                {

                    var mainPage = Application.Current!.Windows[0].Page;
                    await mainPage.DisplayAlert("Error", "Something went wrong while processing your request", " Please try again.");
                }
            }
            catch (Exception)
            {

                var mainPage = Application.Current!.Windows[0].Page;
                await mainPage.DisplayAlert("Error", "Something went wrong while processing your request", " Please try again.");
            }

        }

    }

}


