using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace RozetkaPageFactoryParallel.Pages
{
    class SearchResultsPage : BasePage
    {

        public SearchResultsPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[@data-filter-name='producer']//input")]
        private IWebElement brandSearch;

        [FindsBy(How = How.XPath, Using = "//div[@data-filter-name='producer']//a[1]")]
        private IWebElement brandCheckbox;

        [FindsBy(How = How.XPath, Using = "//button[contains(@class,'buy-button')]")]
        private IWebElement firstProduct;

        [FindsBy(How = How.XPath, Using = "//rz-cart//button[contains(@class, 'header__button ng-star-inserted')]")]
        private IWebElement cartButton;

        [FindsBy(How = How.CssSelector, Using = "select[class*='select']")]
        IWebElement elementSort;
        SelectElement SortHighDropdown
        {
            get { return new SelectElement(elementSort); }
        }

        public void filterByBrand(string filter)
        {
            Thread.Sleep(3000);
            brandSearch.SendKeys(filter);
            Thread.Sleep(3000);
            brandCheckbox.Click();
        }
        public void changeSortingHigh(int order)
        {
            SortHighDropdown.SelectByIndex(order);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }


        public void BuyFirstProduct()
        {
            Thread.Sleep(3000);
            firstProduct.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public void ClickCartButton()
        {
            cartButton.Click();
        }
    }
}
