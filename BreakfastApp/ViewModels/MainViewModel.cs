﻿using BreakfastApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BreakfastApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private List<Breakfast> breakfasts;

        [ObservableProperty]
        private bool isRefreshing;

        private readonly BreakfastRepository database;

        public MainViewModel()
        {
            database = new BreakfastRepository();

            if (database.GetAllItems().Count == 0)
            {
                InitialItemsLoad();
            }

            LoadBreakfast();
        }

        private void InitialItemsLoad()
        {
            database.Create(new BreakfastDto
            {
                Name = "Vegan Sunshine",
                Description = "Vegan everthing! Join us for a healthy breakfast full of vegan dishes and Cookies",
                ImageUri = "https://images.unsplash.com/photo-1659984716295-c3d4be94dc4f?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=327&q=80",
                Savory = "Oatmeal, Avocado toast, Omelet, Salad",
                Sweet = "Cookie"
            });

            database.Create(new BreakfastDto
            {
                Name = "Breakfast @ Tiffany's",
                Description = "Hi, I'm Tiffany's ",
                ImageUri = "https://images.unsplash.com/photo-1620921575116-fb8902865f81?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=435&q=80",
                Savory = "Sandwich, Salad, Omelet",
                Sweet = "Pancake, Waffle"
            });
        }

        public void LoadBreakfast()
        {
            Breakfasts = new List<Breakfast>();
            List<BreakfastDto> breakfastDtos = database.GetAllItems();

            foreach (BreakfastDto breakfastDto in breakfastDtos)
            {
                Breakfast breakfast = new()
                {
                    Id = breakfastDto.Id,
                    Name = breakfastDto.Name,
                    Description = breakfastDto.Description,
                    Image = new Uri(breakfastDto.ImageUri, UriKind.RelativeOrAbsolute),
                    Savory = !string.IsNullOrWhiteSpace(breakfastDto.Savory) ? 
                        breakfastDto.Savory.Split(", ").ToList() : 
                        new List<string>(),
                    Sweet = !string.IsNullOrWhiteSpace(breakfastDto.Sweet) ? 
                        breakfastDto.Sweet.Split(", ").ToList() : 
                        new List<string>(),
                };

                Breakfasts.Add(breakfast);
            }

        }

        [RelayCommand]
        private void Refresh()
        {
            LoadBreakfast();
            IsRefreshing = false;
        }

        [RelayCommand]
        private void Delete(int id)
        {
            database.Delete(id);
            LoadBreakfast();
        }

        [RelayCommand]
        private async Task GoToUpdate(int id) =>
            await Application.Current!.MainPage!.Navigation
                .PushAsync(new UpdatePage(new UpdateViewModel(id, database)));
        

        [RelayCommand]
        private async Task GoToCreate() =>
            await Application.Current!.MainPage!.Navigation
                .PushAsync(new CreatePage(new CreateViewModel(database)));
    }
}