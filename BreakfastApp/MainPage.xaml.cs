using BreakfastApp.ViewModels;

namespace BreakfastApp;

public partial class MainPage : ContentPage
{
    private MainViewModel vm;

    public MainPage(MainViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        this.vm = vm;
    }

    protected override void OnAppearing()
    {
        vm.LoadBreakfast();
    }
}