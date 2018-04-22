using System;
using System.Collections.Generic;

namespace Salary_Review_Calculation.Composite
{
    using Calculator;
    using Common;

    public class CefaloReviewSystem : ReviewSystem
    {
        private Dictionary<int, Employee> empStore = new Dictionary<int, Employee>();


        public EmployeeInfo create(int id, String name, Role role, double salary, Score score)
        {
            Employee emp;
            if (role == Role.DEVELOPER)
            {
                emp = new EmployeeImpl(id, name, role, salary, score);
            }
            else
            {
                emp = new CompositeEmployeeHof(id, name, role, salary, score);
            }

            empStore.Add(id, emp);
            return emp;
        }



        public void addSubordinate(EmployeeInfo parent, EmployeeInfo child)
        {
            Employee composite = empStore[parent.getId()];
            Employee leaf = empStore[child.getId()];

            composite.add(leaf);
        }



        public void removeSubordinate(EmployeeInfo parent, EmployeeInfo child)
        {
            Employee composite = empStore[parent.getId()];
            Employee leaf = empStore[child.getId()];

            composite.remove(leaf);
        }



        public double calculateSalary(EmployeeInfo employee)
        {
            Employee storedEmployee = empStore[employee.getId()];
            return storedEmployee.calculateSalary();
        }



        public double calculateGroupSalary(EmployeeInfo empWithSub)
        {
            Employee storedEmployee = empStore[empWithSub.getId()];
            return storedEmployee.calculateGroupSalary();
        }



        public void print(EmployeeInfo emp)
        {
            Employee employee = empStore[emp.getId()];
            String print = employee.print();
            Console.WriteLine(print);
        }



        public double flatRaise(double percentage, EmployeeInfo empInfo)
        {
            Employee employee = empStore[empInfo.getId()];
            return employee.flatRaise(percentage);
        }
    }
}