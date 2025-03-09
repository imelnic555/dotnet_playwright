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

            // Manually specify the Chromium executable path
            var chromiumPath = @"C:\Users\home\AppData\Local\ms-playwright\chromium-1161\chrome-win\chrome.exe";

            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                ExecutablePath = chromiumPath, // ✅ Force Playwright to use this version
                Headless = true
            });

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