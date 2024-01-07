using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Naaptol
{
    [TestFixture]
    internal class NaaptolTests : PageTest
    {
        [SetUp]
        public async Task SetUp()
        {
            Console.WriteLine("Opened Browser");
            await Page.GotoAsync("https://www.naaptol.com/", new PageGotoOptions
            {
                Timeout = 5000,
                WaitUntil = WaitUntilState.DOMContentLoaded
            });
            Console.WriteLine("Naaptol home page loaded");
        }

        [Test]
        public async Task SearchProductTest()
        {

            ILocator searchInput = Page.Locator("#header_search_text");
            await searchInput.ClickAsync(new LocatorClickOptions { Timeout = 10000 });
            await searchInput.FillAsync("eyewear");

            await searchInput.PressAsync(key: "Enter");
            await Console.Out.WriteLineAsync("Typed eyewear");
            await searchInput.PressAsync(key: "Enter");
            // await Page.Locator(selector: " #header_search .search a").Locator("visible=true").ClickAsync();


            string title = await Page.TitleAsync();
            await Console.Out.WriteLineAsync(title);

            await Console.Out.WriteLineAsync(Page.Url);
            //await Expect(Page).ToHaveURLAsync("https://www.naaptol.com/search.html?type=srch_catlg&kw=eyewear");


        }
    }
}