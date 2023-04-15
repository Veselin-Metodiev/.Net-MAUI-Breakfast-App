using BreakfastApp.Models;
using BreakfastApp.ViewModels;
using CommunityToolkit.Mvvm.Input;

namespace BreakfastApp;

public partial class CreatePage : ContentPage
{
	public CreatePage(CreateViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}