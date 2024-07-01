
using Capstone.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Capstone.Models;
using Capstone.DTOs;
using Capstone.Services;

namespace Capstone.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class GoalsController : ControllerBase
    {
        private readonly IGoalsService __goalService; // This is the database context

        public GoalsController(IGoalsService goalsService)
        {
           __goalService = goalsService;
        }

  
        [HttpGet]
        public ActionResult<IEnumerable<GoalsDTO>> GetGoals()
        {
            return Ok(__goalService.GetAllGoals());
        }

        [HttpGet("{goalId}")]
        public ActionResult<GoalsDTO> GetGoal(int goalId)
        {
            var goal = __goalService.GetGoalByGoalId(goalId);
            if (goal == null)
            {
                return NotFound();
            }
            return Ok(goal);
        }

        //get by performance id controller

        [HttpGet("performance/{performanceId}")]
        public ActionResult<IEnumerable<GoalsDTO>> GetGoalsByPerformanceId(int performanceId)
        {
            return Ok(__goalService.GetGoalsByPerformanceId(performanceId));
        }


        [HttpPost]
        public ActionResult<GoalsDTO> CreateGoal(GoalsDTO goalDTO)
        {
            try {
                var goal = __goalService.CreateGoal(goalDTO);
                return Ok(goal);
            }
            catch (Exception e)
           
            {
                return Conflict(e.Message);
            }
        }

        [HttpPut("{goalId}")]
        public ActionResult<GoalsDTO> UpdateGoal(int goalId, GoalsDTO goalDTO)
        {
            try 
            {
               var goal = __goalService.UpdateGoal(goalId, goalDTO); 
               return Ok(goal);
            }
            catch (Exception e)
            {
                if (e.Message == "Goal not found")
                {
                    return NotFound(e.Message);
                }
                else
                {
                    throw;
                }
        

        }
        } 
    }
}