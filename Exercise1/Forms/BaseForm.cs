﻿using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace Exercise1.Forms
{
    public abstract class BaseForm
    {
        protected readonly IWebDriver driver;

        public BaseForm(IWebDriver driver)
        {
            this.driver = driver;
        }

         public void MoveToElement(By selector)
        {
            var element = driver.FindElement(selector);
            MoveToElement(element);
        }

        public void MoveToElement(IWebElement element)
        {
            Actions builder = new Actions(driver);
            Actions moveTo = builder.MoveToElement(element);
            moveTo.Build().Perform();
        }

        public void WaitForClickable(By by, int seconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }

        public void WaitForClickable(IWebElement element, int seconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }

        public void ScrollToElement(By selector)
        {
            IWebElement element = driver.FindElement(selector);
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();
        }

    }
}
