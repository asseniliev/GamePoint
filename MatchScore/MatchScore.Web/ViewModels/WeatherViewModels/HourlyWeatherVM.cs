using System;
namespace MatchScore.Web.ViewModels.WeatherViewModels
{
    public class HourlyWeatherVM
    {
        public DateTime Time { get; set; }

        public int Temp { get; set; }

        public string Weather { get; set; }

        public string Icon { get; set; }

        //%
        public string Humidity { get; set; }

        //(m/s)
        public string Wind { get; set; }
    }
}

