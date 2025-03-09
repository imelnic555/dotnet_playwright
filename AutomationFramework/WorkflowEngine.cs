using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutomationFramework.Interfaces;

namespace AutomationFramework
{
    public class WorkflowEngine
    {
        private readonly List<ITask> _tasks = new List<ITask>();

        public void AddTask(ITask task)
        {
            _tasks.Add(task);
        }

        public async Task Run()
        {
            foreach (var task in _tasks)
            {
                try
                {
                    await task.Execute();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error executing task: {ex.Message}");
                }
            }
        }
    }
}