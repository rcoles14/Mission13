using Microsoft.AspNetCore.Mvc;
using Mission13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Components
{
    public class TeamsViewComponent : ViewComponent
    {
        private iBowlersRepository repo { get; set; }

        public TeamsViewComponent (iBowlersRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCat = RouteData?.Values["team"];
            var teams = repo.Teams.Select(x => x.TeamName).OrderBy(x => x);
            return View(teams);
        }
    }
}
