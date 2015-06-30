using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CreditCardValidator.Models
{
    public class CreditCard
    {
        [DisplayName("Credit Card Number")]
        public int CreditCardNumber { get; set; }

        [DisplayName("Card Type")]
        public string CardType { get; set; }
    }
}