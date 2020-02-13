using OpenQA.Selenium;

namespace Exercise1.Forms
{
    public class CartForm : BaseForm
    {
        public CartForm(IWebDriver driver) : base(driver)
        {
        }

        public void AssertItemIsInCartAndDeleteFromCart(string name)
        {
            var bodyTag = driver.FindElement(By.TagName("body"));
            if (bodyTag.Text.Contains(name))
            {
                var _deleteFromCartButton = driver.FindElement(By.XPath("//i[contains(@title, 'usuń przedmiot')]"));
                _deleteFromCartButton.Click();
            }
        }
    }
}
