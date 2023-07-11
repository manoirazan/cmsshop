using cmsshop.Context;
using OpenQA.Selenium;

namespace cmsshop.Pages
{
    [Binding]
    public class CartPage : BasePage
    {
        private readonly By _itemInCart = By.ClassName("cart_item");
        private readonly By _itemPrices = By.CssSelector(".cart_item .product-price .amount span");
        private readonly By _itemsToRemove = By.CssSelector(".cart_item .product-remove");

        public CartPage(TestRunContext testRunContext) : base(testRunContext.Driver)
        {
        }

        public int NumberOfItemsInCart()
        {
            return Driver.FindElements(_itemInCart).Count;
        }

        public void RemoveLowestsPriceItemFromCart()
        {
            var productPrices = Driver.FindElements(_itemPrices);
            List<double> prices = productPrices.Select(item=> double.Parse(item.)).ToList();
            double lowestPrice = prices.Min();
            int lowestPriceIndex = prices.IndexOf(lowestPrice);

            var itemsToRemove = Driver.FindElements(_itemsToRemove);
            itemsToRemove[lowestPriceIndex].Click();
        }
    }
}
