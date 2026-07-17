using System;



namespace TaskManagementSystem
{
    class Task
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string Status { get; set; }  

        public Task(int taskId, string taskName, string status = "Pending")
        {
            TaskId = taskId;
            TaskName = taskName;
            Status = status;
        }

        public override string ToString() =>
            $"Task {TaskId}  {TaskName,-20}  Status: {Status}";
    }

    
    class TaskNode
    {
        public Task Data { get; set; }
        public TaskNode Next { get; set; }

        public TaskNode(Task data)
        {
            Data = data;
            Next = null;
        }
    }

    class TaskLinkedList
    {
        private TaskNode head;

        public void AddTask(Task task)
        {
            TaskNode newNode = new TaskNode(task);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                TaskNode current = head;
                while (current.Next != null)
                    current = current.Next;
                current.Next = newNode;
            }
            Console.WriteLine($"Added: {task}");
        }
        public Task SearchById(int taskId)
        {
            TaskNode current = head;
            while (current != null)
            {
                if (current.Data.TaskId == taskId)
                    return current.Data;
                current = current.Next;
            }
            return null;
        }
        public void TraverseAll()
        {
            if (head == null) { Console.WriteLine("Task list is empty."); return; }
            Console.WriteLine("\n  Task List ");
            TaskNode current = head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
            
        }

        
        public bool DeleteTask(int taskId)
        {
            if (head == null) { Console.WriteLine("List is empty."); return false; }

            
            if (head.Data.TaskId == taskId)
            {
                Console.WriteLine($"Deleted: {head.Data}");
                head = head.Next;
                return true;
            }

            TaskNode previous = head;
            TaskNode current = head.Next;
            while (current != null)
            {
                if (current.Data.TaskId == taskId)
                {
                    Console.WriteLine($"Deleted: {current.Data}");
                    previous.Next = current.Next; 
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            Console.WriteLine($"Task ID {taskId} not found.");
            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TaskLinkedList taskList = new TaskLinkedList();

            taskList.AddTask(new Task(1, "Design Database Schema", "Done"));
            taskList.AddTask(new Task(2, "Build REST API",         "In Progress"));
            taskList.AddTask(new Task(3, "Write Unit Tests",       "Pending"));
            taskList.AddTask(new Task(4, "Deploy to Staging",      "Pending"));
            taskList.AddTask(new Task(5, "Code Review",            "Pending"));

            taskList.TraverseAll();

            Console.WriteLine("\n Search ");
            Task found = taskList.SearchById(3);
            Console.WriteLine(found != null ? $"Found: {found}" : "Task not found.");

            Console.WriteLine("\n Delete ");
            taskList.DeleteTask(1); 
            taskList.DeleteTask(3); 
            taskList.DeleteTask(99);

            taskList.TraverseAll();
        }
    }
}
