using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TSD2491_oblig1_253793.Models;

namespace TSD2491_oblig1_253793.Controllers
{
    public class HomeController : Controller
    {
        private readonly static MatchingGameModel _matchingGameModel = new MatchingGameModel();

        public HomeController()
        {

        }

        public IActionResult Index()
        {
            return View(_matchingGameModel);
        }

        [HttpPost]
        public IActionResult ButtonClick(string animal, string description)
        {


            _matchingGameModel.ButtonClick(animal, description);

            return View("Index", _matchingGameModel);
        }
    }
}
