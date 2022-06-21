using AppVolaris.Models;
using AppVolaris.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppVolaris.ViewModels
{
    public class ListFlightsViewModel : BaseViewModel
    {

        private List<FlightModel> _ListFlights;
        public List<FlightModel> ListFlights
        {
            get => _ListFlights;
            set => SetProperty(ref _ListFlights, value);
        }

        private FlightModel _SelectedFlight;
        public FlightModel SelectedFlight
        {
            get => _SelectedFlight;
            set => SetProperty(ref _SelectedFlight, value);
        }

        public ListFlightsViewModel()
        {
            LoadFlights();
        }

        private async void LoadFlights()
        {
            IsBusy = true;
            ListFlights = null;
            ApiResponse response = await new ApiService().GetDataAsync("Flights");
            if(response == null || !response.IsSuccess)
            {
                IsBusy = false;
                await Application.Current.MainPage.DisplayAlert("AppVolaris", $"Error al cargar los vuelos: {response.Message}", "ok");
                return;
            }
            ListFlights = JsonConvert.DeserializeObject<List<FlightModel>>(response.Result.ToString());
            IsBusy = false;
        }
    }
}
