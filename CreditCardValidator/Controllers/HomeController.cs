using CreditCardValidator.Models;
using CreditCardValidator.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CreditCardValidator.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home/Index
        public ActionResult Index()
        {
            CreditCard card = new CreditCard();
            return View(card);
        }

        // POST: Home/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "CardType, CreditCardNumber")] CreditCard card)
        {
            if (ModelState.IsValid)
            {
                // Amex
                if (card.CardType == 1)
                {
                        card.Result = CardValidator.IsValidAmex(card.CreditCardNumber) ? "Valid" : "Invalid";
                }
                // Discover
                else if (card.CardType == 2)
                {
                    card.Result = CardValidator.IsValidDiscover(card.CreditCardNumber) ? "Valid" : "Invalid";
                }
                // Mastercard
                else if (card.CardType == 3)
                {
                    card.Result = CardValidator.IsValidMastercard(card.CreditCardNumber) ? "Valid" : "Invalid";
                }
                // Visa
                else
                {
                    card.Result = CardValidator.IsValidVisa(card.CreditCardNumber) ? "Valid" : "Invalid";
                }
            }
            return View(card);
        }
    }
}