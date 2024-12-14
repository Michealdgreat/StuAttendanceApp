using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentAttendanceApp.MVVM.Models;
using StudentAttendanceApp.MVVM.ViewModels.Base;
using StudentAttendanceApp.Services;
using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace StudentAttendanceApp.MVVM.ViewModels
{
    public partial class ManageSessionViewModel : BaseViewModel
    {
        private readonly GetService _getService;
        private readonly ITokenService _tokenService;

        [ObservableProperty]
        private ObservableCollection<SessionModel> sessions;

        public ManageSessionViewModel(GetService getService, ITokenService tokenService)
        {
            Sessions = new ObservableCollection<SessionModel>();
            _getService = getService;
            _tokenService = tokenService;
        }

        [RelayCommand]
        public async Task FetchSessionsAsync()
        {
            try
            {
                var userTokenDetails = await _tokenService.GetUserDetailsFromToken();

                var sessionsList = await _getService.GetList<SessionModel, dynamic>(userTokenDetails.UserId, EndPoints.GetAllSessions);
                if (sessionsList != null)
                {
                    Sessions = sessionsList;
                }
            }
            catch (Exception)
            {


            }
        }
    }
}