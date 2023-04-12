using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Module8.Models;
using Module8.Storage;

namespace Module8
{
    internal class Program
    {
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

            //App.Start();

            //JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions()
            //{
            //    WriteIndented = true,
            //    ReferenceHandler = ReferenceHandler.Preserve,
            //    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            //};
            string allCommands =
                " \n\t0-показать всех сотрудников," +
                " \n\t1-генератор сотрудников с департаментами," +
                " \n\t2-генератор департаметов, " +
                " \n\t3-удаление сотрудника по Guid," +
                " \n\t4-изменить ЗП сотрудника," +
                " \n\t5-удаление департамента," +
                " \n\t6-сохранение данные в json," +
                " \n\t7-загрузить данные из json," +
                " \n\t8-сортировка и печать сотрудников по возрасту," +
                " \n\t9-сортировка и печать сотрудников по ЗП и имени," +
                " \n\tвыход ";

            var workStorage = new WorkerStorage();

            var generator = new Generator();

            var depStorage = new DepartmentStorage();

            var sort = new Sort();

            var fileJson = new JsonFileWriterReader();

            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine(allCommands);
                int inputComand = IntFromConsole();

                switch (inputComand)
                {
                    case 0://показать всех сотрудников
                        if (workStorage.Workers.Count == 0)
                        {
                            Console.Write(" Нет сотрудников ");
                        }
                        var printWorkers = workStorage.PrintWorkers(workStorage.Workers);
                        Console.WriteLine(printWorkers);
                        break;

                    case 1://генератор сотрудников с департаментами

                        Console.Write("Кол-во сторудников: ");
                        int workersCountWDepart = IntFromConsole();

                        Console.Write("Кол-во департаментов: ");
                        int departCount = IntFromConsole();

                        var genWokers = generator.GenerateWorkersWithDepartments(workersCountWDepart, departCount);

                        workStorage.AddWorkers(genWokers);
                        depStorage.AddDepartments(generator.Departments);

                        Console.WriteLine("Сотрудники сгенерированы");

                        break;

                    case 2://генератор департаметов

                        Console.Write("Кол-во департаментов ");
                        int depCount = IntFromConsole();

                        var genDepartment = generator.GeneratingDepartments(depCount);

                        depStorage.AddDepartments(genDepartment);

                        Console.WriteLine("Департаметы успешно сгенерированы ");

                        break;

                    case 3://удаление сотрудника

                        Console.Write("Введи Guid сотрудника ");
                        Guid guidRemove;

                        bool guidFound = false;

                        while (!guidFound)
                        {
                            Console.Write("Введи Guid сотрудника: ");
                            guidFound = Guid.TryParse(Console.ReadLine(), out guidRemove);

                            if (!guidFound)
                            {
                                Console.WriteLine("Недопустимый идентификатор GUID");
                            }
                            else if (!workStorage.Workers.Any(w => w.Id == guidRemove))
                            {
                                Console.WriteLine("Сотрудник с таким GUID не найден. Попробуйте еще раз.");
                                guidFound = false;
                            }
                        }

                        break;

                    case 4://изменить ЗП сотрудника

                        bool salaryFound = false;

                        do
                        {
                            Console.Write("ЗП которую меняем: ");
                            int oldSalary = IntFromConsole();

                            foreach (Worker worker in workStorage.Workers)
                            {
                                if (worker.Salary == oldSalary)
                                {
                                    Console.Write("Новая ЗП: ");
                                    int newSalary = IntFromConsole();

                                    worker.Salary = newSalary;
                                    Console.WriteLine($"ЗП {oldSalary} успешно изменена на {newSalary}");
                                    salaryFound = true;
                                    break;
                                }
                            }

                            if (!salaryFound)
                            {
                                Console.WriteLine($"ЗП {oldSalary} не найдено. Попробуйте еще раз.");
                            }
                        } while (!salaryFound);

                        break;

                    case 5://удаление департамента

                        var test2 = depStorage.PrintDepName();
                        Console.WriteLine(test2);

                        string nameDep;
                        bool departmentExists = false;
                        do
                        {
                            Console.Write("Удаление департамента: ");
                            nameDep = Console.ReadLine();

                            if (depStorage.Departments.Any(d => d.DepartmentName == nameDep)) //  Any - используется для проверки,
                            {                                                                 //  есть ли хотя бы один элемент в последовательности
                                Console.WriteLine($"Департамент {nameDep} удален");           //  который удовлетворяет заданному условию
                            }
                            else
                            {
                                Console.WriteLine($"Департамент {nameDep} не найден. Попробуйте снова.");
                            }
                        } while (!departmentExists);

                        depStorage.RemoveDepartment(nameDep);
                        break;

                    case 6://сохранение в json

                        Console.Write("Название файла ");
                        var fileName = Console.ReadLine() + ".json";

                        //while (!File.Exists(fileName))
                        //{
                        //    Console.WriteLine($"Файл {fileName} не существует.");
                        //    Console.Write("Хотите создать новый файл с таким именем? (y/n): ");
                        //    var response = Console.ReadLine();
                        //    if (response == "y")
                        //    {
                        //        using (FileStream fs = File.Create(fileName))
                        //        {
                        //            Console.WriteLine($"Файл {fileName} успешно создан."); // что-то передать в консоль
                        //        }
                        //    }
                        //    else
                        //    {
                        //        Console.Write("Введите другое название файла: ");
                        //        fileName = Console.ReadLine();
                        //    }
                        //}

                        //var json = JsonSerializer.Serialize(workStorage.Workers, jsonSerializerOptions);
                        //File.WriteAllText(fileName, json, Encoding.UTF8);

                        break;

                    case 7://чтение из json

                        Console.Write("\nВведите имя файла: ");

                        string filePath = Console.ReadLine() + ".json";

                        fileJson.FileDeserialize(filePath);

                        //while (!File.Exists(filePath))
                        //{
                        //    Console.WriteLine($"Файл {filePath} не существует.\n Введите другое название файла: ");
                        //    filePath = Console.ReadLine() + ".json";
                        //}

                        //string textJson = File.ReadAllText(filePath);

                        //try
                        //{
                        //    var workers = JsonSerializer.Deserialize<List<Worker>>(textJson, jsonSerializerOptions);
                        //    workStorage.AddWorkers(workers);
                        //    Console.WriteLine($"Файл {filePath} успешно прочитан, данные загружены.");
                        //}
                        //catch (JsonException e)
                        //{
                        //    Console.WriteLine($"Ошибка: {e.Message}");
                        //}

                        //var textJsonOB = JsonSerializer.Deserialize<List<Worker>>(textJson);
                        //var jsont = JsonSerializer.Deserialize(textJson, jsonSerializerOptions);
                        //List<Worker> workers = JsonSerializer.Deserialize<List<Worker>>(textJson);
                        break;

                    case 8://сортировка сотрудников по возрасту

                        var sortWorkersAge = sort.SortByAge(workStorage.Workers);
                        var printSortByA = workStorage.PrintWorkers(sortWorkersAge);
                        Console.WriteLine(printSortByA);
                        break;

                    case 9://сортировка сотрудников по ЗП и имени

                        var sortWorkersSalaryName = sort.SortBySalaryByLastName(workStorage.Workers);
                        var printSortBySN = workStorage.PrintWorkers(sortWorkersSalaryName);
                        Console.WriteLine(printSortBySN); ;
                        break;

                    default:

                        Console.WriteLine("\nВыходим");
                        isWork = false;
                        break;
                }
            }
        }
    }
}