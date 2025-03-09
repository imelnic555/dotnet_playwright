using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;

namespace AutomationFramework.Tests.UI
{
    public class UITests
    {
        private IPlaywright _playwright;
        private IBrowser _browser;
        private IBrowserContext _context;
        private IPage _page;

        [SetUp]
        public async Task Setup()
        {
            _playwright = await Playwright.CreateAsync();

            // Get the correct Chromium executable path
            var launchOptions = new BrowserTypeLaunchOptions
            {
                Headless = true
            };

            // Use default Playwright-installed Chromium in CI
            if (Environment.GetEnvironmentVariable("CI") == "true")
            {
                launchOptions.ExecutablePath = "";
            }

            _browser = await _playwright.Chromium.LaunchAsync(launchOptions);
            _context = await _browser.NewContextAsync();
            _page = await _context.NewPageAsync();
        }


        [Test]
        public async Task VerifyHomePageTitle()
        {
            await _page.GotoAsync("https://example.com");

            string title = await _page.TitleAsync();
            Assert.That(title, Is.Not.Empty);
        }

        [TearDown]
        public async Task Cleanup()
        {
            await _page.CloseAsync();
            await _browser.CloseAsync();
            _playwright.Dispose();
        }
    }
}