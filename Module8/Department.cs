using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Module8
{
    public class Department  // Департамент знает о себе и о людях, что в департаменте работают
    {
        private string departmentName;

        private DateTime dateCreation;

        public Department()
        {
        }

        public Department(string departmentName, DateTime dateCreation) : this()
        {
            this.departmentName = departmentName;

            this.dateCreation = dateCreation;
        }

        public List<Worker> Workers { get; set; } = new List<Worker>();

        public string DepartmentName
        { get { return departmentName; } set { departmentName = value; } }

        public DateTime DateCreation
        { get { return dateCreation; } set { dateCreation = value; } }

        public string Print()
        {
            return $" Наименование департамента {this.departmentName}, количество работников {this.Workers.Count}. Дата записи {this.dateCreation}  ";
        }
    }
}