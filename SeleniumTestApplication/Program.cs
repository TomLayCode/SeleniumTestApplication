using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace SeleniumTestApplication
{
    class Program
    {
        static void Main()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("headless");
            using (var browser = new ChromeDriver(chromeOptions))
            {
                WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(10));
                browser.Navigate().GoToUrl("https://www.google.com/ncr");
                browser.FindElement(By.Name("q")).SendKeys("cheese" + Keys.Enter);
                IWebElement firstResult = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("h3>div")));
                Console.WriteLine(firstResult.GetAttribute("textContent"));

            }
        }
    }
}
