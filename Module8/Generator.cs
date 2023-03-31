using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module8
{
    public class Generator
    {
        /*
          Генератор хранит в себе список всяких данных чтобы рандомно генерировать Worker-ов
          Метод .Generate(int count) возвращает count воркеров... ТОЛЬКО этот метод публичный будет)
        */

        private static Random random = new Random();

        public List<Worker> GeneratingWorkers(int count)
        {
            List<Worker> workers = new List<Worker>(count);

            for (int i = 1; i <= count; i++)
            {
                int age = random.Next(18, 61);
                workers.Add(new Worker
                {
                    Name = $"Имя_{i}",
                    LastName = $"Фамилия_{i}",
                    Age = age,
                    Id = Guid.NewGuid(),
                    Salary = 1000 * age,
                    NumberOfProjects = random.Next(1, 6),
                });
            }

            return workers;
        }

        public List<Department> GeneratingDepartments(int count)
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

        // Но можно сделать ведь и 3 метод, который будет создавать людей, отделы... и ЭТИХ людей рандомно пихать по ЭТИМ отделам)
        public List<Department> Departments { get; set; }

        public List<Worker> GenerateWorkersWithDepartments(int workerCount, int departmentCount)

        {
            var workers = GeneratingWorkers(workerCount);

            Departments = GeneratingDepartments(departmentCount);

            for (int i = 0; i < workers.Count; i++)
            {
                var index = random.Next(departmentCount);

                workers[i].DepartmentWorker = Departments[index];

                Departments[index].Workers.Add(workers[i]);
            }

            return workers;
        }
    }
}