using System;
using System.Collections.Generic;

namespace Salary_Review_Calculation.Composite
{
    using System.Linq;

    using Salary_Review_Calculation.Calculator;

    public class CompositeEmployeeHof : AbstractEmployee
    {
        private List<Employee> employees = new List<Employee>();

        public CompositeEmployeeHof(int id, String name, Role role, double salary, Score score) : base(id, name, role, salary, score)
        {
        }

        public override void add(Employee employee)
        {
            employees.Add(employee);
        }

        public override Employee getChild(int i)
        {
            return employees.Single(e => e.getId() == i);
        }

        public override double calculateGroupSalary()
        {
            return fold(calculateSalary(), emp => emp.calculateGroupSalary(), (a, b) => a + b);
        }

        public override double flatRaise(double percentage)
        {
            return fold(base.flatRaise(percentage), e => e.flatRaise(percentage), (a, b) => a + b);
        }


        public override String print()
        {
            return fold(base.print(), emp => emp.print(), (s1, s2) => s1 + "\n" + s2);
        }

        private T fold<T>(
            T initialValue,
            Func<Employee, T> iteration,
            Func<T, T, T> combiner)
        {
            T result = initialValue;
            foreach (Employee emp in employees)
            {
                T val = iteration(emp);
                result = combiner(result, val);
            }
            return result;
        }

        public override void remove(Employee employee)
        {
            //todo this is not the correct way, since it may remove an employee with his subordinates, which we don't want
            employees.Remove(employee);
        }
    }
}
