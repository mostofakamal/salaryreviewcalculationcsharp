using System;

namespace Salary_Review_Calculation.Functional
{
    using Salary_Review_Calculation.Calculator;
    using Salary_Review_Calculation.Common;
    using Salary_Review_Calculation.Generic;

    public class GenericReviewSystem : ReviewSystem
    {
        private Tree<EmployeeInfo> tree = new CompositeTree<EmployeeInfo>();

        public EmployeeInfo create(int id, String name, Role role, double salary, Score score)
        {
            return tree.createNode(new EmployeeInfoImpl(id, name, role, salary, score));
        }

        public void addSubordinate(EmployeeInfo parent, EmployeeInfo child)
        {
            tree.makeChild(parent, child);
        }

        public void removeSubordinate(EmployeeInfo parent, EmployeeInfo child)
        {
            tree.removeChild(parent, child);
        }

        public double calculateSalary(EmployeeInfo employee)
        {
            return newSalary(employee);
        }

        public double calculateGroupSalary(EmployeeInfo empWithSub)
        {
            return tree.fold(empWithSub, 0.0, e => newSalary(e), (a, b) => a + b);
        }

        public void print(EmployeeInfo emp)
        {
            tree.forEach(emp, Console.WriteLine);
        }

        public double flatRaise(double percentage, EmployeeInfo emp)
        {
            return tree.fold(emp, 0.0, e => flatIncrease(e, percentage), (a, b) => a + b);
        }

        private static Double flatIncrease(EmployeeInfo emp, Double percentage)
        {
            return emp.getSalary() * (1 + percentage);
        }

        private static Double newSalary(EmployeeInfo emp)
        {
            ReviewCalculator reviewCalculator = new ReviewCalculator(emp.getSalary(), emp.getScore(), emp.getRole().GetImpact());
            return reviewCalculator.calculate();
        }
    }
}