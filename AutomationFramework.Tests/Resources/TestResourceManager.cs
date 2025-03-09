using System;
using NUnit.Framework;

namespace AutomationFramework.Tests.Resources
{
    [SetUpFixture]
    public class TestResourceManager
    {
        [OneTimeSetUp]
        public void GlobalSetup()
        {
            Console.WriteLine("🔄 Setting up global test resources...");
        }

        [OneTimeTearDown]
        public void GlobalTeardown()
        {
            Console.WriteLine("🧹 Cleaning up test resources...");
            // Add resource cleanup logic here (e.g., closing DB connections, removing temp files)
        }
    }
}