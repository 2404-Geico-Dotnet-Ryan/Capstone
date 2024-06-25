namespace Capstone.Models
{
    public class Performance
    {
        public int PerformanceId { get; set; }
        public int EmployeeId { get; set; }
        public int ManagerId { get; set; }
        public string? ReviewPeriod { get; set; }
        public string? Goal { get; set; }
        public string? Deliverable { get; set; }
        public string? Deadline { get; set; }
        public int Weightage { get; set; }
        public string? Achievements { get; set; }
        public string? ImprovementAreas { get; set; }

        // This establishes the "one to one" relationship 
        // One Performance to One Employee  
        public Employee Employee { get; set; }
        
        /* NO Argurments Constructor*/
        public Performance()
        {

        }

        /* FULL Argurments Constructor */
        public Performance(int performanceId , int employeeId, int managerId, string reviewPeriod, string goal, string deliverable, 
                            string deadline, int weightage, string achievements, string improvementAreas)
        {
            PerformanceId = performanceId;
            EmployeeId = employeeId;
            ManagerId = managerId;
            ReviewPeriod = reviewPeriod;
            Goal = goal;
            Deliverable = deliverable;
            Deadline = deadline;
            Weightage = weightage;
            Achievements = achievements;
            ImprovementAreas = improvementAreas;
        }
    }
}