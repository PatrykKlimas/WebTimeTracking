using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebTimeTracking.Models;

namespace WebTimeTracking.Services
{
    static public class DataValidation
    {

        public static string IsPersonValid(ref Person person)
        {
            string result;

            result = IsSingleWord(person.FirstName);
            if (!result.Equals(string.Empty))
                return "Invalid First Name";
            else
                person.FirstName = result;

            result = IsSingleWord(person.LastName);
            if (!result.Equals(string.Empty))
                return "Invalid Lase Name";
            else
                person.LastName = result;

            result = IsSingleWord(person.City);
            if (!result.Equals(string.Empty))
                return "Invalid City";
            else
                person.LastName = result;

            result = IsSingleWord(person.Country);
            if (!result.Equals(string.Empty))
                return "Invalid Country";
            else
                person.LastName = result;

            result = IsPostalCode(person.PostalCode);
            if (!result.Equals(string.Empty))
                return "Invalid Postal Code";
            else
                person.LastName = result;

            return string.Empty;
        }
        public static string IsSingleWord(string sWord)
        {
            Regex rxSingleWord = new Regex("^([A-Za-z]{2,}\\-?){1,2}$");
            string sTrimWord = sWord.Trim();

            if (rxSingleWord.IsMatch(sTrimWord))
            {
                return sTrimWord.ToUpper().Substring(0,1) +
                       sTrimWord.ToLower()[1..sTrimWord.Length];
            }
            else
            {
                return string.Empty;
            }
        }

        public static string IsPostalCode(string sCode)
        {
            Regex rxSingleWord = new Regex("^\\d{2}\\-\\d{3}$");
            string sTrimCode = sCode.Trim();

            if (rxSingleWord.IsMatch(sTrimCode))
            {
                return sTrimCode;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
