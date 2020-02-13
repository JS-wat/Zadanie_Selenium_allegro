using OpenQA.Selenium;
using System.Threading;

namespace Exercise1.Forms
{
    public class HomePage : BaseForm
    {
        public HomePage(IWebDriver driver, Links url) : base(driver)
        {
            this.driver.Url = url.Url.ToString();
        }

        public HomePage AcceptReg()
        {
            WaitForClickable(By.XPath("//button[contains(text(), 'przejdź dalej')]"), 5);

            var _buttonAcceptConsent = driver.FindElement(By.XPath("//button[contains(text(), 'przejdź dalej')]"));
            
            if (_buttonAcceptConsent.Displayed)
            {
                _buttonAcceptConsent.Click();
            }

            return this;
        }

        internal SearchResultForm SearchItem(SearchedData searchedData)
        {
            WaitForClickable(By.Name("string"), 5);
            var _searchedItem = driver.FindElement(By.Name("string"));
            _searchedItem.SendKeys(searchedData.SearchedItem);

            WaitForClickable(By.XPath("//button[contains(text(), 'szukaj')]"), 5);
            var _searchButton = driver.FindElement(By.XPath("//button[contains(text(), 'szukaj')]"));
            _searchButton.Click();

            return new SearchResultForm(driver);
        }
    }
}
