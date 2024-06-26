namespace Capstone.Models
{
    public class Performance
    {
        public int PerformanceId { get; set; }
        public int EmployeeId { get; set; }
        public int ManagerId { get; set; }
        public string? ReviewPeriod { get; set; }
        public string? Achievements { get; set; }
        public string? ImprovementAreas { get; set; }
        public int TotalReviewScore { get; set; }
        public bool IsCompletedPA { get; set; }
        public bool IsCompletedReview { get; set; }

        // This establishes the "one to one" relationship 
        // One Performance to One Employee  
        public Employee Employee { get; set; }

        // This establishes the "one to many" relationship 
        // One Employee to Many LeaveRequest
        public ICollection<Goals> Goals { get; set; }
        
        /* NO Argurments Constructor*/
        public Performance()
        {

        }

        /* FULL Argurments Constructor */
        public Performance(int performanceId , int employeeId, int managerId, string reviewPeriod, string achievements, 
                           string improvementAreas, int totalReviewScore, bool isCompletedPA, bool isCompletedReview)
        {
            PerformanceId = performanceId;
            EmployeeId = employeeId;
            ManagerId = managerId;
            ReviewPeriod = reviewPeriod;
            Achievements = achievements;
            ImprovementAreas = improvementAreas;
            TotalReviewScore = totalReviewScore;
            IsCompletedPA = isCompletedPA;
            IsCompletedReview = isCompletedReview;
        }
    }
}