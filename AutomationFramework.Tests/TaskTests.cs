using NUnit.Framework;
using System;
using System.IO;
using System.Threading.Tasks;
using AutomationFramework.Tasks;

namespace AutomationFramework.Tests
{
    [TestFixture]
    public class TaskTests
    {
        [Test]
        public async Task DataFetchTask_ExecutesWithoutError()
        {
            // Arrange
            var task = new DataFetchTask();
            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            await task.Execute();

            // Assert
            Assert.That(output.ToString(), Does.Contain("Fetching data..."));
            Assert.That(output.ToString(), Does.Contain("Data fetched."));
        }
    }
}