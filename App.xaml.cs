namespace TaskEvents;

public partial class App : Application
{
	public App(IJob job)
	{
		InitializeComponent();
		job.Start();

		MainPage = new AppShell();
	}
}

