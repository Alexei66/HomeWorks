﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module8;

internal class DepartmentStorage
{
    public List<Department> Departments { get; set; }

    public DepartmentStorage()
    {
        Departments = new List<Department>();
    }

    public void AddDepartments(List<Department> newDepartments)
    {
        Departments.AddRange(newDepartments);
    }

    public void AddDepartment(Department newDepartment)
    {
        Departments.Add(newDepartment);
    }

    public void InsertRangeDepartments(int index, List<Department> newDepartments)
    {
        Departments.InsertRange(index, newDepartments);
    }

    public void RemoveDepartment(string departmentName)
    {
        var dep = Departments.FirstOrDefault(w => w.DepartmentName == departmentName);
        //dep.Workers.ForEach(w => w.Department = null);
        foreach (var worker in dep.Workers)
        {
            worker.Department = null;
        }

        Departments.Remove(dep); // удаляет первый найденный
    }
}