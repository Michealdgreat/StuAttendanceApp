using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Plugin.NFC;
using StudentAttendanceApp.MVVM.ViewModels.Base;
using System.Text;

namespace StudentAttendanceApp.MVVM.ViewModels
{
    public partial class ScanViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string? rfidTag;

        [ObservableProperty]
        private bool isListening;

        private bool eventsSubscribed;

        public ScanViewModel()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            // Unsubscribe first to prevent multiple subscriptions
            UnsubscribeEvents();

            try
            {
                // Verify CrossNFC is supported and available
                if (!CrossNFC.IsSupported)
                {
                    System.Diagnostics.Debug.WriteLine("NFC: Not supported on this device");
                    return;
                }

                if (!CrossNFC.Current.IsAvailable)
                {
                    System.Diagnostics.Debug.WriteLine("NFC: Not available");
                    return;
                }

                // Explicit null checks
                if (CrossNFC.Current == null)
                {
                    System.Diagnostics.Debug.WriteLine("NFC: CrossNFC.Current is null");
                    return;
                }

                // Add comprehensive event subscriptions
                CrossNFC.Current.OnMessageReceived += Current_OnMessageReceived;
                CrossNFC.Current.OnTagDiscovered += Current_OnTagDiscovered;
                CrossNFC.Current.OnTagListeningStatusChanged += Current_OnTagListeningStatusChanged;
                CrossNFC.Current.OnNfcStatusChanged += Current_OnNfcStatusChanged;

                eventsSubscribed = true;
                System.Diagnostics.Debug.WriteLine("NFC: Events subscribed successfully");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"NFC: Event subscription error - {ex}");
            }
        }

        private void UnsubscribeEvents()
        {
            try
            {
                if (CrossNFC.Current == null) return;

                CrossNFC.Current.OnMessageReceived -= Current_OnMessageReceived;
                CrossNFC.Current.OnTagDiscovered -= Current_OnTagDiscovered;
                CrossNFC.Current.OnTagListeningStatusChanged -= Current_OnTagListeningStatusChanged;
                CrossNFC.Current.OnNfcStatusChanged -= Current_OnNfcStatusChanged;

                eventsSubscribed = false;
                System.Diagnostics.Debug.WriteLine("NFC: Events unsubscribed successfully");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"NFC: Event unsubscription error - {ex}");
            }
        }

        private void Current_OnTagListeningStatusChanged(bool isListening)
        {
            IsListening = isListening;
            System.Diagnostics.Debug.WriteLine($"NFC: Listening Status Changed - {isListening}");
        }

        private void Current_OnNfcStatusChanged(bool isEnabled)
        {
            System.Diagnostics.Debug.WriteLine($"NFC: Status Changed - {isEnabled}");
        }

        private void Current_OnTagDiscovered(ITagInfo tagInfo, bool format)
        {
            System.Diagnostics.Debug.WriteLine("NFC: Tag Discovered Event");
            System.Diagnostics.Debug.WriteLine($"NFC: Tag Info Null: {tagInfo == null}");

            if (tagInfo != null)
            {
                System.Diagnostics.Debug.WriteLine($"NFC: Tag Records Count: {tagInfo.Records?.Length ?? 0}");
            }
        }

        [RelayCommand]
        public async Task StartListening()
        {
            try
            {
                if (!CrossNFC.IsSupported)
                {
                    System.Diagnostics.Debug.WriteLine("NFC: Not supported on this device");
                    await Shell.Current.DisplayAlert("Error", "NFC not supported on this device", "OK");
                    return;
                }

                if (!CrossNFC.Current.IsAvailable)
                {
                    System.Diagnostics.Debug.WriteLine("NFC: Not available");
                    await Shell.Current.DisplayAlert("Error", "NFC is not available", "OK");
                    return;
                }

                if (!CrossNFC.Current.IsEnabled)
                {
                    System.Diagnostics.Debug.WriteLine("NFC: Not enabled");
                    await Shell.Current.DisplayAlert("Error", "Please enable NFC in settings", "OK");
                    return;
                }

                // Ensure events are subscribed
                SubscribeEvents();

                // Start listening with additional logging
                System.Diagnostics.Debug.WriteLine("NFC: Starting to listen");
                CrossNFC.Current.StartListening();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"NFC: Start listening error - {ex}");
                await Shell.Current.DisplayAlert("Error", $"Error starting NFC listening: {ex.Message}", "OK");
            }
        }

        [RelayCommand]
        public async Task StopListening()
        {
            try
            {
                CrossNFC.Current.StopListening();
                System.Diagnostics.Debug.WriteLine("NFC: Stopped listening");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"NFC: Stop listening error - {ex}");
                await Shell.Current.DisplayAlert("Error", $"Error stopping NFC listening: {ex.Message}", "OK");
            }
        }

        private async void Current_OnMessageReceived(ITagInfo tagInfo)
        {
            // Comprehensive logging and debugging
            System.Diagnostics.Debug.WriteLine("NFC: Message Received Event Triggered");

            if (tagInfo == null)
            {
                System.Diagnostics.Debug.WriteLine("NFC: TagInfo is null");
                await Shell.Current.DisplayAlert("Error", "No tag found", "OK");
                return;
            }

            // Additional detailed logging
            System.Diagnostics.Debug.WriteLine($"NFC: Tag Supported: {tagInfo.IsSupported}");
            System.Diagnostics.Debug.WriteLine($"NFC: Tag Empty: {tagInfo.IsEmpty}");
            System.Diagnostics.Debug.WriteLine($"NFC: Tag Identifier: {BitConverter.ToString(tagInfo.Identifier ?? new byte[0])}");

            if (tagInfo.IsEmpty)
            {
                System.Diagnostics.Debug.WriteLine("NFC: Tag is empty");
                await Shell.Current.DisplayAlert("Error", "Empty tag", "OK");
                return;
            }

            // Check if Records collection is null or empty
            if (tagInfo.Records == null || !tagInfo.Records.Any())
            {
                System.Diagnostics.Debug.WriteLine("NFC: No records found in tag");
                await Shell.Current.DisplayAlert("Error", "No records found on tag", "OK");
                return;
            }

            try
            {
                // Process all records, not just the first one
                foreach (var record in tagInfo.Records)
                {
                    if (record == null) continue;

                    System.Diagnostics.Debug.WriteLine($"NFC: Record Type Format: {record.TypeFormat}");
                    System.Diagnostics.Debug.WriteLine($"NFC: Record Mime Type: {record.MimeType ?? "N/A"}");

                    // More robust message extraction
                    string message = ExtractRecordMessage(record);

                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        System.Diagnostics.Debug.WriteLine($"NFC: Extracted Message: {message}");
                        RfidTag = message;

                        // Optional: Stop after first valid message
                        await StopListening();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"NFC: Error processing tag - {ex}");
                await Shell.Current.DisplayAlert("Error", $"Error reading tag: {ex.Message}", "OK");
            }
        }

        private string ExtractRecordMessage(NFCNdefRecord record)
        {
            try
            {
                if (record?.Payload == null)
                {
                    System.Diagnostics.Debug.WriteLine("NFC: Record payload is null");
                    return string.Empty;
                }

                // Try multiple encoding methods
                try
                {
                    // UTF-8 decoding (most common)
                    return Encoding.UTF8.GetString(record.Payload);
                }
                catch
                {
                    try
                    {
                        // Fallback to ASCII
                        return Encoding.ASCII.GetString(record.Payload);
                    }
                    catch
                    {
                        // Hex representation as last resort
                        return BitConverter.ToString(record.Payload);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"NFC: Message extraction error - {ex}");
                return string.Empty;
            }
        }

        // Implement IDisposable or use a destructor to unsubscribe from events
        public void Dispose()
        {
            UnsubscribeEvents();
        }
    }
}