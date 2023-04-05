using MatchScore.Data.Constants;
using MatchScore.Web.ViewModels.WeatherViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MatchScore.Web.Helpers
{
    public static class WeatherHelper
    {
        public static async Task RunAsync(HttpClient client, string latitude, string longitude, List<HourlyWeatherVM> forecast)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, string.Format(APIKeys.WeatherRequestURL, latitude, longitude, APIKeys.WeatherApiKey));

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode(); // Throw an exception if error

            var body = await response.Content.ReadAsStringAsync();
            dynamic weather = JsonConvert.DeserializeObject(body);

            foreach (var day in weather.list)
            {
                var hourlyForecast = new HourlyWeatherVM();

                //Parsing Unix string to DateTime
                string dateString = day.dt;
                DateTime date = UnixTimeStampToDateTime(double.Parse(dateString));
                hourlyForecast.Time = date;

                //Parsing string to double and rounding number
                string maxTemp = day.main.temp;
                hourlyForecast.Temp = Convert.ToInt32(Math.Round(double.Parse(maxTemp), MidpointRounding.AwayFromZero));

                hourlyForecast.Weather = day.weather[0].main;

                hourlyForecast.Icon = day.weather[0].icon;

                hourlyForecast.Humidity = day.main.humidity;

                hourlyForecast.Wind = day.wind.speed;

                forecast.Add(hourlyForecast);
            }
        }

        //Special method for converting Unix Time Stamp to DateTime object
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }

        public static List<DailyWeatherVM> GenerateDailyForecasts(List<HourlyWeatherVM> forecast)
        {
            var startDate = forecast[0].Time.Date;

            var result = new List<DailyWeatherVM>();

            for (int i = 0; i < 5; i++)
            {
                var day = new DailyWeatherVM();
                day.Time = startDate.AddDays(i);

                var hours = forecast.Where(w => w.Time.Date == day.Time).ToList();

                day.MinTemp = hours.Min(h => h.Temp);
                day.MaxTemp = hours.Max(h => h.Temp);

                day.Weather = hours
                    .Where(f => f.Weather.ToLower() != "clouds")
                    .GroupBy(f => f.Weather)
                    .OrderByDescending(grp => grp.Count())
                    .Select(grp => grp.Key)
                    .FirstOrDefault();

                if (string.IsNullOrEmpty(day.Weather))
                {
                    day.Weather = "Clouds";
                    day.Icon = "04";
                    result.Add(day);
                    continue;
                }
                day.Icon = hours
                    .Where(f => f.Weather.ToLower() != "clouds")
                    .GroupBy(f => f.Icon)
                    .OrderByDescending(grp => grp.Count())
                    .Select(grp => grp.Key)
                    .First().Substring(0,2);
                result.Add(day);
            }

            return result;
        }
    }
}

