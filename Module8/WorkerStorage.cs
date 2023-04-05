using Module8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module8
{
    internal class WorkerStorage
    {
        public List<Worker> Workers { get; set; }

        public WorkerStorage()
        {
            Workers = new List<Worker>();
        }

        public void AddWorkers(List<Worker> newWorkers)
        {
            Workers.AddRange(newWorkers);
        }

        public void InsertRangeWorkers(int index, List<Worker> newWorkers)
        {
            Workers.InsertRange(index, newWorkers);
        }

        public void RemoveWorker(Guid workerId)
        {
            var worker = Workers.FirstOrDefault(w => w.Id == workerId);
            Workers.Remove(worker); // удаляет первый найденный Id
            worker.Department.RemoveWorker(worker);
        }

        //public void EditWorker(Guid id, int age)
        //{
        //}

        //public void UpdateWorker(Guid id, int salary)
        //{
        //}

        //public void EditWorker(Guid id, int age, int salary)
        //{
        //}

        //public void EditWorker(Guid id, int age, int salary, int numberOfProjects)
        //{
        //}
    }
}