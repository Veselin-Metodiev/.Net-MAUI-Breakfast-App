using BreakfastApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BreakfastApp.ViewModels
{
    public partial class UpdateViewModel : ObservableObject
    {
        private int id;

        [ObservableProperty]
        static string name;

        [ObservableProperty]
        static string imageUri;

        [ObservableProperty]
        static string description;

        [ObservableProperty]
        static string savory;

        [ObservableProperty]
        static string sweet;

        private BreakfastRepository database;

        public UpdateViewModel(int id, BreakfastRepository database)
        {
            this.id = id;
            this.database = database;

            DisplayItem();
        }

        private void DisplayItem()
        {
            BreakfastDto breakfastDto = database.GetItem(id);

            Name = breakfastDto.Name;
            Description = breakfastDto.Description;
            ImageUri = breakfastDto.ImageUri;
            Savory = breakfastDto.Savory;
            Sweet = breakfastDto.Sweet;
        }

        [RelayCommand]
        private void Update()
        {
            BreakfastDto breakfastDto = new()
            {
                Id = id,
                Name = Name,
                Description = Description,
                ImageUri = ImageUri,
                Savory = Savory,
                Sweet = Sweet
            };

            database.Update(breakfastDto);

            Application.Current!.MainPage!.Navigation.PopAsync();
        }
    }
}
