namespace Salary_Review_Calculation
{
    using System;

    using Salary_Review_Calculation.Calculator;
    using Salary_Review_Calculation.Common;
    using Salary_Review_Calculation.Composite;
    using Salary_Review_Calculation.Functional;

    class Program
    {
        static void Main(string[] args)
        {
            testReviewSystem();
        }

        private static void testReviewSystem()
        {
            Score goodScore = new Score(8, 5, 9, 8, 9);
            Score badScore = new Score(5, 5, 5, 5, 6);

            ReviewSystem reviewSystem = new GenericReviewSystem();
           // ReviewSystem reviewSystem = new CefaloReviewSystem();
            Console.WriteLine(reviewSystem);
            EmployeeInfo cto = reviewSystem.create(1, "john the cto", Role.CTO, 100000, goodScore);

            EmployeeInfo pmJane = reviewSystem.create(2, "jane the pm", Role.PROJECTMANAGER, 80000, goodScore);
            EmployeeInfo pmJim = reviewSystem.create(3, "jim the pm", Role.PROJECTMANAGER, 90000, badScore);

            EmployeeInfo tlTim = reviewSystem.create(4, "tim the tl", Role.TEAMLEAD, 70000, badScore);
            EmployeeInfo tlTony = reviewSystem.create(5, "tony the tl", Role.TEAMLEAD, 70000, goodScore);
            EmployeeInfo tlTisha = reviewSystem.create(6, "tisha the tl", Role.TEAMLEAD, 60000, goodScore);

            EmployeeInfo devDon = reviewSystem.create(7, "don the dev", Role.DEVELOPER, 30000, goodScore);
            EmployeeInfo devDime = reviewSystem.create(8, "dime the dev", Role.DEVELOPER, 40000, goodScore);
            EmployeeInfo devDany = reviewSystem.create(9, "dany the dev", Role.DEVELOPER, 50000, badScore);
            EmployeeInfo devDina = reviewSystem.create(10, "dina the dev", Role.DEVELOPER, 60000, goodScore);
            EmployeeInfo devDilu = reviewSystem.create(11, "dilu the dev", Role.DEVELOPER, 40000, badScore);

            // Build hierarchy
            reviewSystem.addSubordinate(tlTim, devDon);
            reviewSystem.addSubordinate(tlTim, devDime);

            reviewSystem.addSubordinate(tlTony, devDany);
            reviewSystem.addSubordinate(tlTony, devDina);

            reviewSystem.addSubordinate(tlTisha, devDilu);

            reviewSystem.addSubordinate(pmJane, tlTim);
            reviewSystem.addSubordinate(pmJane, tlTony);
            reviewSystem.addSubordinate(pmJim, tlTisha);

            reviewSystem.addSubordinate(cto, pmJane);
            reviewSystem.addSubordinate(cto, pmJim);

            double ctoSalry = reviewSystem.calculateSalary(cto);
            Console.WriteLine($"ctoSalry = {ctoSalry}\n");

            double dinaSalry = reviewSystem.calculateSalary(devDina);
            Console.WriteLine($"dinaSalry = {dinaSalry}\n");
            double devGroupSalary = reviewSystem.calculateGroupSalary(devDina);
            Console.WriteLine($"devGroupSalary ={devGroupSalary}\n");

            double groupSalary = reviewSystem.calculateGroupSalary(cto);
            Console.WriteLine($"groupSalary = {groupSalary}\n");

            double withFlatIncrease = reviewSystem.flatRaise(0.05, cto);
            Console.WriteLine($"withFlatIncrease ={withFlatIncrease}\n");

            reviewSystem.print(cto);
        }
    }
}
