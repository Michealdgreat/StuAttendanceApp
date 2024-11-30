using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using StudentAttendanceApp.MVVM.Models;
using StudentAttendanceApp.MVVM.ViewModels.Base;
using StudentAttendanceApp.MVVM.ViewModels.Messenger;
using StudentAttendanceApp.MVVM.Views;
using System.ComponentModel;

namespace StudentAttendanceApp.MVVM.ViewModels
{
    [QueryProperty(nameof(UserDetails), "UserDetails")]
    public partial class ProfileViewModel : BaseViewModel
    {

        [ObservableProperty]
        UserModel? userDetails;

        public ProfileViewModel()
        {


            //WeakReferenceMessenger.Default.Register<ValueChangedMessage<UserModel>>(this, (r, message) =>
            //{
            //    UserDetails = message.Value; // Update UserDetails with the received user data
            //});
        }

        [RelayCommand]
        public async Task TapInNow()
        {
            await Shell.Current.GoToAsync(nameof(ScanPage), true);
        }



    }
}
