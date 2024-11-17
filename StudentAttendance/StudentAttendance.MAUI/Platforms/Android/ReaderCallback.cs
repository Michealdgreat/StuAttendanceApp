using Android.Nfc;

namespace StudentAttendance.MAUI
{
    public class ReaderCallback : Java.Lang.Object, NfcAdapter.IReaderCallback
    {
        public TaskCompletionSource<Tag> NFCTag { get; set; }

        public void OnTagDiscovered(Tag tag)
        {
            var isSuccess = NFCTag?.TrySetResult(tag);
            if (null == NFCTag || !isSuccess.Value)
                Platforms.NfcService.DetectedTag = tag;
        }
    }
}

