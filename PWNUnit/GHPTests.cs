using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace PWNUnit
{
    public class GHPTests : PageTest
    {
        [SetUp]
        public void Setup()
        {
        }
        //Manual Instance
        //[Test]
        //public async Task Test1()
        //{


        //    //playwright startup
        //    using var playwright = await Playwright.CreateAsync();

        //    //launch browser
        //    await using var browser = await playwright.Chromium.LaunchAsync(
        //        new BrowserTypeLaunchOptions
        //        {
        //            Headless = false
        //        });

        //    //page instance
        //    var context = await browser.NewContextAsync();
        //    var page = await context.NewPageAsync();

        //    Console.WriteLine("Opened Browser");
        //    await page.GotoAsync("https://www.google.com");
        //    Console.WriteLine("Page Loaded");

        //    string title = await page.TitleAsync();
        //    Console.WriteLine(title);
        //    //await page.GetByTitle("Search").FillAsync("hp laptop");
        //    await page.Locator("#APjFqb").FillAsync("selenium");
        //    Console.WriteLine("typed");


        //    await page.Locator("(//input[@value='Google Search'])[2]").ClickAsync();
        //    Console.WriteLine("Clicked");

        //    title = await page.TitleAsync();
        //    Console.WriteLine(title);
        //}
        //PW Managed Instance
        [Test]
        public async Task Test2()
        {



            Console.WriteLine("Opened Browser");
            await Page.GotoAsync("https://www.google.com");
            Console.WriteLine("Page Loaded");

            string title = await Page.TitleAsync();
            Console.WriteLine(title);
            await Expect(Page).ToHaveTitleAsync("Google");
            //await page.GetByTitle("Search").FillAsync("hp laptop");
            await Page.Locator("#APjFqb").FillAsync("selenium");
            Console.WriteLine("typed");


            await Page.Locator("(//input[@value='Google Search'])[2]").ClickAsync();
            Console.WriteLine("Clicked");

            //title = await Page.TitleAsync();
            //Console.WriteLine(title);

            //Assert.That(title, Does.Contain("selenium"));
            await Expect(Page).ToHaveTitleAsync("selenium - Google Search");

        }
    }
}