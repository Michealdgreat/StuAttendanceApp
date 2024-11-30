using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using StudentAttendanceApp.MVVM.ViewModels.Base;
using System.Collections.ObjectModel;


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



        public RegisterViewModel()
        {
            UserRoles = ["Student", "Teacher"];
            SelectedRole = UserRoles.FirstOrDefault()!;
            UserRole = 1;
            UpdateFieldVisibility();
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
                UserRole = 1;
                GroupFieldVisibility = true;
                DepartmentFieldVisibility = false;
            }

            if (SelectedRole == "Teacher")
            {
                UserRole = 2;
                DepartmentFieldVisibility = true;
                GroupFieldVisibility = false;
            }
        }



    }
}
