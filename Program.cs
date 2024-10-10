using System.Linq;
using System;
using System.Diagnostics.Metrics;

class Task
{
    private DateTime dateStart;
    private DateTime dateFinish;
    private string description = "";
    public DateTime DateFinish
    {
        get
        {
            return dateFinish;
        }
    }
    public Task(DateTime dateStart, DateTime dateFinish, string description)
    {
        this.dateStart = dateStart;
        this.dateFinish = dateFinish;
        this.description = description;
    }
    public void info()
    {
        Console.WriteLine($"Самое позднее занятие");
        Console.WriteLine($"Название - {description}");
        Console.WriteLine($"Время начала - {dateStart}");
        Console.WriteLine($"Время окончания - {dateFinish}");
    }
}

class RKIS
{
    static void Main()
    {
        int DescriptionCounter = 0;
        List<Task> task = new List<Task>();
        while (true)
        {
            Console.WriteLine("\nВведите число 0, что бы завершить программу");
            Console.WriteLine("Введите число 1, что бы ввести название, время начала и окончания занятия");
            Console.WriteLine("Введите число 2, что бы вывести название");
            int number = int.Parse(Console.ReadLine()!);
            switch (number)
            {
                case 0:
                    return;
                case 1:
                    if (DescriptionCounter == 5)
                    {
                        Console.WriteLine("\nБольше не возможно добавить пользователей");
                        break;
                    }
                    Console.Write("\nВведите название: ");
                    string Description = Console.ReadLine()!;
                    Console.Write("Введите время начала занятия: ");
                    DateTime DateStart = Convert.ToDateTime(Console.ReadLine()!);
                    Console.Write("Введите время окончания занятия: ");
                    DateTime DateFinish = Convert.ToDateTime(Console.ReadLine()!);
                    Task tasks = new Task(DateStart, DateFinish, Description);
                    task.Add(tasks);
                    DescriptionCounter ++;
                    break;
                case 2:
                    var selectTask =  task.OrderByDescending(t => t.DateFinish).First(); 
                    selectTask.info();
                    break;
            }
        }
    }
}
