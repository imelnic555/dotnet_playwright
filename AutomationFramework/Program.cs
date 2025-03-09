// See https://aka.ms/new-console-template for more information

using AutomationFramework;

using AutomationFramework.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Starting Automation Framework...");

        WorkflowEngine workflow = new WorkflowEngine();
        workflow.AddTask(new DataFetchTask());
        workflow.AddTask(new DataProcessingTask());

        await workflow.Run();

        Console.WriteLine("Automation Completed.");
    }
}