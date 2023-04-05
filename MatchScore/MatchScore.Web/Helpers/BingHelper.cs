using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MatchScore.Web.Helpers
{
    public static class BingHelper
    {
        public static List<string> GetCoordinates(string country, string city)
        {
            string bingRestLinl = "http://dev.virtualearth.net/REST/v1/Locations";
            string cityCountryQuery = string.Format("?query={0}%20{1}", city, country);
            string includeNeighbourhood = "includeNeighborhood=0";
            string incl = "incl=queryParse,ciso2";
            string key = "key=8BbtzJvAqA5bXCzcnTcd~yrMD5WUhGOr6IAqMsIRAEw~Agt1ygXkoxFeVN50i32C8FRDbd19RAng3vvcPi8Ti9u2vf_FSgjWPzl8QwzDxAqL";

            string queryString = $"{bingRestLinl}{cityCountryQuery}&{includeNeighbourhood}&{incl}&{key}";

            Console.WriteLine(queryString);

            List<string> coordinates = new List<string>();

            RunAsync(queryString, coordinates).GetAwaiter().GetResult();

            return coordinates;
        }

        private static async Task RunAsync(string queryString, List<string> coordinates)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, queryString);

            var response = await Program.Client.SendAsync(request);
            response.EnsureSuccessStatusCode(); // Throw an exception if error

            var json = await response.Content.ReadAsStringAsync();

            dynamic dynamicRoot = JsonConvert.DeserializeObject(json);

            foreach (var rs in dynamicRoot.resourceSets)
            {
                bool pointFound = false;
                foreach (var r in rs.resources)
                {
                    if (r.confidence == "High")
                    {
                        coordinates.Add((string)r.point.coordinates[0]);
                        coordinates.Add((string)r.point.coordinates[1]);
                        pointFound = true;
                        break;
                    }
                    else if (r.confidence == "Medium")
                    {
                        coordinates.Add(r.point.coordinates[0]);
                        coordinates.Add(r.point.coordinates[1]);
                        pointFound = true;
                        break;
                    }
                }
                if (pointFound) break;
            }
        }
    }
}
