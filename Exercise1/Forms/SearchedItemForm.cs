using OpenQA.Selenium;

namespace Exercise1.Forms
{
    public class SearchedItemForm : BaseForm
    {
        public string itemName;
        public SearchedItemForm(IWebDriver driver) : base(driver)
        {

        }

        public CartForm AddToAndGoToCart()
        {
            WaitForClickable(By.Id("add-to-cart-button"), 5);
            var _buttonAddToCart = driver.FindElement(By.Id("add-to-cart-button"));
            _buttonAddToCart.Click();

            WaitForClickable(By.Id("add-to-cart-si-precart"), 5);
            var _buttonGoToCart = driver.FindElement(By.Id("add-to-cart-si-precart"));
            _buttonGoToCart.Click();

            return new CartForm(driver);
        }

        public string GetItemName()
        {
            var _nameItem = driver.FindElement(By.XPath("//h1"));
            string itemName = _nameItem.Text;

            return itemName;
        }
    }
}
