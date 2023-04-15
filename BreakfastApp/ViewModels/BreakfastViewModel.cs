using BreakfastApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BreakfastApp.ViewModels
{
    [QueryProperty(nameof(Breakfast), nameof(Breakfast))]
    public partial class BreakfastViewModel : ObservableObject
    {
        [ObservableProperty]
        List<Breakfast> breakfasts;

        [ObservableProperty]
        Breakfast breakfast;

        public BreakfastViewModel()
        {
            LoadBreakfast();
        }

        private void LoadBreakfast()
        {
            Breakfasts = new()
            {
                new Breakfast
                {
                    Name = "Vegan Sunshine",
                    Description = "Vegan everthing! Join us for a healthy breakfas full of vegan dishes and Cookies",
                    Image = new Uri("https://images.unsplash.com/photo-1659984716295-c3d4be94dc4f?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=327&q=80"),
                    Savory = new List<string> { "Oatmeal", "Advocado toast", "Omelet", "Salad" },
                    Sweet = new List<string> { "Cookie" }

                },
                new Breakfast
                {
                    Name = "Breakfast @ Tiffany's",
                    Description = "Hi, I'm Tiffany's ",
                    Image = new Uri("https://images.unsplash.com/photo-1620921575116-fb8902865f81?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=435&q=80"),
                    Savory = new List<string> { "Sandwich", "Salad", "Omelet" },
                    Sweet = new List<string> { "Pancake", "Waffle" }
                }
            };
        }

        [RelayCommand]
        private async Task GoToCreate() => 
            await Shell.Current.GoToAsync(nameof(CreatePage));
    }
}
