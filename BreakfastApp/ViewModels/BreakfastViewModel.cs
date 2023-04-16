using BreakfastApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BreakfastApp.ViewModels
{
    public partial class BreakfastViewModel : ObservableObject
    {
        [ObservableProperty]
        private static List<Breakfast> breakfasts;

        [ObservableProperty]
        private static bool isRefreshing;

        BreakfastRepository database;

        public BreakfastViewModel()
        {
            this.database = new BreakfastRepository();

            InitialItemsLoad();
            LoadBreakfast();
        }

        public void InitialItemsLoad()
        {
            database.Create(new BreakfastDto
            {
                Name = "Vegan Sunshine",
                Description = "Vegan everthing! Join us for a healthy breakfast full of vegan dishes and Cookies",
                Image = "https://images.unsplash.com/photo-1659984716295-c3d4be94dc4f?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=327&q=80",
                Savory = "Oatmeal, Avocado toast, Omelet, Salad",
                Sweet = "Cookie"
            });

            database.Create(new BreakfastDto
            {
                Name = "Breakfast @ Tiffany's",
                Description = "Hi, I'm Tiffany's ",
                Image = "https://images.unsplash.com/photo-1620921575116-fb8902865f81?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=435&q=80",
                Savory = "Sandwich, Salad, Omelet",
                Sweet = "Pancake, Waffle"
            });
        }

        public void LoadBreakfast()
        {
            Breakfasts = new List<Breakfast>();
            List<BreakfastDto> breakfastDtos = database.List();

            foreach (BreakfastDto breakfastDto in breakfastDtos)
            {
                Breakfast breakfast = new()
                {
                    Name = breakfastDto.Name,
                    Description = breakfastDto.Description,
                    Image = new Uri(breakfastDto.Image, UriKind.RelativeOrAbsolute),
                    Savory = breakfastDto.Savory.Split(", ").ToList(),
                    Sweet = breakfastDto.Sweet.Split(", ").ToList()
                };

                Breakfasts.Add(breakfast);
            }

        }

        public void ReloadBreakfast()
        {
            Breakfasts.Clear();
            List<BreakfastDto> breakfastDtos = database.List();

            foreach (BreakfastDto breakfastDto in breakfastDtos)
            {
                Breakfast breakfast = new()
                {
                    Name = breakfastDto.Name,
                    Description = breakfastDto.Description,
                    Image = new Uri(breakfastDto.Image, UriKind.RelativeOrAbsolute),
                    Savory = breakfastDto.Savory.Split(", ").ToList(),
                    Sweet = breakfastDto.Sweet.Split(", ").ToList()
                };

                Breakfasts.Add(breakfast);
            }
        }

        [RelayCommand]
        void Refresh()
        {
            ReloadBreakfast();
            IsRefreshing = false;
        }

        [RelayCommand]
        private async Task GoToCreate() =>
            await Application.Current!.MainPage!.Navigation.PushAsync(new CreatePage(new CreateViewModel(database)));
    }
}