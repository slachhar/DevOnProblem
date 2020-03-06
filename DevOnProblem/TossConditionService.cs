using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOnProblem
{
    public class TossConditionService : ITossConditionService
    {
        private readonly ITossConditionRepository repository;

        public TossConditionService(ITossConditionRepository _repository)
        {
            repository = _repository;
        }

        public string getDecision(InputTossCondition condition)
        {

            return repository.GetDecision(toss => toss.Condition == condition.Weather.ToString()

            );

        }
    }

    public interface ITossConditionService
    {
        string getDecision(InputTossCondition condition);
    }

    public class InputTossCondition
    {
        public InputTossCondition(PlanetEnum planet, Weather weather, DayNight dayNight)
        {
            Planet = planet;
            Weather = weather;
            DayNight = dayNight;
        }
        public PlanetEnum Planet { get; set; }
        public Weather Weather { get; set; }
        public DayNight DayNight { get; set; }
    }

    public enum Weather
    {
        Clear,
        Cloudy
    }

    public enum DayNight
    {
        Day,
        Night
    }
}
