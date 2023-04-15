using Module8.Models;

namespace Module8;

public static class Generator
{
    /*
      Генератор хранит в себе список всяких данных чтобы рандомно генерировать Worker-ов
      Метод .Generate(int count) возвращает count воркеров... ТОЛЬКО этот метод публичный будет)
    */

    private static Random random = new Random();

    private static string[] names = new string[]
    {
      "Прохор",
      "Яков",
      "Юлий",
      "Афанасий",
      "Виль",
      "Остин",
      "Люций",
      "Матвей",
      "Владлен",
      "Тимофей",
    };

    private static string[] lastNames = new string[]
        {
        "Василенко",
        "Трофимов",
        "Дорофеев",
        "Калашников",
        "Поляков",
        "Дидовец",
        "Федоренко",
        "Архипов",
        "Лебедев",
        "Ширяев",
        };

    public static List<Worker> GeneratingWorkers(int count)
    {
        List<Worker> workers = new List<Worker>(count);

        for (int i = 1; i <= count; i++)
        {
            workers.Add(new Worker
            {
                Name = names[random.Next(names.Length)],
                LastName = lastNames[random.Next(lastNames.Length)],
                Age = random.Next(18, 61),
                Id = Guid.NewGuid(),
                Salary = random.NextDouble() * 5000,
                NumberOfProjects = random.Next(1, 6),
            });
        }

        return workers;
    }

    public static List<Department> GeneratingDepartments(int count)
    {
        List<Department> department = new List<Department>(count);

        for (int i = 1; i <= count; i++)
        {
            department.Add(new Department
            {
                DepartmentName = $"Отдел_{i}",
                DateCreation = DateTime.Now - new TimeSpan(days: random.Next(30), hours: 0, minutes: 0, seconds: 0),
            });
        }

        return department;
    }

    public static List<Department> Departments { get; set; }

    public static List<Worker> GenerateWorkersWithDepartments(int workerCount, int departmentCount)

    {
        var workers = GeneratingWorkers(workerCount);

        Departments = GeneratingDepartments(departmentCount);

        for (int i = 0; i < workers.Count; i++)
        {
            var index = random.Next(departmentCount);

            workers[i].Department = Departments[index];

            Departments[index].Workers.Add(workers[i]);
        }

        return workers;
    }
}