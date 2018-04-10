using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlaryReviewCalculationCSharp.Calculator
{
    public class ReviewCalculator
    {
        public Impact Impact { get; set; }
        public double Salary { get; set; }
        public Score Score { get; set; }

        public double Calculate()
        {
            double result = Salary;
            result += CountBaseScore();
            result += CountDisciplineScore();
            result += CountProblemSolvingScore();
            result += CountLeadershipScore();
            result += CountCommunicationScore();
            result += CountExperienceScore();

            return result;
        }

        private double CountBaseScore()
        {
            return Salary * 0.05;
        }

        private double CountDisciplineScore()
        {
            return Salary * (Score.Decipline / 10) * Impact.DisciplineImpact;
        }

        private double CountProblemSolvingScore()
        {
            return Salary * (Score.ProblemSolving / 10) * Impact.ProblemSolvingImpact;
        }

        private double CountLeadershipScore()
        {
            return Salary * (Score.LeaderShip / 10) * Impact.LeadershipImpact;
        }

        private double CountCommunicationScore()
        {
            return Salary * (Score.Communication / 10) * Impact.CommunicationImpact;
        }

        private double CountExperienceScore()
        {
            return Salary * (Score.YearsOfExperience / 10) * Impact.ExperienceImpact;
        }
    }
}
