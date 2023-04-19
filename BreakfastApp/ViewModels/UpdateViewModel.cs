using BreakfastApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BreakfastApp.ViewModels
{
    public partial class UpdateViewModel : ObservableObject
    {
        private readonly int id;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string imageUri;

        [ObservableProperty]
        private string description;

        [ObservableProperty]
        private string savory;

        [ObservableProperty]
        private string sweet;

        private readonly BreakfastRepository database;

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
        private async void Update()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Name) ||
                    string.IsNullOrWhiteSpace(Description))
                {
                    throw new InvalidDataException();
                }

                if (!Uri.IsWellFormedUriString(ImageUri, UriKind.Absolute))
                {
                    throw new UriFormatException();
                }
            }
            catch (Exception ex)
            {
                if (ex is InvalidDataException)
                {
                    await Application.Current!.MainPage!.DisplayAlert(Constants.IncorrectDataTitle,
                        Constants.IncorrectDataMessage, Constants.IncorrectDataBtnText);
                    return;
                }

                await Application.Current!.MainPage!.DisplayAlert(Constants.IncorrectUriTitle,
                    Constants.IncorrectUriMessage, Constants.IncorrectUriBtnText);
                return;
            }

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

            await Application.Current!.MainPage!.Navigation.PopAsync();
        }
    }
}
