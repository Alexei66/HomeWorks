using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Module8
{
    internal class Program
    {
        private static void PrintList(List<Worker> listWorkers)
        {
            Console.WriteLine();
            foreach (var worker in listWorkers)
            {
                Console.WriteLine(worker.Print());
            }
        }

        private static int IntFromConsole()
        {
            int correctValue;

            while (!int.TryParse(Console.ReadLine(), out correctValue) && correctValue > 0)
            {
                Console.WriteLine("Неверный ввод. Пожалуйста, введите целое число больше 0.");
            }
            return correctValue;
        }

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

            string allCommands =
                " \n0-показать всех сотрудников," +
                " \n1-генератор сотрудников с департаментами," +
                " \n2-генератор сотрудников, " +
                " \n3-удаление сотрудника," +
                " \n4-изменить имя сотрудника," +
                " \n5-удаление департамента," +
                " \n6-сохранение в json," +
                " \n7-чтение из json," +
                " \n8-сортировка и печать сотрудников по возрасту," +
                " \n9-сортировка и печать сотрудников по ЗП и имени," +
                " \nвыход ";

            var workStorage = new WorkerStorage();

            var generator = new Generator();

            var depStorage = new DepartmentStorage();

            var sort = new Sort();

            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine(allCommands);
                int inputComand = IntFromConsole();

                switch (inputComand)
                {
                    case 0://показать всех сотрудников
                        if (workStorage.Workers == null)
                        {
                            Console.Write(" Нет сотрудников ");
                        }
                        PrintList(workStorage.Workers);
                        break;

                    case 1://генератор сотрудников с департаментами

                        Console.Write("Кол-во сторудников: ");
                        int workersCountWDepart = IntFromConsole();

                        Console.Write("Кол-во департаментов: ");
                        int departCount = IntFromConsole();

                        var genWokers = generator.GenerateWorkersWithDepartments(workersCountWDepart, departCount);
                        workStorage.AddWorkers(genWokers);

                        break;

                    case 2://генератор департаметов

                        Console.WriteLine("Кол-во департаментов");
                        int depCount = IntFromConsole();

                        var genDepartment = generator.GeneratingDepartments(depCount).FirstOrDefault();

                        depStorage.AddDepartment(genDepartment);

                        break;

                    case 3://удаление сотрудника

                        Console.Write("Guid будет удален");
                        Guid guidRemove;

                        while (!Guid.TryParse(Console.ReadLine(), out guidRemove))
                        {
                            Console.WriteLine("Недопустимый идентификатор GUID");
                        }

                        workStorage.RemoveWorker(guidRemove);
                        break;

                    case 4://изменить имя сотрудника

                        break;

                    case 5://удаление департамента

                        Console.WriteLine("");
                        var nameDep = Console.ReadLine();

                        depStorage.RemoveDepartment(nameDep);

                        break;

                    case 6://сохранение в json

                        Console.Write("Название файла");
                        var fileName = Console.ReadLine();

                        while (!File.Exists(fileName))
                        {
                            Console.WriteLine($"Файл {fileName} не существует. .");
                            fileName = Console.ReadLine();
                        }

                        JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions()
                        {
                            WriteIndented = true,
                            ReferenceHandler = ReferenceHandler.Preserve,
                        };
                        JsonSerializer.Serialize(workStorage.Workers, jsonSerializerOptions);
                        break;

                    case 7://чтение из json

                        Console.WriteLine("Название файла");

                        var filePath = Console.ReadLine();

                        try
                        {
                            JsonSerializerOptions options = new JsonSerializerOptions();

                            var jsonString = File.ReadAllText(filePath);

                            var texts = JsonSerializer.Deserialize<List<Worker>>(jsonString);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"An error occurred while reading from file {filePath}: {ex.Message}");
                        }

                        break;

                    case 8://сортировка сотрудников по возрасту

                        var sortWorkersAge = sort.SortBuAge(workStorage.Workers);
                        PrintList(sortWorkersAge);
                        break;

                    case 9://сортировка сотрудников по ЗП и имени

                        var sortWorkersSalaryName = sort.SortBuSalaryByLastName(workStorage.Workers);

                        break;

                    default:

                        Console.WriteLine("Выходим");
                        isWork = false;
                        break;
                }
            }

            //var workers = gen.GenerateWorkersWithDepartments(21, 5);
            //var depart = gen.Departments;

            //PrintList(workers);

            //Console.WriteLine();
            //Console.WriteLine();

            //var sortWorkers = sort.SortByAgeBuSalaryByDepartment(workers);
            //PrintList(sortWorkers);
            //var dep = generator.GeneratingDepartments(1).FirstOrDefault();

            //depStorage.AddDepartment(dep);
            //var newWorkers = new List<Worker>
            //{
            //    new Worker(Guid.NewGuid(),"имя1","фамилия1",25,2500,2,dep),
            //    new Worker(Guid.NewGuid(),"имя2","фамилия2",25,2500,2,dep)
            //};

            //workStorage.AddWorkers(newWorkers);
            //dep.AddWorker(newWorkers[0]);
            //dep.AddWorker(newWorkers[1]);

            //PrintList(workStorage.Workers);

            //depStorage.RemoveDepartment(dep.DepartmentName);

            //PrintList(workStorage.Workers);

            //workStorage.RemoveWorker(newWorkers[0].Id);
            //PrintList(workStorage.Workers);
            //var worker = new Worker(Guid.NewGuid(), "Фамилия3", "Имя3", 35, 3500, 4, new Department("Отдел3", DateTime.Now));

            //JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions()
            //{
            //    WriteIndented = true,
            //    ReferenceHandler = ReferenceHandler.Preserve,
            //};
            //var text = JsonSerializer.Serialize(worker, jsonSerializerOptions); // настроить JsonSerializerOptions
            //Console.WriteLine(text);
        }
    }
}