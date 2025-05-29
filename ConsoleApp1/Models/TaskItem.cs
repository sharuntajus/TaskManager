using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    public abstract class TaskItem
    {
        public int TaskId { get; private set; }
        public string TaskName { get; private set; }
        public string TaskDescription { get; private set; }
        public User Assignee { get; private set; }
        public User Reporter { get; private set; }
        public TaskStatus Status { get; protected set; }
        public DateTime createdAt {  get; private set; }
        public TaskPriority Priority { get; private set; }
        public List<string> Tags { get; private set; }
        protected TaskItem(int id,string taskName, string taskDesc,User assignee,User reporter,TaskPriority priority,List<string> tags)
        {
            TaskId = id;
            TaskName = taskName;
            TaskDescription = taskDesc;
            Assignee = assignee;
            Reporter = reporter;
            Status = TaskStatus.InProgress;
            createdAt=DateTime.Now;
            Priority = priority;
            Tags = tags;
        }
        public void ReAssign(User assignee)
        {
            if (assignee != null)
            {
                Assignee = assignee;
            }
        }
        public abstract void Complete();
        public virtual void UpdateStatus(TaskStatus newStatus)
        {
            if (!IsValidTransition(Status, newStatus))
            {
                Console.WriteLine($"Invalid status change from {Status} to {newStatus}");
                return;
            }

            Console.WriteLine($" Status changed from {Status} to {newStatus}");
            Status = newStatus;
        }
        public virtual void Display()
        {
            Console.WriteLine($"{TaskName}|{Status} |Assigned To:{Assignee}|Reported by: {Reporter}| Created At: {createdAt} | Priority: {Priority}|Tags: {string.Join(", ", Tags)}");
        }

        private bool IsValidTransition(TaskStatus current, TaskStatus next)
        {
            return (current, next) switch
            {
                (TaskStatus.Backlog, TaskStatus.InProgress) => true,
                (TaskStatus.InProgress, TaskStatus.Completed) => true,
                (TaskStatus.InProgress, TaskStatus.Blocked) => true,
                (TaskStatus.Blocked, TaskStatus.InProgress) => true,
                (_, TaskStatus.Cancelled) => true, // Allowing cancellation anytime
                _ => false
            };
        }
    }
}
