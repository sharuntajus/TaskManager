using TaskManager.Models;
using TaskManager.Services;

class Program {
    static void Main(string[] args) {

        var Tester = new User
        {
            UserName = "TesterMani",
            Email = "mani@tester.net"
        };
        var Developer = new User
        {
            UserName = "DevDany",
            Email = "dani@dev.net"
        };
        //Traditional way
        //var Tester = new User("TesterMani", "mani@tester.net");
        //var Developer = new User("DevDany", "dani@dev.net");

        var taskservice =new TaskService();

        var bug = new TaskBug(1, "Redirection Issue", "page redirects to not intended page", Tester, Developer, "Medium",TaskPriority.High, new List<string> { "redirection", "404Page" });
        var feature = new TaskFeature(10, "Revamp - CT1", "Revamp using raw OOPS", Tester, Developer, DateTime.Now.AddMonths(2), TaskPriority.Medium, new List<string> { "c#", "rev" });

        taskservice.AddTask(feature);
        taskservice.AddTask(bug);
        
        taskservice.ListTasks();

        taskservice.CompleteTask("Redirection Issue");


        taskservice.ListByTag("rev");
        taskservice.ListByPriority(TaskPriority.High);

        taskservice.ListTasks();
        Console.ReadLine();
    }
}