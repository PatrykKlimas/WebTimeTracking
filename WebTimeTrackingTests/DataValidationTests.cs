using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebTimeTracking.Services;

namespace WebTimeTrackingTests
{
    [TestClass]
    public class DataValidationTests
    {
        private string[] CorrectWords = {"Patryk","Kowalski-Szczesny","ADAM","ADRIAN" };
        private string[] IncorrectWords = { "\\ads", "@@#adas", "Pa pa", "xxxx xxxx" };
        private string[] ValidPasswords = { "Patryk!12", "!Pa12Tryk", "11111Ab?" };
        private string[] NoValidPasswords = { "111", "patrykpa", "PATRKHH", "???????","pATRY!K" };
        [TestMethod]
        public void IsSingleWord_Correct()
        {
            bool correct = false;
            string name;
            for (int i = 0; i < CorrectWords.Length; i++)
            {
                name = CorrectWords[i];
                correct = string.Empty.Equals(DataValidation.IsSingleWord(name));
                if (correct)
                {
                    Assert.IsTrue(correct);
                }
            }
            Assert.IsFalse(correct);
        }
        [TestMethod]
        public void IsSingleWord_Inorrect()
        {
            bool correct = true;
            string name;
            for (int i = 0; i < IncorrectWords.Length; i++)
            {
                name = IncorrectWords[i];
                correct = string.Empty.Equals(DataValidation.IsSingleWord(name));
                if (!correct)
                {
                    Assert.IsFalse(correct);
                }
            }
            Assert.IsTrue(correct);
        }
        [TestMethod]
        public void Password_Correct()
        {
            bool correct = false;
            string pass;
            for (int i = 0; i < ValidPasswords.Length; i++)
            {
                pass = ValidPasswords[i];
                correct = string.Empty.Equals(DataValidation.PasswordValidation(pass));
                if (correct)
                {
                    Assert.IsTrue(correct);
                }
            }
            Assert.IsFalse(correct);
        }
        [TestMethod]
        public void Password_Incorrect()
        {
            bool correct=true;
            string pass;
            for (int i = 0; i < NoValidPasswords.Length; i++)
            {
                pass = NoValidPasswords[i];
                correct = string.Empty.Equals(DataValidation.PasswordValidation(pass));
                if (!correct)
                {
                    Assert.IsFalse(correct);
                }
            }
            Assert.IsTrue(correct);
        }
    }
}
