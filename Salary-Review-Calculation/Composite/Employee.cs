using System;

namespace Salary_Review_Calculation.Composite
{
    using Salary_Review_Calculation.Common;

    public interface Employee : EmployeeInfo
    {
        void add(Employee employee);

        void remove(Employee employee);

        Employee getChild(int i);

        double calculateSalary();

        double calculateGroupSalary();

        String print();

        double flatRaise(double percentage);
    }
}
