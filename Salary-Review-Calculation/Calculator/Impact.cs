namespace Salary_Review_Calculation.Calculator
{
    public class Impact
    {
        public Impact(double disciplineImpact, double problemSolvingImpact, double leadershipImpact, double communicationImpact, double experienceImpact)
        {
            this.disciplineImpact = disciplineImpact;
            this.problemSolvingImpact = problemSolvingImpact;
            this.leadershipImpact = leadershipImpact;
            this.communicationImpact = communicationImpact;
            this.experienceImpact = experienceImpact;
        }

        public double getDisciplineImpact()
        {
            return disciplineImpact;
        }

        public double getProblemSolvingImpact()
        {
            return problemSolvingImpact;
        }

        public double getLeadershipImpact()
        {
            return leadershipImpact;
        }


        public double getCommunicationImpact()
        {
            return communicationImpact;
        }


        public double getExperienceImpact()
        {
            return experienceImpact;
        }


        private readonly double disciplineImpact;
        private readonly double problemSolvingImpact;
        private readonly double leadershipImpact;
        private readonly double communicationImpact;
        private readonly double experienceImpact;
    }
}
