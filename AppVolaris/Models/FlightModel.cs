using System;
using System.Collections.Generic;
using System.Text;

namespace AppVolaris.Models
{
    public class FlightModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string Date { get; set; }
        public string Hour { get; set; }
        public string Status { get; set; }
        public double Logitude { get; set; }
        public double Latitude { get; set; }

        public string ImageBase64 { get; set; }

    }
}
