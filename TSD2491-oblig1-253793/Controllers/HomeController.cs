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
            // Retrieve the player's name from the session
            _matchingGameModel.PlayerName = HttpContext.Session.GetString("PlayerName");

            if (_matchingGameModel.PlayerName != null)
            {
                // Retrieve the game count from the static dictionary using the player's name
                _matchingGameModel.GamesPlayed = MatchingGameModel.GetGamesPlayed(_matchingGameModel.PlayerName);
            }

            return View(_matchingGameModel);
        }


        [HttpPost]
        public IActionResult ButtonClick(string animal, string description)
        {


            _matchingGameModel.ButtonClick(animal, description);

            return View("Index", _matchingGameModel);
        }

        [HttpPost]
        public IActionResult RegisterPlayer(MatchingGameModel model)
        {
            // Save the player's name to the session
            HttpContext.Session.SetString("PlayerName", model.PlayerName);

            // Set the PlayerName in the model
            _matchingGameModel.PlayerName = model.PlayerName;

            // Initialize games played count for new players
            if (_matchingGameModel.GamesPlayed == 0) // Check if the player is new
            {
                _matchingGameModel.GamesPlayed = MatchingGameModel.GetGamesPlayed(_matchingGameModel.PlayerName);
            }

            // Redirect back to the game page
            return RedirectToAction("Index");
        }


    }
}