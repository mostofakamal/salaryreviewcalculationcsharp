using System;

namespace Salary_Review_Calculation.Common
{
    using Salary_Review_Calculation.Calculator;

    public interface EmployeeInfo : Identity
    {
        String getName();

        double getSalary();

        Role getRole();

        Score getScore();
    }
}
