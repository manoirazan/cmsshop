using cmsshop.Context;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace cmsshop.Pages
{
    [Binding]
    public class HomePage : BasePage
    {
        private readonly By _addToCart = By.CssSelector(".button.ajax_add_to_cart");
        private readonly By _viewCartOption = By.CssSelector(".added_to_cart.wc-forward");
        public HomePage(TestRunContext testRunContext) : base(testRunContext.Driver)
        {
        }

        public IWebElement GetListOfItems()
        {
            return (IWebElement)Driver.FindElements(_addToCart);
        }

        public void AddRandomItemsToCart(int numberOfItems)
        {
            Random random = new Random();
            HashSet<int> clickedIndices = new HashSet<int>();
            var items = Driver.FindElements(_addToCart);

            while (clickedIndices.Count < 4)
            {
                int randomItemIndex = random.Next(items.Count);

                if (!clickedIndices.Contains(randomItemIndex))
                {
                    clickedIndices.Add(randomItemIndex);
                    IWebElement elementToClick = items[randomItemIndex];
                    elementToClick.Click();
                    var viewCarts = Driver.FindElements(_viewCartOption);
                    WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                    wait.Until(c => c.FindElements(_viewCartOption));
                    Thread.Sleep(2000);//temp solution to wait for the item to be added to the cart and scrolling issues
                }
            }

        }
    }
}
