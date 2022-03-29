using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission13.Models;
using Mission13.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Controllers
{
    public class HomeController : Controller
    {
        private iBowlersRepository _repo { get; set; }

        public HomeController(iBowlersRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index(string selectedTeam)

        {
            ViewBag.Selected = selectedTeam;
            
            var blah = new BowlersViewModel
            {
                Bowlers = _repo.Bowlers.Include(t => t.Team)
                .Where(t => t.Team.TeamName == selectedTeam || selectedTeam == null)
                .OrderBy(t => t.Team.TeamName)
            };

            return View(blah);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.TeamsList = _repo.Teams.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Add(Bowler b)
        {
                _repo.Add(b);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.TeamsList = _repo.Teams.ToList();
            var bowler = _repo.Bowlers.Single(x => x.BowlerID == id);
            return View("Add", bowler);
        }
        [HttpPost]
        public IActionResult Edit(Bowler b)
        {
            _repo.Update(b);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var bowler = _repo.Bowlers.Single(x => x.BowlerID == id);
            return View("Delete", bowler);
        }
        [HttpPost]
        public IActionResult Delete(Bowler b)
        {
            _repo.Delete(b);
            return RedirectToAction("Index");
        }
    }
}
