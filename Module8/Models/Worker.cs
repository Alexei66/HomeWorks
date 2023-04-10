using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module8.Models
{
    public class Worker  // Worker знает только про себя... и департамент, к которому относится
    {
        private string name;
        private string lastName;
        private int age;
        private Guid id = Guid.NewGuid();
        private int salary;
        private int numberOfProjects;
        private Department department;

        public Worker()
        {
        }

        //снипеты

        public Worker(Guid id, string name, string lastName, int age, int salary, int numberOfProjects, Department departmentWorker)
        {
            this.name = name;
            this.lastName = lastName;
            this.age = age;
            this.id = id;
            this.salary = salary;
            this.numberOfProjects = numberOfProjects;
            department = departmentWorker;
        }

        public string Name
        { get { return name; } set { name = value; } }

        public string LastName
        { get { return lastName; } set { lastName = value; } }

        public int Age
        { get { return age; } set { age = value; } }

        public Guid Id
        { get { return id; } set { id = value; } }

        public int Salary
        { get { return salary; } set { salary = value; } }

        public int NumberOfProjects
        { get { return numberOfProjects; } set { numberOfProjects = value; } }

        public Department Department
        { get { return department; } set { department = value; } }

        public string Print()
        {
            var person = $"{id}. Я {lastName} {name}. Мне {age} лет. ЗП {salary} проектов {numberOfProjects}";

            if (Department == null) return $"{person}  без отдела";

            return $"{person}  из {department?.DepartmentName} ";
        }
    }
}