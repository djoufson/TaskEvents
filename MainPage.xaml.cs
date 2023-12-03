namespace TaskEvents;

public partial class MainPage : ContentPage
{
	public MainPage(ViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
}
