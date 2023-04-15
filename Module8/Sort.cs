using Module8.Models;

namespace Module8;

public class Sort
{
    private static void EmptyWorker(List<Worker> workers)
    {
        if (workers.Count == 0)
        {
            throw new Exception("\nНет сотрудников для сортировки");
        }
    }

    public List<Worker> SortBySalaryByLastName(List<Worker> workers)
    {
        EmptyWorker(workers);
        var workerList = workers
            .OrderBy(w => w.Salary)
            .ThenBy(w => w.LastName)
            .ToList();

        return workerList;
    }

    public List<Worker> SortByAge(List<Worker> workers)
    {
        EmptyWorker(workers);
        var workerList = workers
            .OrderBy(w => w.Age).ToList();

        return workerList;
    }

    public List<Worker> SortByAgeBySalaryByDepartment(List<Worker> workers)
    {
        EmptyWorker(workers);
        var workerList = workers
            .OrderBy(w => w.Age)
            .ThenBy(w => w.Salary)
            .ThenBy(w => w.Department)
            .ToList();

        return workerList;
    }
}