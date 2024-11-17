using StudentAttendance.MAUI.MVVM.ViewModels;
using System;

namespace StudentAttendance.MAUI.MVVM.Views
{
    public partial class BaseContentPage : ContentPage
    {
        public BaseContentPage(BaseViewModel baseViewModel)
        {
            BindingContext = baseViewModel;
        }
    }
}

