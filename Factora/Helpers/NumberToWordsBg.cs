using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factora.Helpers
{
    public static class NumberToWordsBg
    {
        private static readonly string[] Units = { "", "едно", "две", "три", "четири", "пет", "шест", "седем", "осем", "девет" };
        private static readonly string[] Teens = { "десет", "единадесет", "дванадесет", "тринадесет", "четиринадесет", "петнадесет", "шестнадесет", "седемнадесет", "осемнадесет", "деветнадесет" };
        private static readonly string[] Tens = { "", "десет", "двадесет", "тридесет", "четиридесет", "петдесет", "шестдесет", "седемдесет", "осемдесет", "деветдесет" };
        private static readonly string[] Hundreds = { "", "сто", "двеста", "триста", "четириста", "петстотин", "шестстотин", "седемстотин", "осемстотин", "деветстотин" };

        public static string ToWords(decimal amount)
        {
            long euro = (long)Math.Floor(amount);
            int cents = (int)Math.Round((amount - euro) * 100);

            string euroText = euro == 0 ? "нула" : ConvertGroup(euro);

            string currencyEuro = "евро";

            string currencyCents = cents == 1 ? "цент" : "цента";

            return $"{euroText} {currencyEuro} и {cents:00} {currencyCents}";
        }

        private static string ConvertGroup(long n)
        {
            if (n >= 1000)
            {
                long thousands = n / 1000;
                long remainder = n % 1000;
                string thText = thousands == 1 ? "хиляда" : (thousands == 2 ? "две хиляди" : ConvertGroup(thousands) + " хиляди");
                return remainder == 0 ? thText : stText(thText, remainder);
            }

            string result = "";
            if (n >= 100)
            {
                result += Hundreds[n / 100];
                n %= 100;
                if (n > 0) result += " ";
            }

            if (n >= 10 && n <= 19)
            {
                result += (result != "" ? "и " : "") + Teens[n - 10];
                return result;
            }

            if (n >= 20)
            {
                result += Tens[n / 10];
                n %= 10;
                if (n > 0) result += " и ";
            }
            else if (n > 0 && result != "")
            {
                result += "и ";
            }

            if (n > 0) result += Units[n];
            return result;
        }

        private static string stText(string thText, long remainder)
        {
            string remText = ConvertGroup(remainder);
            if (remainder < 20 || (remainder < 100 && remainder % 10 == 0))
                return $"{thText} и {remText}";
            return $"{thText} {remText}";
        }
    }
}
