using AutoMapper;
using MatchScore.Data.Enums;
using MatchScore.Data.Models;
using MatchScore.Services.Services.Contracts;
using MatchScore.Web.Helpers;
using MatchScore.Web.ViewModels.LocationViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace MatchScore.Web.Controllers
{
    public class LocationsController : Controller
    {
        #region State
        private readonly ILocationsService locationsService;
        private readonly IMapper mapper;
        private readonly IUsersService userService;

        public LocationsController(IMapper mapper, IUsersService userService, ILocationsService locationsService)
        {
            this.mapper = mapper;
            this.userService = userService;
            this.locationsService = locationsService;
        }
        #endregion


        [HttpGet]
        public IActionResult Create()
        {
            //Seed list of countries
            var countries = from Countries types in Enum.GetValues(typeof(Countries))
                            select new
                            {
                                ID = (int)types,
                                Name = this.GetEnumDescription(types)
                            };

            this.ViewData["Countries"] = new SelectList(countries, "ID", "Name");

            LocationCreateVM locationVM = new LocationCreateVM();
            return View();
        }

        [HttpPost]
        public IActionResult Create(LocationCreateVM locationVM)
        {
            List<string> coordinates = BingHelper.GetCoordinates(locationVM.Country.ToString(), locationVM.City);
            Location createdLocation = new Location();
            if (coordinates != null && coordinates.Count != 0)
            {
                Location newLocation = this.mapper.Map<Location>(locationVM);
                newLocation.Latitude = coordinates[0];
                newLocation.Longitude = coordinates[1];
                //Test User here

                //User loggedUser = this.userService.GetByUsername(User.Identity.Name);
                User user = this.userService.GetByUsername(User.Claims.FirstOrDefault(c => c.Type.Equals("Username")).Value);

                createdLocation = this.locationsService.Create(newLocation, user);
            }

            return RedirectToAction("Create", "Events", new { locationId = createdLocation.LocationId });
        }

        private string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                string desc = attributes.First().Description;
                return attributes.First().Description;
            }

            string toReturn = value.ToString();
            return value.ToString();
        }
    }
}
