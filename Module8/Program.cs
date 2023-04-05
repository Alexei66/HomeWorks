using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Module8
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /*
            Создать прототип информационной системы, в которой есть возможность работать со структурой организации
            В структуре присутствуют департаменты и сотрудники

            Каждый департамент может содержать не более 1_000_000 сотрудников.

            У каждого департамента есть поля: наименование, дата создания,
            количество сотрудников числящихся в нём (можно добавить свои пожелания)

            У каждого сотрудника есть поля: Фамилия, Имя, Возраст, департамент в котором он числится,
            уникальный номер, размер оплаты труда, количество закрепленным за ним проектов.

            должна быть возможность
            /// - импорта и экспорта всей информации в xml и json
            /// Добавление, удаление, редактирование сотрудников и департаментов
             */

            var gen = new Generator();
            //var workers = gen.GenerateWorkersWithDepartments(21, 5);
            //var depart = gen.Departments;

            //PrintList(workers);

            //Console.WriteLine();
            //Console.WriteLine();

            //var sort = new Sort();
            //var sortWorkers = sort.SortByAgeBuSalaryByDepartment(workers);
            //PrintList(sortWorkers);
            var dep = gen.GeneratingDepartments(1).FirstOrDefault();

            var workStor = new WorkerStorage();
            var depStor = new DepartmentStorage();
            depStor.AddDepartment(dep);
            var newWorkers = new List<Worker>
            {
                new Worker(Guid.NewGuid(),"имя1","фамилия1",25,2500,2,dep),
                new Worker(Guid.NewGuid(),"имя2","фамилия2",25,2500,2,dep)
            };

            workStor.AddWorkers(newWorkers);
            dep.AddWorker(newWorkers[0]);
            dep.AddWorker(newWorkers[1]);

            PrintList(workStor.Workers);

            depStor.RemoveDepartment(dep.DepartmentName);

            PrintList(workStor.Workers);

            //workStor.RemoveWorker(newWorkers[0].Id);
            //PrintList(workStor.Workers);
            //var worker = new Worker(Guid.NewGuid(), "Фамилия3", "Имя3", 35, 3500, 4, new Department("Отдел3", DateTime.Now));

            //JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions()
            //{
            //    WriteIndented = true,
            //    ReferenceHandler = ReferenceHandler.Preserve,
            //};
            //var text = JsonSerializer.Serialize(workers, jsonSerializerOptions); // настроить JsonSerializerOptions
            //Console.WriteLine(text);
        }

        private static void PrintList(List<Worker> workers)
        {
            Console.WriteLine();
            foreach (var worker in workers)
            {
                Console.WriteLine(worker.Print());
            }
        }
    }
}