# TaskManager
Built with basic OOPs structure


Structure
TaskManager/
├── Program.cs
├── Models/
│   ├── TaskItem.cs
│   ├── TaskBug.cs
│   ├── TaskFeature.cs
│   ├── TaskStatus.cs
│   └── User.cs
├── Services/
│   └── TaskService.cs

                    +-----------------------------+
                       |         User                |
                       +-----------------------------+
                       | - Name: string              |
                       | - Email: string             |
                       +-----------------------------+
                       | + ToString(): string        |
                       +-----------------------------+

                       +-----------------------------+
                       |      TaskItem (abstract)    |  ◄────── Abstract Base
                       +-----------------------------+
                       | - Title: string (private)   |
                       | - Description: string       |
                       | - Reporter: User (private)  |
                       | - Assignee: User (private)  |
                       | - Status: TaskStatus (protected) |
                       | - CreatedAt: DateTime       |
                       +-----------------------------+
                       | + Reassign(user): void      |
                       | + UpdateDescription(): void |
                       | + Complete(): abstract void |
                       | + Display(): virtual void   |
                       +-----------------------------+
                                 ▲
                  ┌─────────────┴─────────────┐
                  │                           │
+-------------------------+       +-----------------------------+
|       TaskBug           |       |       TaskFeature           |
+-------------------------+       +-----------------------------+
| - Severity: string      |       | - DueDate: DateTime         |
+-------------------------+       +-----------------------------+
| + Complete(): override  |       | + Complete(): override      |
| + Display(): override   |       | + Display(): override       |
+-------------------------+       +-----------------------------+

                       +-----------------------------+
                       |       TaskService           |
                       +-----------------------------+
                       | - tasks: List<TaskItem>     |
                       +-----------------------------+
                       | + AddTask(task): void       |
                       | + CompleteTask(title): void |
                       | + ListTasks(): void         |
                       +-----------------------------+


Encapsulation Visualized
- (minus sign) means private
+ (plus sign) means public
# (hash) would mean protected

TaskItem.Assignee is private set →  Encapsulated

TaskItem.Complete() is abstract → Polymorphic

BugTask and FeatureTask inherit TaskItem → Inheritance

TaskItem is abstract → Abstraction
