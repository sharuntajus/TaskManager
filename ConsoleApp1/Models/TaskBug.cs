using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    internal class TaskBug :TaskItem
    {
        public string BugSeverity { get;private set; }

        public TaskBug(int taskId, string taskName, string taskDesc, User reporter, User assignee,string bugSeverity, TaskPriority priority, List<string> tags)
            :base(taskId,taskName, taskDesc, reporter, assignee, priority, tags)
        {
            BugSeverity = bugSeverity;
        }
        public override void Complete()
        {
            UpdateStatus(TaskStatus.Completed);
            Console.WriteLine($" Bug '{TaskName}' fixed.");

        }
        public override void Display()
        {
            base.Display();
            //Status = TaskStatus.Completed;
            Console.WriteLine($" - Bug Severity: {BugSeverity}");
        }
    }
}
