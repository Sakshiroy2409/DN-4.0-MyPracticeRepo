using System;

public class Task
{
    public int TaskId;
    public string TaskName;
    public string Status;

    public Task(int taskId, string taskName, string status)
    {
        TaskId = taskId;
        TaskName = taskName;
        Status = status;
    }

    public void Display()
    {
        Console.WriteLine($"ID: {TaskId}, Name: {TaskName}, Status: {Status}");
    }
}

public class TaskNode
{
    public Task Task;
    public TaskNode Next;

    public TaskNode(Task task)
    {
        Task = task;
        Next = null;
    }
}

public class TaskLinkedList
{
    private TaskNode head;

    
    public void AddTask(Task task)
    {
        TaskNode newNode = new TaskNode(task);

        if (head == null)
        {
            head = newNode;
            return;
        }

        TaskNode current = head;
        while (current.Next != null)
        {
            current = current.Next;
        }
        current.Next = newNode;
    }

    
    public void TraverseTasks()
    {
        if (head == null)
        {
            Console.WriteLine("No tasks available.");
            return;
        }

        TaskNode current = head;
        while (current != null)
        {
            current.Task.Display();
            current = current.Next;
        }
    }

    
    public void SearchTask(int taskId)
    {
        TaskNode current = head;
        while (current != null)
        {
            if (current.Task.TaskId == taskId)
            {
                Console.WriteLine("Task found:");
                current.Task.Display();
                return;
            }
            current = current.Next;
        }
        Console.WriteLine("Task not found.");
    }

    
    public void DeleteTask(int taskId)
    {
        if (head == null)
        {
            Console.WriteLine("List is empty.");
            return;
        }

        if (head.Task.TaskId == taskId)
        {
            head = head.Next;
            Console.WriteLine("Task deleted.");
            return;
        }

        TaskNode current = head;
        while (current.Next != null && current.Next.Task.TaskId != taskId)
        {
            current = current.Next;
        }

        if (current.Next == null)
        {
            Console.WriteLine("Task not found.");
        }
        else
        {
            current.Next = current.Next.Next;
            Console.WriteLine("Task deleted.");
        }
    }
}

class Program
{
    static void Main()
    {
        TaskLinkedList taskList = new TaskLinkedList();

        
        taskList.AddTask(new Task(1, "Design Database", "Pending"));
        taskList.AddTask(new Task(2, "Develop UI", "In Progress"));
        taskList.AddTask(new Task(3, "Write Tests", "Pending"));

        Console.WriteLine("All Tasks:");
        taskList.TraverseTasks();

        Console.WriteLine("\nSearch for Task ID 2:");
        taskList.SearchTask(2);

        Console.WriteLine("\nDelete Task ID 1:");
        taskList.DeleteTask(1);

        Console.WriteLine("\nTasks After Deletion:");
        taskList.TraverseTasks();
    }
}