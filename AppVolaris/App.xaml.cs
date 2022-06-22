using AppVolaris.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppVolaris
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new ListFlightsPage();
            NavigationPage nav = new NavigationPage(new ListFlightsPage());
            nav.BarBackgroundColor = (Color)App.Current.Resources["BackgroundColor"];
            nav.BarTextColor = (Color)App.Current.Resources["BarTextColor"];
            MainPage = nav;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
