using System;
using System.Threading.Tasks;
using AutomationFramework.Interfaces;

namespace AutomationFramework.Tasks
{
    public class DataProcessingTask : ITask
    {
        public async Task Execute()
        {
            Console.WriteLine("Processing data...");
            await Task.Delay(1500); // Simulating async work
            Console.WriteLine("Data processed.");
        }
    }
}