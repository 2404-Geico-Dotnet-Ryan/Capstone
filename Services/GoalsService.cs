
using Capstone.Data;
using Capstone.DTOs;
using Capstone.Models;
using Capstone.Services;


namespace Capstone.Services

{
    public class GoalsService : IGoalsService
    {
        private readonly AppDbContext _context;

        public GoalsService(AppDbContext context)
        {
            _context = context;
        }

        public Goals CreateGoal(GoalsDTO goalsDTO)
        {
            if (goalsDTO == null)
            {
                var goal = new Goals
                {
                    GoalId = goalsDTO.GoalId,
                    PerformanceId = goalsDTO.PerformanceId,
                    Goal = goalsDTO.Goal,
                    Deliverable = goalsDTO.Deliverable,
                    Deadline = goalsDTO.Deadline,
                    Weightage = goalsDTO.Weightage,
                    GoalScore = goalsDTO.GoalScore,
                    ManagerFeedback = goalsDTO.ManagerFeedback
                };
                _context.Goals.Add(goal);
                _context.SaveChanges();
                return goal;
            }
            else 
            {
                throw new Exception("Goal cannot be null");
            }
            
        }

        public void DeleteGoal(int GoalId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GoalsDTO> GetAllGoals()
        {
            throw new NotImplementedException();
        }

        public GoalsDTO GetGoalByGoalId(int GoalId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GoalsDTO> GetGoalsByPerformanceId(int PerformanceId)
        {
            throw new NotImplementedException();
        }

        public void UpdateGoal(int goalId, GoalsDTO UpdateGoal)
        {
            throw new NotImplementedException();
        }

        GoalsDTO IGoalsService.CreateGoal(GoalsDTO Goal)
        {
            throw new NotImplementedException();
        }
    }


    }
