using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOnProblem
{
    public class TossConditionRepository : ITossConditionRepository
    {
        private List<TossCondition> tossConditions = new List<TossCondition>();

        public void AddCondition(TossCondition condition)
        {
            tossConditions.Add(condition);
        }

        public string GetDecision(Func<TossCondition, bool> predicate)
        {
            string decision = "Bat";
            foreach (var tossCondition in tossConditions.Where(predicate))
            {
                return tossCondition.Decision;
            }

            return decision;
        }
    }

    public interface ITossConditionRepository
    {
        void AddCondition(TossCondition condition);
        string GetDecision(Func<TossCondition, bool> predicate);
    }

    public class TossCondition
    {
        public string Planet { get; set; }
        public string Condition { get; set; }
        public string Decision { get; set; }
    }
}
