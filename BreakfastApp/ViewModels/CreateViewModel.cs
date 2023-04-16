using BreakfastApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BreakfastApp.ViewModels
{
    public partial class CreateViewModel : ObservableObject
    {
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
                   string.IsNullOrWhiteSpace(Description) ||
                   string.IsNullOrWhiteSpace(Savory) ||
                   string.IsNullOrWhiteSpace(Sweet))
                {
                    throw new InvalidDataException();
                }

                if (!Uri.TryCreate(ImageUri, UriKind.RelativeOrAbsolute, out Uri image))
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
                }

                await Application.Current!.MainPage!.DisplayAlert(Constants.IncorrectUriTitle,
                    Constants.IncorrectUriMessage, Constants.IncorrectUriBtnText);
                return;
            }

            BreakfastDto breakfast = new()
            {
                Name = Name,
                Description = Description,
                Image = ImageUri,
                Savory = Savory,
                Sweet = Sweet
            };

            database.Create(breakfast);
            await Application.Current!.MainPage!.Navigation.PopAsync();
        }
    }
}
