﻿using Module8.Models;
using System.Text;

namespace Module8;

public class DepartmentStorage
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

        foreach (var worker in dep.Workers)
        {
            worker.Department = null;
        }

        Departments.Remove(dep); // удаляет первый найденный
    }

    public string PrintDepName()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var item in Departments)
        {
            sb.AppendLine(item.DepartmentName);
        }
        return sb.ToString();
    }

    public IEnumerable<string> PrintDepartmentName()
    {
        foreach (var item in Departments)
        {
            yield return item.DepartmentName;
        }
    }
}