namespace BreakfastApp;

public partial class App : Application
{
	public App (BreakfastDatabase breakfastDatabase)
	{
		InitializeComponent();

		MainPage = new AppShell();
    }
}
