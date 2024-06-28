namespace Capstone.Models
{
    public class Goals
    {
        public int GoalId { get; set; }
        public int PerformanceId { get; set; }
        public string? Goal { get; set; }
        public string? Deliverable { get; set; }
        public DateTime Deadline { get; set; }
        public int Weightage { get; set; }
        public int GoalScore { get; set; }
        public string? ManagerFeedback { get; set; }

        // This establishes the "one to many" relationship 
        // One Performance to many goals  
        public Performance Performance { get; set; }
        
        /* NO Argurments Constructor*/
        public Goals()
        {

        }

        /* FULL Argurments Constructor */
        public Goals(int goalId , int performanceId, string goal, string deliverable, 
                    DateTime deadline, int weightage, int goalScore, string managerFeedback)
        {
            GoalId = goalId;
            PerformanceId = performanceId;
            Goal = goal;
            Deliverable = deliverable;
            Deadline = deadline;
            Weightage = weightage;
            GoalScore = goalScore;
            ManagerFeedback = managerFeedback;
        }
    }
}