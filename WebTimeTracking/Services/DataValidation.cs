using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebTimeTracking.ViewModels;

namespace WebTimeTracking.Services
{
    static public class DataValidation
    {

        public static string IsPersonValid(ref PersonViewModel person)
        {
            string result;

            result = IsSingleWord(person.FirstName);
            if (result.Equals(string.Empty))
                return "Invalid First Name";
            else
                person.FirstName = result;

            result = IsSingleWord(person.LastName);
            if (result.Equals(string.Empty))
                return "Invalid Lase Name";
            else
                person.LastName = result;

            result = IsSingleWord(person.City);
            if (result.Equals(string.Empty))
                return "Invalid City";
            else
                person.LastName = result;

            result = IsSingleWord(person.Country);
            if (result.Equals(string.Empty))
                return "Invalid Country";
            else
                person.LastName = result;

            result = IsPostalCode(person.PostalCode);
            if (result.Equals(string.Empty))
                return "Invalid Postal Code";
            else
                person.LastName = result;

            result = PasswordValidation(person.Password);
            if (result.Equals(string.Empty))
                return "Hasło powinno zawierać conajmniej 1 dużą litere, liczbe oraz znak specjalny. Długość od 6 do 63 znaków.";
            else
                person.LastName = result;

            if (!PasswordConfirmation(person.Password, person.PasswordConfirm))
                return "Nieprawidłowo powtórzone hasło.";
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
        public static string PasswordValidation(string pass)
        {
            Regex rxPassword = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d\\W]{6,63}$");
            if (rxPassword.IsMatch(pass))
            {
                return pass;
            }
            else
            {
                return string.Empty;
            }
        }
        public static bool PasswordConfirmation(string pass1, string pass2)
        {
            return pass1.Equals(pass2);
        }
    }
}
