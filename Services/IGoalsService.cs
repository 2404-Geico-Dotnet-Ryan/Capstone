using Capstone.DTOs;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Services
{
    public interface IGoalsService
    {
        IEnumerable<GoalsDTO> GetAllGoals(); //get list of all goals
        GoalsDTO GetGoalByGoalId(int GoalId); //get goal by id
        IEnumerable<GoalsDTO> GetGoalsByPerformanceId(int PerformanceId); //get goal by performance id

        GoalsDTO CreateGoal(GoalsDTO Goal); //create a goal

        GoalsDTO UpdateGoal(int goalId, GoalsDTO updateGoalDTO); //make a change to a goal - PUT/Update

        void DeleteGoal(int GoalId); //delete a goal - DELETE 
               
    }
}
