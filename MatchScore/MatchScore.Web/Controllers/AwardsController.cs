using MatchScore.Data.Models;
using MatchScore.Web.ViewModels.EventViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchScore.Services.Services.Contracts;

namespace MatchScore.Web.Controllers
{
    public class AwardsController : Controller
    {
        private readonly IAwardsService awardsService;
        #region States
        public AwardsController(IAwardsService awardsService)
        {
            this.awardsService = awardsService;
        }
        #endregion

        [HttpPost]
        public IActionResult Edit(EventEditVM eventVM)
        {   
            foreach (var award in eventVM.Awards)
            {
                this.awardsService.Update(award);
            }
            return RedirectToAction("Edit", "Events", new { eventId = eventVM.EventId });
        }
    }
}
