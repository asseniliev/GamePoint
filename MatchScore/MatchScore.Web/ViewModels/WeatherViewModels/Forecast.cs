using System;
using System.Collections.Generic;

namespace MatchScore.Web.ViewModels.WeatherViewModels
{
    public class Forecast
    {
        public List<DailyWeatherVM> Weather { get; set; } = new List<DailyWeatherVM>();

        public HourlyWeatherVM CurrentWeather { get; set; }
    }
}

