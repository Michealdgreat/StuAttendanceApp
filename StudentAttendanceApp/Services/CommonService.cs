using System;
using Microsoft.Maui.Controls;

namespace StudentAttendanceApp.Services
{
    public class CommonService
    {
        public void InitializeAppShell()
        {
            // Ensure that the application has at least one window
            if (Application.Current?.Windows.Count > 0)
            {
                var currentPage = Application.Current.Windows[0].Page;
                if (currentPage is not AppShell)
                {
                    Application.Current.Windows[0].Page = new AppShell();
                }
            }
            else
            {
                // Handle the case where there are no windows, if necessary.
                // This might involve logging an error, throwing an exception,
                // or whatever's appropriate for your application's lifecycle.
                throw new InvalidOperationException("No windows available in the application.");
            }
        }
    }
}