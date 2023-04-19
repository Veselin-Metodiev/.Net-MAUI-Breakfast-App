using BreakfastApp.ViewModels;

namespace BreakfastApp;

public partial class UpdatePage : ContentPage
{
	public UpdatePage(UpdateViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
    }
}