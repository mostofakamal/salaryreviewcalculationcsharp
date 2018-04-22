using System;

namespace Salary_Review_Calculation.Composite
{
    using Calculator;

    public class EmployeeImpl : Employee
    {
        private int id;
        private String name;
        private double salary;
        private Role role;
        private Score score;

        public EmployeeImpl(int id, String name, Role role, double salary, Score score)
        {
            this.id = id;
            this.name = name;
            this.salary = salary;
            this.role = role;
            this.score = score;
        }

        public void add(Employee employee)
        {
           //this is leaf node so this method is not applicable to this class.

        }


        public void remove(Employee employee)
        {
            //this is leaf node so this method is not applicable to this class.
        }


        public Employee getChild(int i)
        {
            //this is leaf node so this method is not applicable to this class.
             return null;
        }
       

        public double calculateSalary()
        {
            ReviewCalculator reviewCalculator = new ReviewCalculator(salary, score, role.GetImpact());
            return reviewCalculator.calculate();
        }

        public double calculateGroupSalary()
        {
            return calculateSalary();
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

        public String toString()
        {
            return "EmployeeInfo{" +
                   "id=" + id +
                   ", name='" + name + '\'' +
                   ", role=" + role +
                   ", salary=" + salary +
                   '}';
        }

        public virtual String print()
        {
            return toString();
        }

        public virtual double flatRaise(double percentage)
        {
            return salary * (1.0 + percentage);
        }
    }
}