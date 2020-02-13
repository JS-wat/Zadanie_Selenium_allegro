using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Exercise1.Forms
{
    public class SearchResultForm : BaseForm
    {
        public SearchResultForm(IWebDriver driver) : base(driver)
        {

        }

        internal void SearchFilter(SearchedData searchedData)
        {
            MoveToElement(By.XPath("//span[contains(text(), 'używane')]"));
            WaitForClickable(By.XPath("//span[contains(text(), 'używane')]"), 5);
            var _usedItemFilterButton = driver.FindElement(By.XPath("//span[contains(text(), 'używane')]"));
            _usedItemFilterButton.Click();

            MoveToElement(By.Id("price_from"));
            WaitForClickable(By.Id("price_from"), 5);
            var _priceFromTextBox = driver.FindElement(By.Id("price_from"));
            _priceFromTextBox.SendKeys(searchedData.PriceFrom);

            WaitForClickable(_usedItemFilterButton, 5);
        }

        public SearchedItemForm ChooseFirstItem()
        {
            MoveToElement(By.XPath("(//div[contains(@class, 'opbox-listing--base')]//article)[1]"));
            WaitForClickable(By.XPath("(//div[contains(@class, 'opbox-listing--base')]//article)[1]"), 5);
            var _firstResultItem = driver.FindElement(By.XPath("(//div[contains(@class, 'opbox-listing--base')]//article)[1]"));
            _firstResultItem.Click();

            return new SearchedItemForm(driver);
        }
    }
}
