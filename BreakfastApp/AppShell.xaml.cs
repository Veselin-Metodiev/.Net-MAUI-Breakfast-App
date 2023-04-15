namespace BreakfastApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(CreatePage), typeof(CreatePage));
	}
}
