﻿using AppVolaris.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppVolaris.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlightDetailPage : ContentPage
    {
        public FlightDetailPage()
        {
            InitializeComponent();
            BindingContext = new DetailFlightViewModel();
        }
    }
}