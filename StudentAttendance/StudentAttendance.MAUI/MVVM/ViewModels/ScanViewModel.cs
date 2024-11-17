using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentAttendance.MAUI.Interfaces;
using StudentAttendance.MAUI.MVVM.ViewModels.Base;
using System.ComponentModel;
using System.Text;

namespace StudentAttendance.MAUI.MVVM.ViewModels
{
    public partial class ScanViewModel : BaseViewModel
    {

        [ObservableProperty]
        private string rfidTag;

        private readonly INfcService nfcAdapter;

        [ObservableProperty]
        private string stringData;


        public ScanViewModel(INfcService nfcService)
        {
            this.nfcAdapter = nfcService;
            ExecuteNfc();

        }

        [RelayCommand]
        public async Task StartListening()
        {

            if (await nfcAdapter.OpenNFCSettingsAsync())
            {
                nfcAdapter.ConfigureNfcAdapter();
                nfcAdapter.EnableForegroundDispatch();
            }
        }

        [RelayCommand]
        public void StopListening()
        {

            nfcAdapter.DisableForegroundDispatch();
            nfcAdapter.UnconfigureNfcAdapter();
        }

        private Task ExecuteNfc()
        {
            byte[] bytes = Encoding.ASCII.GetBytes(StringData);
            return nfcAdapter.SendAsync(bytes);
        }
    }
}
