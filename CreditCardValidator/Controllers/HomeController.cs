using CreditCardValidator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CreditCardValidator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var cardTypes = new List<CardType>()
            {
                new CardType { Id = 1, Name = "American Express" },
                new CardType { Id = 2, Name = "Discover" },
                new CardType { Id = 3, Name = "Mastercard" },
                new CardType { Id = 4, Name = "Visa" }
            };
            ViewBag.CreditCardType = new SelectList(cardTypes, "Id", "Name");
            return View();
        }
    }
}