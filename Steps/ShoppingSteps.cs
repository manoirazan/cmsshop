using cmsshop.Context;
using cmsshop.Pages;

namespace cmsshop.Steps
{
    [Binding]
    public class ShoppingSteps
    {
        private TestRunContext _testRunContext;
        private HomePage _homePage;
        private CartPage _cartPage;

        public ShoppingSteps(TestRunContext testRunContext,
            HomePage homePage,
            CartPage cartPage)
        {
            _testRunContext = testRunContext;
            _homePage = homePage;
            _cartPage = cartPage;
        }

        [Given(@"I am on the shop home page")]
        public void GivenIAmOnTheShopHomePage()
        {
            _testRunContext.NavigateToHome();
        }


        [Given(@"I add four random items to my cart")]
        public void GivenIAddFourRandomItemsToMyCart()
        {
            _homePage.AddRandomItemsToCart(4);
        }

        [When(@"I view my cart")]
        public void WhenIViewMyCart()
        {
            _testRunContext.NavigateToPage("cart");
        }

        [Then(@"I find total four items listed in my cart")]
        public void ThenIFindTotalFourItemsListedInMyCart()
        {
            var items = _cartPage.NumberOfItemsInCart();
            items.Should().Be(4);
        }

        [When(@"I remove the lowest price item from my cart")]
        public void WhenIRemoveTheLowestPriceItemFromMyCart()
        {
            _cartPage.RemoveLowestsPriceItemFromCart();
        }

        [Then(@"I am able to verify three items in my cart")]
        public void ThenIAmAbleToVerifyThreeItemsInMyCart()
        {
            var items = _cartPage.NumberOfItemsInCart();
            items.Should().Be(3);
        }

    }
}
