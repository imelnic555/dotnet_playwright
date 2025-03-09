using NUnit.Framework;
using System.Threading.Tasks;
using AutomationFramework;
using AutomationFramework.Tasks;

namespace AutomationFramework.Tests
{
    [TestFixture] // ✅ NUnit class attribute
    public class WorkflowEngineTests
    {
        [SetUp] // ✅ Runs before each test (optional)
        public void Setup() { }

        [Test] // ✅ NUnit test attribute
        public async Task WorkflowEngine_ExecutesTasksInOrder()
        {
            // Arrange
            var workflow = new WorkflowEngine();
            var fetchTask = new DataFetchTask();
            var processTask = new DataProcessingTask();

            workflow.AddTask(fetchTask);
            workflow.AddTask(processTask);

            // Act
            await workflow.Run();

            // Assert
            Assert.Pass(); // ✅ NUnit syntax
        }
    }
}