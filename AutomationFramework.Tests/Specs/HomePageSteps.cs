using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace AutomationFramework.Tests.Specs
{
    [Binding]
    public class HomePageSteps
    {
        private IPlaywright _playwright;
        private IBrowser _browser;
        private IPage _page;

        [Given(@"I open the browser")]
        public async Task GivenIOpenTheBrowser()
        {
            _playwright = await Playwright.CreateAsync();

            var launchOptions = new BrowserTypeLaunchOptions
            {
                Headless = true
            };

            if (Environment.GetEnvironmentVariable("CI") == "true")
            {
                launchOptions.ExecutablePath = "";
            }

            _browser = await _playwright.Chromium.LaunchAsync(launchOptions);
            _page = await _browser.NewPageAsync();
        }
        
        [When(@"I navigate to ""(.*)""")]
        public async Task WhenINavigateTo(string url)
        {
            await _page.GotoAsync(url);
        }

        [Then(@"the page title should contain ""(.*)""")]
        public async Task ThenThePageTitleShouldContain(string expectedTitle)
        {
            var title = await _page.TitleAsync();
            Assert.That(title, Does.Contain(expectedTitle));
        }

        [When(@"I click the button with ID ""(.*)""")]
        public async Task WhenIClickTheButtonWithID(string buttonId)
        {
            await _page.ClickAsync($"#{buttonId}");
        }

        [Then(@"the page should contain ""(.*)""")]
        public async Task ThenThePageShouldContain(string expectedText)
        {
            var content = await _page.ContentAsync();
            Assert.That(content, Does.Contain(expectedText));
        }

        [AfterScenario]
        public async Task Cleanup()
        {
            await _page.CloseAsync();
            await _browser.CloseAsync();
            _playwright.Dispose();
        }
    }
}
