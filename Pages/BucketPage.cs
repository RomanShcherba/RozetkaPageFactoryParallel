using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace RozetkaPageFactoryParallel.Pages
{
    class BucketPage : BasePage
    {
        public BucketPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this); 
        }

        [FindsBy(How = How.XPath, Using = "//div[@class ='cart-receipt__sum-price']//span[contains(@class,'')]")]
        private IWebElement bucketTotal;

        public int getBucketSumm()
        {
            return int.Parse(bucketTotal.Text);
        }

    }
}
