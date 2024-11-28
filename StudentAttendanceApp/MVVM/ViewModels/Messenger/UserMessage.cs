using CommunityToolkit.Mvvm.Messaging.Messages;
using StudentAttendanceApp.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceApp.MVVM.ViewModels.Messenger;

public class UserMessage : ValueChangedMessage<UserModel>
{
    public UserMessage(UserModel value) : base(value)
    {
    }
}
