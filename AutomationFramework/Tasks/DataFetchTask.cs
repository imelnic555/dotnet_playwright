using System;
using System.Threading.Tasks;
using AutomationFramework.Interfaces;


namespace AutomationFramework.Tasks
{
    public class DataFetchTask : ITask
    {
        public async Task Execute()
        {
            Console.WriteLine("Fetching data...");
            await Task.Delay(1000); // Simulating async work
            Console.WriteLine("Data fetched.");
        }
    }
}