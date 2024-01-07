using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonPOM.AmazonTests.Pages
{
    internal class HomePage
    {
        private IPage _page;
        private ILocator SearchInput => _page.Locator(selector: "#twotabsearchtextbox");
        private ILocator SearchButton => _page.Locator(selector: "#nav-search-submit-button");
        public HomePage(IPage page) => _page = page;
        public async Task Search(string searchtext)
        {
            await SearchInput.ClickAsync();
            await SearchInput.FillAsync(searchtext);
            await SearchButton.ClickAsync();
        }
    }
}
