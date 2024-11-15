namespace StuAttendanceApp.Views;

public partial class ScanPage : ContentPage
{
	public ScanPage(ScanViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
