using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CreditCardValidator.Models
{
    public class CreditCard
    {
        private readonly List<CardType> _cardTypes;

        public CreditCard()
        {
            _cardTypes = new List<CardType>()
            {
                new CardType { Id = 1, Name = "American Express" },
                new CardType { Id = 2, Name = "Discover" },
                new CardType { Id = 3, Name = "Mastercard" },
                new CardType { Id = 4, Name = "Visa" }
            };
        }

        [DisplayName("Card Type")]
        public int CardType { get; set; }

        [DisplayName("Credit Card Number"), Required]
        public ulong? CreditCardNumber { get; set; }

        public IEnumerable<SelectListItem> CardTypes 
        {
            get { return new SelectList(_cardTypes, "Id", "Name"); }
        }

        public string Result { get; set; }
    }
}