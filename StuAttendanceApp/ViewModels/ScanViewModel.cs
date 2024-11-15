using System.Text;
using System.Threading.Tasks;
using Plugin.NFC;

namespace StuAttendanceApp.ViewModels
{
    public partial class ScanViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string? rfidTag;

        public async Task StartListening()
        {
            if (!CrossNFC.IsSupported)
            {
                await Shell.Current.DisplayAlert("Error", "NFC not supported on this device", "Okay");

                return;
            }

            if (!CrossNFC.Current.IsEnabled)
            {
                await Shell.Current.DisplayAlert("Error", "Please enable NFC In settings", "Try again");
                return;
            }

            CrossNFC.Current.OnMessageReceived += Current_OnMessageReceived;
            CrossNFC.Current.StartListening();
        }

        public Task StopListening()
        {
            CrossNFC.Current.StopListening();
            CrossNFC.Current.OnMessageReceived -= Current_OnMessageReceived;
            return Task.CompletedTask;
        }

        private async void Current_OnMessageReceived(ITagInfo tagInfo)
        {
            if (tagInfo == null || tagInfo.IsEmpty)
            {
                await Shell.Current.DisplayAlert("Error", "No NFC tag found or the tag is empty.", "Try again");
                return;
            }

            var firstRecord = tagInfo.Records.FirstOrDefault();
            if (firstRecord != null)
            {
                RfidTag = Encoding.UTF8.GetString(firstRecord.Payload);
            }
        }



    }
}