using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWNUnit
{
    [TestFixture]
    internal class EATests : PageTest
    {
        [SetUp]
        public async Task SetUp()
        {
            Console.WriteLine("Opened Browser");
            await Page.GotoAsync("http://eaapp.somee.com/",
                new PageGotoOptions
                { Timeout = 7000, WaitUntil = WaitUntilState.DOMContentLoaded});
            Console.WriteLine("Page Loaded");
        }
        [Test]
        public async Task LoginTest()
        {

            

            //await Page.GetByText("Login").ClickAsync();

            //var lnkLogin = Page.Locator(selector: "text=Login");
            //await lnkLogin.ClickAsync();

            await Page.ClickAsync(selector: "text=Login", new PageClickOptions
            { Timeout = 8000 });

            await Console.Out.WriteLineAsync("Link Clicked");

            await Expect(Page).ToHaveURLAsync("http://eaapp.somee.com/Account/Login");

            //await Page.GetByLabel("UserName").FillAsync(value: "admin");
            //await Page.GetByLabel("Password").FillAsync(value: "password");
            //await Console.Out.WriteLineAsync("Typed");

            //await Page.Locator("#UserName").FillAsync(value: "admin");
            //await Page.Locator("#Password").FillAsync(value: "password");
            //await Console.Out.WriteLineAsync("Typed");

            await Page.FillAsync(selector: "#UserName", "admin");
            await Page.FillAsync(selector: "#Password", "password");
            await Console.Out.WriteLineAsync("Typed");

            //await Page.Locator("//input[@value='Log in']").ClickAsync();
            var btnLogin = Page.Locator(selector: "input", new PageLocatorOptions
            { HasTextString = "Log in" });
            await btnLogin.ClickAsync();

            await Console.Out.WriteLineAsync("Clicked");

            //await Expect(Page).ToHaveTitleAsync("Home - Execute Automation Employee App");

            //await Expect(Page.Locator(selector:"text='Hello admin!'")).ToBeVisibleAsync();
            var hello = Page.Locator(selector: "text='Hello admin!'");
            var logoff = Page.Locator(selector: "text='Log off'");
            await Expect(hello
                .And(logoff)).ToBeVisibleAsync();


        }
    }
}
