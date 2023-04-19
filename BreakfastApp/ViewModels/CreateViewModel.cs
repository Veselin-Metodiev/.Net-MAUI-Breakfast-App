using BreakfastApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BreakfastApp.ViewModels
{
    public partial class CreateViewModel : ObservableObject
    {
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

        public CreateViewModel(BreakfastRepository database)
        {
            this.database = database;
        }

        [RelayCommand]
        public async void Create()
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

            BreakfastDto breakfast = new()
            {
                Name = Name,
                Description = Description,
                ImageUri = ImageUri,
                Savory = Savory,
                Sweet = Sweet
            };

            database.Create(breakfast);
            ResetUserInput();

            await Application.Current!.MainPage!.Navigation.PopAsync();
        }

        private void ResetUserInput()
        {
            Name = String.Empty;
            ImageUri = String.Empty;
            Description = String.Empty;
            Sweet = String.Empty;
            Savory = String.Empty;
        }
    }
}
