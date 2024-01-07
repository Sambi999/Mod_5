using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWPOM.PWTests.Pages
{
    internal class NewLoginPage
    {
        private IPage _page; 

        private ILocator LnkLogin => _page.Locator(selector: "text=Login");
        private ILocator InpUsername => _page.Locator(selector: "#UserName");
        private ILocator InpPassword => _page.Locator(selector: "#Password");
        private ILocator BtnLogin =>  _page.Locator(selector: "input", new PageLocatorOptions
        { HasTextString = "Log in" });
        private ILocator LnkWelMess => _page.Locator(selector: "text='Hello admin!'");

        public NewLoginPage(IPage page) => _page = page;
        
        public async Task ClickLoginLink() => await LnkLogin.ClickAsync();
        
        public async Task Login(string username, string password)
        {
            await InpUsername.FillAsync(username);
            await InpPassword.FillAsync(password);
            await BtnLogin.ClickAsync();
        }
        public async Task<bool> ChkWelMess() => await LnkWelMess.IsVisibleAsync();
       
    }
}
