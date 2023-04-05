using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module8
{
    internal class Sort
    {
        public List<Worker> SortBuSalaryByLastName(List<Worker> workers)
        {
            var workerList = workers
                .OrderBy(w => w.Salary)
                .ThenBy(w => w.LastName)
                .ToList();

            return workerList;
        }

        public List<Worker> SortBuAge(List<Worker> workers)
        {
            var workerList = workers
                .OrderBy(w => w.Age).ToList();

            return workerList;
        }

        public List<Worker> SortByAgeBuSalaryByDepartment(List<Worker> workers)
        {
            var workerList = workers
                .OrderBy(w => w.Age)
                .ThenBy(w => w.Salary)
                .ThenBy(w => w.Department)
                .ToList();

            return workerList;
        }
    }
}