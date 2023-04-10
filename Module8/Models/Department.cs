using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Module8.Models;

public class Department  // Департамент знает о себе и о людях, что в департаменте работают
{
    private string departmentName;

    private DateTime dateCreation;

    public Department()
    {
        Workers = new List<Worker>();
    }

    public Department(string departmentName, DateTime dateCreation) : this()
    {
        this.departmentName = departmentName;

        this.dateCreation = dateCreation;
    }

    public List<Worker> Workers { get; set; }

    public string DepartmentName
    { get { return departmentName; } set { departmentName = value; } }

    public DateTime DateCreation
    { get { return dateCreation; } set { dateCreation = value; } }

    public string Print()
    {
        return $" Наименование департамента {departmentName}, количество работников {Workers.Count}. Дата записи {dateCreation}  ";
    }

    public void AddWorker(Worker newWorker)
    {
        Workers.Add(newWorker);
        newWorker.Department = this;
    }

    public void RemoveWorker(Worker worker)
    {
        Workers.Remove(worker);
    }
}