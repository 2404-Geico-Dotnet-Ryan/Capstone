using System.Data;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Capstone.DTOs
{

    public class GoalsDTO
    {
        public int GoalId { get; set; }
        public int PerformanceId { get; set; }
        public string? Goal { get; set; }
        public string? Deliverable { get; set; }
        public DateTime Deadline { get; set; }
        public int Weightage { get; set; }
        public int GoalScore { get; set; }
        public string? ManagerFeedback { get; set; }

    }

}