using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace RozetkaPageFactoryParallel.Pages
{
    class HomePage : BasePage

    {
        public HomePage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@class='search-form__input ng-untouched ng-pristine ng-valid']")]
            private readonly IWebElement searchInput;
            
            [FindsBy(How = How.XPath, Using = "//button[contains(@class,'button button_color_green')]")]
            private readonly IWebElement searchButton;

        public void SearchByKeyword(string nameProducts)
        {
            searchInput.SendKeys(nameProducts);
            searchButton.Click();
            driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(30);
        }

    }
}
