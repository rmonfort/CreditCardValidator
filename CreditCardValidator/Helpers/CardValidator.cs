using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditCardValidator.Helpers
{
    enum CardType
    {
        Amex = 1,
        Discover = 2,
        Mastercard = 3,
        Visa = 4,

    }
    public static class CardValidator
    {
        public static bool IsValidAmex(ulong? creditCardNumber)
        {
            if (creditCardNumber > 0 && HasCorrectNumberOfDigits(creditCardNumber, 15))
            {
                if (HasCorrectPrefix(creditCardNumber, CardType.Amex) && PassesLuhn(creditCardNumber.ToString()))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsValidDiscover(ulong? creditCardNumber)
        {
            if (creditCardNumber > 0 && HasCorrectNumberOfDigits(creditCardNumber, 16))
            {
                if (HasCorrectPrefix(creditCardNumber, CardType.Discover) && PassesLuhn(creditCardNumber.ToString()))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsValidMastercard(ulong? creditCardNumber)
        {
            throw new NotImplementedException();
        }

        public static bool IsValidVisa(ulong? creditCardNumber)
        {
            throw new NotImplementedException();
        }

        private static bool HasCorrectNumberOfDigits(ulong? number, int requiredNumberOfDigits)
        {
            int numberOfDigits = number.ToString().Length;
            return (numberOfDigits == requiredNumberOfDigits);
        }

        private static bool HasCorrectPrefix(ulong? creditCardNumber, CardType cardType)
        {
            if (cardType == CardType.Amex)
            {
                // IIN(Issuer identification number) for Amex : 34, 37
                int prefix = Convert.ToInt32(creditCardNumber.ToString().Substring(0, 2));
                if (prefix == 34 || prefix == 37)
                {
                    return true;
                }
                return false;
            }

            if (cardType == CardType.Discover)
            {
                // IIN for Discover : 65
                int prefix = Convert.ToInt32(creditCardNumber.ToString().Substring(0, 2));
                if (prefix == 65)
                {
                    return true;
                }
                
                // INN range for Discover : 644-649 
                prefix = Convert.ToInt32(creditCardNumber.ToString().Substring(0, 3));
                if (prefix > 644 && prefix < 649)
                {
                    return true;
                }

                // INN for Discover : 6011
                prefix = Convert.ToInt32(creditCardNumber.ToString().Substring(0, 4));
                if (prefix == 6011)
                {
                    return true;
                }

                // INN range for Discover : 622126-622925
                prefix = Convert.ToInt32(creditCardNumber.ToString().Substring(0, 6));
                if (prefix > 622126 && prefix < 622925)
                {
                    return true;       
                }
                return false;
            }

            if (cardType == CardType.Mastercard)
            {
                return true;
            }

            if (cardType == CardType.Visa)
            {
                return true;
            }

            return false;
        }

        // Luhn algorithm
        public static bool PassesLuhn(this string creditCardNumber)
        {
            return PassesLuhn(creditCardNumber.Select(c => c - '0').ToArray());
        }

        private static bool PassesLuhn(this int[] digits)
        {
            return GetCheckValue(digits) == 0;
        }

        private static int GetCheckValue(int[] digits)
        {
            return digits.Select((d, i) => i % 2 == digits.Length % 2 ? ((2 * d) % 10) + d / 5 : d).Sum() % 10;
        }
    }
}