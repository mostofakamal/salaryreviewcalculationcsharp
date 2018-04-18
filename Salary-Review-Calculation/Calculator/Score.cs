using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary_Review_Calculation.Calculator
{
    public class Score
    {

        private float problemSolving;
        private float yearsOfExperience;
        private float leaderShip;
        private float communication;
        private float decipline;

        public Score(float problemSolving, float yearsOfExperience, float leaderShip,
                     float communication, float decipline)
        {
            this.problemSolving = problemSolving;
            this.yearsOfExperience = yearsOfExperience;
            this.leaderShip = leaderShip;
            this.communication = communication;
            this.decipline = decipline;
        }

        public float getProblemSolving()
        {
            return problemSolving;
        }

        public void setProblemSolving(float problemSolving)
        {
            this.problemSolving = problemSolving;
        }

        public float getYearsOfExperience()
        {
            return yearsOfExperience;
        }

        public void setYearsOfExperience(float yearsOfExperience)
        {
            this.yearsOfExperience = yearsOfExperience;
        }

        public float getLeaderShip()
        {
            return leaderShip;
        }

        public void setLeaderShip(float leaderShip)
        {
            this.leaderShip = leaderShip;
        }

        public float getCommunication()
        {
            return communication;
        }

        public void setCommunication(float communication)
        {
            this.communication = communication;
        }

        public float getDecipline()
        {
            return decipline;
        }

        public void setDecipline(float decipline)
        {
            this.decipline = decipline;
        }
    }
}
