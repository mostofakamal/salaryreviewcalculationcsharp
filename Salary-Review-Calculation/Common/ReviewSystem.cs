using System;

namespace Salary_Review_Calculation.Common
{
    using Salary_Review_Calculation.Calculator;

    public interface ReviewSystem
    {
        EmployeeInfo create(int id, String name, Role role, double salary, Score score);
        void addSubordinate(EmployeeInfo parent, EmployeeInfo child);
        void removeSubordinate(EmployeeInfo parent, EmployeeInfo child);
        double calculateSalary(EmployeeInfo employee);
        double calculateGroupSalary(EmployeeInfo empWithSub);

        void print(EmployeeInfo cto);
        double flatRaise(double percentage, EmployeeInfo empInfo);
    }
}
