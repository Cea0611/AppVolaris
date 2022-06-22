using AppVolaris.Models;
using AppVolaris.Services;
using AppVolaris.Views;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppVolaris.ViewModels
{
    public class DetailFlightViewModel : BaseViewModel
    {
        private Command _CancelCommand;
        public Command CancelCommand => _CancelCommand ?? (_CancelCommand = new Command(CancelAction));

        private Command _SaveCommand;
        //public Command SaveCommand => _SaveCommand ?? (_SaveCommand = new Command(SaveAction));

        private Command _DeleteCommand;
       // public Command DeleteCommand => _DeleteCommand ?? (_DeleteCommand = new Command(DeleteAction));

        private Command _TakePictureCommand;
        public Command TakePictureCommand => _TakePictureCommand ?? (_TakePictureCommand = new Command(TakePictureAction));

        private Command _SelectPictureCommand;
        public Command SelectPictureCommand => _SelectPictureCommand ?? (_SelectPictureCommand = new Command(SelectPictureAction));

        private Command _MapCommand;
        public Command MapCommand => _MapCommand ?? (_MapCommand = new Command(MapAction));

        Command _GetLocationCommand;
        public Command GetLocationCommand => _GetLocationCommand ?? (_GetLocationCommand = new Command(GetLocationAction));

        private double _latitude;
        public double Latitude
        {
            get => _latitude;
            set => SetProperty(ref _latitude, value);
        }

        private double _longitude;
        public double Longitude
        {
            get => _longitude;
            set => SetProperty(ref _longitude, value);
        }

        private FlightModel _TaskSelected;
        public FlightModel TaskSelected
        {
            get => _TaskSelected;
            set => SetProperty(ref _TaskSelected, value);
        }

        private string _Picture;
        public string Picture
        {
            get => _Picture;
            set => SetProperty(ref _Picture, value);
        }

        public DetailFlightViewModel()
        {
            TaskSelected = new FlightModel();
        }

        public DetailFlightViewModel(FlightModel taskSelected)
        {
            TaskSelected = taskSelected;
            Picture = taskSelected.ImageBase64;
        }

        //Cancelar
        private async void CancelAction()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        //Mapa
        private async void MapAction()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new MapsPage());
        }

        //Camara y galeria
        private async void TakePictureAction()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "AppVolaris",
                Name = "cam_picture.jpg"
            });

            if (file == null) return;

            Picture = TaskSelected.ImageBase64 = await new ImageService().ConvertImageFileToBase64(file.Path);


        }

        private async void SelectPictureAction()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("No Pick Photo", ":( No pick photo available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
            });

            if (file == null) return;

            Picture = TaskSelected.ImageBase64 = await new ImageService().ConvertImageFileToBase64(file.Path);  //file.Path;


        }

        private async void GetLocationAction()
        {
            try
            {
                var location = await Geolocation.GetLocationAsync(); //GetLastKnownLocationAsync();
                if (location != null)
                {
                    Latitude = location.Latitude;
                    Longitude = location.Longitude;

                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("AppVolaris", "No se pudo obtener la ubicación", "Ok");
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }
    }
}
