using APILab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace APILab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        private CardsDAL cardsDAL = new CardsDAL();
        private string deckID = "bp6k8j3xktqs";

        public IActionResult DeckOfCards()
        {
            CardsModel result = cardsDAL.GetData(deckID);
            if (result.remaining < 5)
            { 
                result = cardsDAL.ShuffleDeck(deckID);
                result = cardsDAL.GetData(deckID);
            }
            return View(result);
        }

        /*public IActionResult SaveCards(bool keepCards, string code)
        {
            if 
            CardsModel result = cardsDAL.AddToPile(deckID, code);
            return RedirectToAction("DeckOfCards");
        }*/

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
