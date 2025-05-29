using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    internal class TaskFeature :TaskItem
    {
        public DateTime DueDate { get; set; }
        public TaskFeature(int taskId, string taskName, string taskDesc, User reporter, User assignee, DateTime dueDate,TaskPriority priority,List<string>tags)
            : base(taskId, taskName, taskDesc, reporter, assignee,priority,tags)
        {
            DueDate= dueDate;
        }

        public override void Complete()
        {
            if (DateTime.Now > DueDate)
            {
                Console.WriteLine($" Feature '{TaskName}' Delayed.");
            }
            else
            {
                Console.WriteLine($"Feature '{TaskName}' completed.");
            }
            Status = TaskStatus.Completed;
        }
        public override void Display()
        {
            base.Display();
            Console.WriteLine($" - Due Date: {DueDate.ToShortDateString()}");
            if (DateTime.Now > DueDate) { Console.WriteLine("OVERDUE"); }
            else if ((DueDate - DateTime.Now).TotalDays <= 2)
            {
                Console.WriteLine("Last two days");
            }
        }
    }
}
