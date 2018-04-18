using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary_Review_Calculation.Calculator
{
    public class ReviewCalculator
    {

        private readonly Impact impact;
        private readonly double salary;
        private readonly Score score;

        public ReviewCalculator(double salary, Score score, Impact impact)
        {
            this.salary = salary;
            this.score = score;
            this.impact = impact;
        }

        public double calculate()
        {

            double result = this.salary;
            result += countBaseScore();
            result += countDisciplineScore();
            result += countProblemSolvingScore();
            result += countLeadershipScore();
            result += countCommunicationScore();
            result += countExperienceScore();

            return result;
        }

        private double countBaseScore()
        {
            return this.salary * 0.05;
        }

        private double countDisciplineScore()
        {
            return salary * (score.getDecipline() / 10) * impact.getDisciplineImpact();
        }

        private double countProblemSolvingScore()
        {
            return salary * (score.getProblemSolving() / 10) * impact.getProblemSolvingImpact();
        }

        private double countLeadershipScore()
        {
            return salary * (score.getLeaderShip() / 10) * impact.getLeadershipImpact();
        }

        private double countCommunicationScore()
        {
            return salary * (score.getCommunication() / 10) * impact.getCommunicationImpact();
        }

        private double countExperienceScore()
        {
            return salary * (score.getYearsOfExperience() / 10) * impact.getExperienceImpact();
        }
    }
}
