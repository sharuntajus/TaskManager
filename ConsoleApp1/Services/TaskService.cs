using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;

namespace TaskManager.Services
{
    public class TaskService
    {
        private readonly List<TaskItem> tasks = new();

        public void AddTask(TaskItem task) =>tasks.Add(task);

        public void CompleteTask(string Tittle)
        {
            var task = tasks.FirstOrDefault(t => t.TaskName == Tittle);
            if (task == null)
            {
                Console.WriteLine("Task not Found, check taskID");
                return;
            }

            task.Complete();
        }

        public void ListTasks()
        {
            foreach(var task in tasks)
            {
                task.Display();
                Console.WriteLine("");
            }
        }
        public void ListByTag(string tag)
        {
            var filtered = tasks
                .Where(t => t.Tags.Any(tg => tg.Equals(tag, StringComparison.OrdinalIgnoreCase)))
                .ToList();

            Console.WriteLine($"\n Tasks with tag '{tag}':");
            PrintTaskList(filtered);
        }

        public void ListByPriority(TaskPriority priority)
        {
            var filtered = tasks
                .Where(t => t.Priority == priority)
                .ToList();

            Console.WriteLine($"\n Tasks with priority '{priority}':");
            PrintTaskList(filtered);
        }
        private void PrintTaskList(List<TaskItem> filtered)
        {
            if (!filtered.Any())
            {
                Console.WriteLine("No tasks to show.");
                return;
            }

            foreach (var task in filtered)
            {
                task.Display();
                Console.WriteLine();
            }
        }
    }
}
