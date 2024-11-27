using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using StudentAttendanceApp.MVVM.Models;
using StudentAttendanceApp.MVVM.ViewModels.Base;
using StudentAttendanceApp.MVVM.ViewModels.Messenger;
using System.ComponentModel;

namespace StudentAttendanceApp.MVVM.ViewModels
{
    public partial class ProfileViewModel : BaseViewModel, IRecipient<UserMessage>
    {

        [ObservableProperty]
        private UserModel? userDetails;

        public ProfileViewModel()
        {

            WeakReferenceMessenger.Default.Register<UserMessage>(this, (r, message) => Receive(message));

            //WeakReferenceMessenger.Default.Register<UserMessage>(this, (r, message) =>
            //{

            //    UserDetails = message._user;
            //});
        }

        public void Receive(UserMessage message)
        {
            UserDetails = message.User;
        }
    }
}
