
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

        public IEnumerable<GoalsDTO> GetAllGoals()
        {
           var goals = _context.Goals.ToList();
            List<GoalsDTO> goalsDTO = new List<GoalsDTO>();
            foreach (var goal in goals)
            {
                goalsDTO.Add(new GoalsDTO
                {
                    GoalId = goal.GoalId,
                    PerformanceId = goal.PerformanceId,
                    Goal = goal.Goal,
                    Deliverable = goal.Deliverable,
                    Deadline = goal.Deadline,
                    Weightage = goal.Weightage,
                    GoalScore = goal.GoalScore,
                    ManagerFeedback = goal.ManagerFeedback
                });
            }
            return goalsDTO;
        }

        public GoalsDTO GetGoalByGoalId(int GoalId)
        {
           var goal = _context.Goals.FirstOrDefault(g => g.GoalId == GoalId);
            if (goal != null)
            {
                return new GoalsDTO
                {
                    GoalId = goal.GoalId,
                    PerformanceId = goal.PerformanceId,
                    Goal = goal.Goal,
                    Deliverable = goal.Deliverable,
                    Deadline = goal.Deadline,
                    Weightage = goal.Weightage,
                    GoalScore = goal.GoalScore,
                    ManagerFeedback = goal.ManagerFeedback
                };
            }
            else
            {
                throw new Exception("Goal not found");
            }
        }

        public IEnumerable<GoalsDTO> GetGoalsByPerformanceId(int PerformanceId)
        {
            throw new NotImplementedException();
        }

        public void UpdateGoal(int goalId, GoalsDTO UpdateGoal)
        {
            var goal = _context.Goals.FirstOrDefault(g => g.GoalId == goalId);
            if (goal != null)
            {
                goal.GoalId = UpdateGoal.GoalId;
                goal.PerformanceId = UpdateGoal.PerformanceId;
                goal.Goal = UpdateGoal.Goal;
                goal.Deliverable = UpdateGoal.Deliverable;
                goal.Deadline = UpdateGoal.Deadline;
                goal.Weightage = UpdateGoal.Weightage;
                goal.GoalScore = UpdateGoal.GoalScore;
                goal.ManagerFeedback = UpdateGoal.ManagerFeedback;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Goal not found");
            }
        }

        GoalsDTO IGoalsService.CreateGoal(GoalsDTO Goal)
        {
            throw new NotImplementedException();
        }
    }


    }
