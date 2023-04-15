using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BreakfastApp.ViewModels
{
    public partial class CreateViewModel : ObservableObject
    {
        [RelayCommand]
        public static async Task Create() =>
            await Shell.Current.GoToAsync("..", true);
    }
}
