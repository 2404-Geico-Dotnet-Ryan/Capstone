using Capstone.Data;
using Capstone.DTOs;
using Capstone.Models;
using Capstone.Services;
using Microsoft.EntityFrameworkCore;


namespace Capstone.Services

{
    public class GoalsService : IGoalsService
    {
        private readonly AppDbContext _context;

        public GoalsService(AppDbContext context)
        {
            _context = context;
        }



        public GoalsDTO CreateGoal(GoalsDTO goalsDTO)
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
                return goalsDTO;
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
            var goals = _context.Goals.Where(g => g.PerformanceId == PerformanceId).ToList();
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
    public GoalsDTO UpdateGoal(int goalId, GoalsDTO updateGoalDTO)
        {
            var goal = _context.Goals.Find(goalId);
            if (goal != null)
            {
                goal.GoalId = updateGoalDTO.GoalId;
                goal.PerformanceId = updateGoalDTO.PerformanceId;
                goal.Goal = updateGoalDTO.Goal;
                goal.Deliverable = updateGoalDTO.Deliverable;
                goal.Deadline = updateGoalDTO.Deadline;
                goal.Weightage = updateGoalDTO.Weightage;
                goal.GoalScore = updateGoalDTO.GoalScore;
                goal.ManagerFeedback = updateGoalDTO.ManagerFeedback;
                _context.Goals.Update(goal);
                _context.SaveChanges();
                return updateGoalDTO;

            }
            else
            {
                throw new Exception("Goal not found");
            }
        }
    }

    }
