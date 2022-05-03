using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using Serilog;
using System;
using OpenQA.Selenium;

namespace RozetkaPageFactoryParallel.Tests
{
    [TestFixture]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]

    public class BaseTest
    {
        private IWebDriver driver;
        public IWebDriver Driver { get { return driver; } }
        [SetUp]
        public void Setup()
        {
             Log.Logger = new LoggerConfiguration()
                .WriteTo.File(@"E:\домашка\EPAM LAB\RozetkaPageFactoryParallel\RozetkaPageFactoryParallel\Logs\Logs.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
             Log.Information("Log started");
            driver = new ChromeDriver();
            Driver.Navigate().GoToUrl("https://rozetka.com.ua/");
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
            Log.Information("Closed");
        }
    }
}
