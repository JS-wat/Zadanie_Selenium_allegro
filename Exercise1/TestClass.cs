using Exercise1.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Exercise1
{
    public class TestClass : IDisposable
    {
        private ChromeDriver driver;
        private Links UrlData()
        {
            return new Links(new Uri("https://allegro.pl"));
        }

        private SearchedData Data()
        {
            return new SearchedData("iphone x", "200");
        }

        public TestClass()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Fact]

        public void AddToCartTestCase()
        {
            var link = UrlData();
            var data = Data();

            var homePage = new HomePage(driver, link);

            homePage.AcceptReg();

            var searchResult = homePage.SearchItem(data);
            searchResult.SearchFilter(data);

            var searchedItemPage = searchResult.ChooseFirstItem();

            string nameItem = searchedItemPage.GetItemName();
            var cartPage = searchedItemPage.AddToAndGoToCart();
            cartPage.AssertItemIsInCartAndDeleteFromCart(nameItem);
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}
