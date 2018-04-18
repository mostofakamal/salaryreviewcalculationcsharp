using System;

namespace Salary_Review_Calculation.Composite
{
    using Salary_Review_Calculation.Calculator;

    public abstract class AbstractEmployee : Employee
    {
        private int id;
        private String name;
        private double salary;
        private Role role;
        private Score score;

        protected AbstractEmployee(int id, String name, Role role, double salary, Score score)
        {
            this.id = id;
            this.name = name;
            this.salary = salary;
            this.role = role;
            this.score = score;
        }

        public abstract void add(Employee employee);


        public abstract void remove(Employee employee);


        public abstract Employee getChild(int i);
       

        public double calculateSalary()
        {
            ReviewCalculator reviewCalculator = new ReviewCalculator(salary, score, role.GetImpact());
            return reviewCalculator.calculate();
        }

        public abstract double calculateGroupSalary();

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