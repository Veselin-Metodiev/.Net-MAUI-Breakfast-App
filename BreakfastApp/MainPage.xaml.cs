using BreakfastApp.ViewModels;

namespace BreakfastApp;

public partial class MainPage : ContentPage
{
    public MainPage(BreakfastViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}