using System;

namespace Salary_Review_Calculation.Composite
{
    using Salary_Review_Calculation.Calculator;

    /// <summary>
    /// The developer.
    /// </summary>
    public class Developer : AbstractEmployee
    {
        public Developer(int id, String name, Role role, double salary, Score score) : base(id, name, role, salary, score)
        {
        }

        public override void add(Employee employee)
        {
            //this is leaf node so this method is not applicable to this class.
        }

        public override Employee getChild(int i)
        {
            //this is leaf node so this method is not applicable to this class.
            return null;
        }

        public override double calculateGroupSalary()
        {
            return calculateSalary();
        }

        public override void remove(Employee employee)
        {
            //this is leaf node so this method is not applicable to this class.
        }
    }
}