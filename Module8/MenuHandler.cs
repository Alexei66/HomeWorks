using Module8.Models;
using Module8.Storage;

namespace Module8;

public class MenuHandler
{
    private ConsoleWriter _consoleWriter; //это приватное поле класса JsonFileWriteRead
    private readonly WorkerStorage _workStorage;
    private readonly DepartmentStorage _depStorage;
    private readonly Sort _sort;
    private readonly JsonFileWriterReader _fileJson;

    public MenuHandler(ConsoleWriter consoleWriter, WorkerStorage workStorage, DepartmentStorage depStorage, Sort sort, JsonFileWriterReader fileJson) //это конструктор
    {
        _consoleWriter = consoleWriter; //тут мы присвоили параметр, который передали нашему приватному свойству)
        _workStorage = workStorage;
        _depStorage = depStorage;
        _sort = sort;
        _fileJson = fileJson;
    }

    public void HandleCommand(int inputComand)
    {
        switch ((MenuItem)inputComand)
        {
            case MenuItem.ShowAll:
                if (_workStorage.Workers.Count == 0)
                {
                    _consoleWriter.Print(" Нет сотрудников ");
                }
                var printWorkers = _workStorage.PrintWorkers(_workStorage.Workers);
                _consoleWriter.PrintLine(printWorkers);
                break;

            case MenuItem.GenWorkWithDep:

                _consoleWriter.Print("Кол-во сторудников: ");
                int workersCountWDepart = IntFromConsole();

                _consoleWriter.Print("Кол-во департаментов: ");
                int departCount = IntFromConsole();

                var genWokers = Generator.GenerateWorkersWithDepartments(workersCountWDepart, departCount);

                _workStorage.AddWorkers(genWokers);
                _depStorage.AddDepartments(Generator.Departments);

                _consoleWriter.PrintLine("Сотрудники сгенерированы");

                break;

            case MenuItem.GenDep:
                _consoleWriter.Print("Кол-во департаментов ");
                int depCount = IntFromConsole();

                var genDepartment = Generator.GeneratingDepartments(depCount);

                _depStorage.AddDepartments(genDepartment);

                _consoleWriter.PrintLine("Департаметы успешно сгенерированы ");
                break;

            case MenuItem.AddWork:
                var name = _consoleWriter.Read();
                var age = IntFromConsole();
                var lastName = _consoleWriter.Read();
                var neWWorker = new Worker()
                {
                    Name = name,
                    Age = age,
                    LastName = lastName,
                };
                _workStorage.AddWorker(neWWorker);
                break;

            case MenuItem.DelWorkById:
                _consoleWriter.Print("Введи Guid сотрудника ");
                Guid guidRemove;

                bool guidFound = false;

                while (!guidFound)
                {
                    _consoleWriter.Print("Введи Guid сотрудника: ");
                    guidFound = Guid.TryParse(_consoleWriter.Read(), out guidRemove);

                    if (!guidFound)
                    {
                        _consoleWriter.PrintLine("Недопустимый идентификатор GUID");
                        guidFound = false;
                    }
                    else if (!_workStorage.Workers.Any(w => w.Id == guidRemove))
                    {
                        _consoleWriter.PrintLine("Сотрудник с таким GUID не найден. Попробуйте еще раз.");
                        guidFound = false;
                    }
                    else
                    {
                        _workStorage.RemoveWorker(guidRemove);
                        _consoleWriter.PrintLine("Сотрудник удален");
                    }
                }
                break;

            case MenuItem.ChangeWorkSalary:
                bool salaryFound = false;

                do
                {
                    _consoleWriter.Print("ЗП которую меняем: ");
                    int oldSalary = IntFromConsole();

                    foreach (Worker worker in _workStorage.Workers)
                    {
                        if (worker.Salary == oldSalary)
                        {
                            _consoleWriter.Print("Новая ЗП: ");
                            int newSalary = IntFromConsole();

                            worker.Salary = newSalary;
                            _consoleWriter.PrintLine($"ЗП {oldSalary} успешно изменена на {newSalary}");
                            salaryFound = true;
                            break;
                        }
                    }

                    if (!salaryFound)
                    {
                        _consoleWriter.PrintLine($"ЗП {oldSalary} не найдено. Попробуйте еще раз.");
                    }
                } while (!salaryFound);
                break;

            case MenuItem.DelDep:
                var test2 = _depStorage.PrintDepName();
                _consoleWriter.PrintLine(test2);

                string nameDep;
                bool departmentExists = false;

                do
                {
                    _consoleWriter.Print("Удаление департамента: ");
                    nameDep = _consoleWriter.Read();

                    departmentExists = _depStorage.Departments.Any(d => d.DepartmentName == nameDep);    //  Any - используется для проверки,
                                                                                                         //  есть ли хотя бы один элемент в последовательности
                    if (departmentExists)                                                               //  который удовлетворяет заданному условию
                    {
                        _consoleWriter.PrintLine($"Департамент {nameDep} удален");
                        _depStorage.RemoveDepartment(nameDep);
                    }
                    else
                    {
                        _consoleWriter.PrintLine($"Департамент {nameDep} не найден. Попробуйте снова.");
                    }
                } while (!departmentExists);
                break;

            case MenuItem.SaveJson:
                _consoleWriter.Print("Название файла ");
                var fileName = _consoleWriter.Read() + ".json";

                _fileJson.FileSerialize(fileName, _workStorage.Workers);
                break;

            case MenuItem.LoadJson:
                _consoleWriter.Print("\nВведите имя файла: ");

                string filePath = _consoleWriter.Read() + ".json";

                var tes = _fileJson.FileDeserialize(filePath);
                _workStorage.AddWorkers(tes);
                break;

            case MenuItem.SortByAgeAndPrint:
                var sortWorkersAge = _sort.SortByAge(_workStorage.Workers);
                var printSortByA = _workStorage.PrintWorkers(sortWorkersAge);
                _consoleWriter.PrintLine(printSortByA);
                break;

            case MenuItem.SortBySalaryAndNameAndPrint:
                var sortWorkersSalaryName = _sort.SortBySalaryByLastName(_workStorage.Workers);
                var printSortBySN = _workStorage.PrintWorkers(sortWorkersSalaryName);
                _consoleWriter.PrintLine(printSortBySN);
                break;

            case MenuItem.Exit:
                _consoleWriter.PrintLine("\nВыходим");
                break;

            case MenuItem.Test:

                var depOstin = _workStorage.Workers.Where(w => w.Salary >= 4050 && w.Name == "Остин" && w.NumberOfProjects > 3 && w.LastName == "Ширяев")
                                                   .Select(w => w.Department.DepartmentName)
                                                   .Distinct()              //выбирает уникальные значения из коллекции
                                                   .Order()
                                                   .ToList();

                int count = depOstin.Count;

                depOstin.ForEach(w => Console.WriteLine(w));
                _consoleWriter.PrintLine(count.ToString());
                break;

            default:
                throw new Exception($"{inputComand} не найден");
        }
    }

    public int IntFromConsole()
    {
        int correctValue;

        while (!int.TryParse(_consoleWriter.Read(), out correctValue) || correctValue < 0)
        {
            _consoleWriter.PrintLine("Неверный ввод. Пожалуйста, введите целое число больше 0.");
        }
        return correctValue;
    }
}