using AppVolaris.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;

namespace AppVolaris.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapsPage : ContentPage
    {
        public MapsPage()
        {
            InitializeComponent();

            FlightModel flight = new FlightModel
            {
                ID = 1,
                Name = "Guadalajara",
                Picture = "",
                Date = "25-06-2022",
                Hour = "12:00 pm",
                Status = "Activo",
                Logitude = -103.39182,
                Latitude = 20.66682
            };

            MapControl.MoveToRegion(
                    MapSpan.FromCenterAndRadius(
                        new Position(
                            flight.Latitude,
                            flight.Logitude
                        ), Distance.FromMiles(.5)
                    )
                ); ;
        }
    }
}