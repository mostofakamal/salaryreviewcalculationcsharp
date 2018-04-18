using System;

namespace Salary_Review_Calculation.Common
{
    using Salary_Review_Calculation.Calculator;

    public class EmployeeInfoImpl : EmployeeInfo
    {

        private int id;
        private String name;
        private double salary;
        private Role role;
        private Score score;

        public EmployeeInfoImpl(int id, String name, Role role, double salary, Score score)
        {
            this.id = id;
            this.name = name;
            this.salary = salary;
            this.role = role;
            this.score = score;
        }

        public String getName()
        {
            return name;
        }

        public double getSalary()
        {
            return salary;
        }

        public int getId()
        {
            return id;
        }


        public Role getRole()
        {
            return role;
        }

        public Score getScore()
        {
            return score;
        }

        public override string ToString()
        {
            return "EmployeeInfo{" +
                   "id=" + id +
                   ", name='" + name + '\'' +
                   ", role=" + role +
                   ", salary=" + salary +
                   '}';
        }
    }
}
