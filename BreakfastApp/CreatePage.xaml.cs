using BreakfastApp.ViewModels;

namespace BreakfastApp;

public partial class CreatePage : ContentPage
{
	public CreatePage(CreateViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}