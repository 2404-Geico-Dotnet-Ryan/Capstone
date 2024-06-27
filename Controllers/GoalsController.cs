
using Capstone.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Capstone.Models;
using Capstone.DTOs;

namespace Capstone.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class GoalsController : ControllerBase
    {
        private readonly AppDbContext _context; // This is the database context

        public GoalsController(AppDbContext context)
        {
            _context = context;
        }

        //CRUD operations for Goals - GET, PUT, POST, DELETE

        
        [HttpPost]
        public GoalsDTO CreateGoal(GoalsDTO goalDTO)
        {
            var goal = new Goals
            {
                GoalId = goalDTO.GoalId,
                PerformanceId = goalDTO.PerformanceId,
                Goal = goalDTO.Goal,
                Deliverable = goalDTO.Deliverable,
                Deadline = goalDTO.Deadline,
                Weightage = goalDTO.Weightage,
                GoalScore = goalDTO.GoalScore,
                ManagerFeedback = goalDTO.ManagerFeedback
            };
            _context.Goals.Add(goal);
            _context.SaveChanges();
            return goalDTO;
        }

        //Delete a goal by the PK - GoalId - tested in swagger & DB passed
        [HttpDelete("{GoalId}")]
        public void DeleteGoal(int GoalId)
        {
            var goal = _context.Goals.FirstOrDefault(g => g.GoalId == GoalId);
            if (goal != null)
            {
                _context.Goals.Remove(goal);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Goal not found");
            }
        }

        //Get every goal in the DB - no filtering. Tested in swagger - passed
        [HttpGet]
        public ActionResult<IEnumerable<GoalsDTO>>GetGoals()
        {
            var goals = _context.Goals.Select(g => new GoalsDTO
            {
                GoalId = g.GoalId,
                PerformanceId = g.PerformanceId,
                Goal = g.Goal,
                Deliverable = g.Deliverable,
                Deadline = g.Deadline,
                Weightage = g.Weightage,
                GoalScore = g.GoalScore,
                ManagerFeedback = g.ManagerFeedback
            }).ToList();
            return goals;
        }


        //Get a goal by the PK - GoalId - tested pass
        [HttpGet("{GoalId}")]
        public ActionResult<GoalsDTO> GetGoal(int GoalId)
        {
            var goal = _context.Goals.Select(g => new GoalsDTO
            {
                GoalId = g.GoalId,
                PerformanceId = g.PerformanceId,
                Goal = g.Goal,
                Deliverable = g.Deliverable,
                Deadline = g.Deadline,
                Weightage = g.Weightage,
                GoalScore = g.GoalScore,
                ManagerFeedback = g.ManagerFeedback
            }).FirstOrDefault(g => g.GoalId == GoalId);
            if (goal == null)
            {
                return NotFound();
 
            }
            return goal;
        }

        //Update a goal by the PK - GoalId - testing in swagger updated "Deliverable" passed
        [HttpPut("{GoalId}")]
        public ActionResult<GoalsDTO> UpdateGoal(int GoalId, GoalsDTO goalDTO)
        {
            var goal = _context.Goals.FirstOrDefault(g => g.GoalId == GoalId);
            if (goal == null)
            {
                return NotFound();
            }
            goal.GoalId = goalDTO.GoalId;
            goal.PerformanceId = goalDTO.PerformanceId;
            goal.Goal = goalDTO.Goal;
            goal.Deliverable = goalDTO.Deliverable;
            goal.Deadline = goalDTO.Deadline;
            goal.Weightage = goalDTO.Weightage;
            goal.GoalScore = goalDTO.GoalScore;
            goal.ManagerFeedback = goalDTO.ManagerFeedback;
            _context.SaveChanges();
            return goalDTO;

    }


}

}
