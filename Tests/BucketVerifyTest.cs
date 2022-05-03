using NUnit.Framework;
using RozetkaPageFactoryParallel.DataSource;
using RozetkaPageFactoryParallel.Pages;
using RozetkaPageFactoryParallel.Utils;

[assembly: LevelOfParallelism(3)]

namespace RozetkaPageFactoryParallel.Tests
{
    [TestFixture]

    [Parallelizable(scope: ParallelScope.All)]
    public class BucketVerifyTest : BaseTest
    {
        
        [TestCaseSource(typeof(DataProvider), nameof(DataProvider.TestData))]
        public void ExecuteTest(Filter filter)
        {
            HomePage homePage = new HomePage(Driver);
            homePage.SearchByKeyword(filter.nameProducts);
            SearchResultsPage searchResultsPage = new SearchResultsPage(Driver);
            searchResultsPage.filterByBrand(filter.brand);
            searchResultsPage.changeSortingHigh(2);
            searchResultsPage.BuyFirstProduct();
            searchResultsPage.ClickCartButton();
            BucketPage bucketPage = new BucketPage(Driver);
            int total = bucketPage.getBucketSumm();
            Assert.That(total, Is.LessThan(filter.price));

        }
    }
}
