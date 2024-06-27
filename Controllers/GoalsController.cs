
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

        //Add all the HttpGEt etc methods below 

        //create an HTTP to add a new goal
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

    }


}
