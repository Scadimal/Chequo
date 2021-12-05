using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;

namespace Chequo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NumberTranslatorController : ControllerBase
    {
        private readonly ILogger<NumberTranslatorController> _logger;

        public NumberTranslatorController(ILogger<NumberTranslatorController> logger)
        {
            _logger = logger;
        }

        private static String[] englishNumbers = {
            "", 
            "ONE", 
            "TWO", 
            "THREE", 
            "FOUR", 
            "FIVE", 
            "SIX", 
            "SEVEN", 
            "EIGHT", 
            "NINE", 
            "TEN", 
            "ELEVEN", 
            "TWELVE", 
            "THIRTEEN", 
            "FOURTEEN", 
            "FIFTEEN", 
            "SIXTEEN", 
            "SEVENTEEN", 
            "EIGHTEEN", 
            "NINETEEN"
        };
        private static String[] englishTens = {
            "",
            "TEN",
            "TWENTY",
            "THIRTY",
            "FOURTY",
            "FIFTY",
            "SIXTY",
            "SEVENTY",
            "EIGHTY",
            "NINETY"
        };
        // Going to quintillion in case someone decides to make a cheque out for the entire world's wealth in Venezuelan Bolivar :)
        private static String[] placeValues = {
            "",
            "THOUSAND",
            "MILLION",
            "BILLION",
            "TRILLION",
            "QUADRILLION",
            "QUINTILLION"
        };
        [EnableCors("LocalPolicy")]
        [HttpGet]
        /**
        * Returns a decimal number in english
        *
        * @param {decimal} credit The number to translate.
        * @return {String} 'credit' translated into common english in DOLLARS and CENTS
        */
        public String Get(decimal credit)
        {
            if(credit == 0)
                throw new  BadHttpRequestException("Please don't waste paper on a valueless cheque");
            if(credit < 0)
                throw new BadHttpRequestException("Stealing money with a cheque is illegal >:C", 451);

            String[] creditStrings = Math.Round(credit, 2).ToString().Split(".");
            decimal dollarsNum = decimal.Parse(creditStrings[0]);
            String dollarsWords = numberToEnglish(dollarsNum);
            String dollars = (dollarsWords.Length == 0 ? "ZERO" : dollarsWords) + " DOLLAR";
            dollars += dollarsNum == 1 ? "" : "S";
            String cents = "";
            if(creditStrings.Length == 2){
                decimal centsNum = decimal.Parse(creditStrings[1]);
                cents = " AND " + numberToEnglish(centsNum) + " CENT";
                cents += centsNum == 1 ? "" : "S";
            }
            return dollars + cents;
        }
        
        private String numberToEnglish(decimal num){
            /* 
                This is a scalable solution in case Australia ever falls victim to hyperinflation
                (Honestly I think a switch case for every place value is more readable, but I figured this
                was better to showcase)
            */

            /**
            * Returns a decimal number in english. This was made to take in a decimal to ensure the function
            * was compatible with all valid numbers
            *
            * @param {decimal} num The number to translate.
            * @return {String} 'num' translated into common english
            */
            if(!(Math.Abs(num % 1) == 0))
                throw new Exception("Cannot call numberToEnglish with input " + num);
                
            String englishNum = "";
            int power = num.ToString().Length-1;
            decimal divider = (decimal) Math.Pow(10, power - (power % 3));
            if(power >= 3){
                englishNum += hundredsToEnglish((int)((num/divider) % divider));
            } else {
                englishNum += hundredsToEnglish((int)num);
            }
            if((power)/3 > placeValues.Length -1)
                //If we don't have a word defined for this power, simply make one up and hope the banks don't notice
                englishNum += " " + numberToEnglish(power/3 - 1) + "TILLION";
            else{
                englishNum += power >= 3 ? " " + placeValues[(power)/3] : "";
            }
            decimal nextNum = num % (decimal) Math.Pow(10, power-(power%3));
            if(nextNum >= 1)
                englishNum += (nextNum < 100 ? " AND " : " ") + numberToEnglish(nextNum);
            return englishNum;
        }

        private String hundredsToEnglish(int hundreds){
            String output = "";
            switch(hundreds.ToString().Length){
                case 3:
                    output += englishNumbers[hundreds/100] + " HUNDRED";
                    if(hundreds % 100 > 0){
                        output += " AND ";
                        goto case 2;
                    }
                    break;
                case 2:
                    if(hundreds % 100 > 19){
                        output += englishTens[hundreds % 100 / 10];
                        if(hundreds % 10 > 0){
                            output += "-";
                            goto case 1;
                        }
                    } else {
                        output += englishNumbers[hundreds % 100];
                    }
                    break;
                case 1:
                    output += englishNumbers[hundreds % 10];
                    break;
                default:
                    throw new Exception("Invalid power detected - " + hundreds);
            }
            return output;
        }
    }
}
