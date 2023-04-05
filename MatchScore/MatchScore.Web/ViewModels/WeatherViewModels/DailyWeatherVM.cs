using System;
namespace MatchScore.Web.ViewModels.WeatherViewModels
{
    public class DailyWeatherVM
    {
        public DateTime Time { get; set; }

        public int MinTemp { get; set; }

        public int MaxTemp { get; set; }

        public string Weather { get; set; }

        public string Icon { get; set; }
    }
}

