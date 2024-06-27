using Capstone.DTOs;
using Capstone.Models;

namespace Capstone.Services
{
    public interface IGoalsService
    {
        IEnumerable<GoalsDTO> GetAllGoals(); //get list of all goals
        GoalsDTO GetGoalByGoalId(int GoalId); //get goal by id
        IEnumerable<GoalsDTO> GetGoalsByPerformanceId(int PerformanceId); //get goal by performance id

        GoalsDTO CreateGoal(GoalsDTO Goal); //create a goal

        void UpdateGoal(int goalId, GoalsDTO UpdateGoal); //make a change to a goal - PUT/Update

        void DeleteGoal(int GoalId); //delete a goal - DELETE 
               
    }
}
