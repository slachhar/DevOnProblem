using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOnProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Tuple<string, string> conditions = Tuple.Create("Clear", "Day");
            TossConditionRepository tossConditionRepository = new TossConditionRepository();
            tossConditionRepository.AddCondition(new TossCondition() { Condition = "Clear", Decision = "Bat", Planet = "L" });
            tossConditionRepository.AddCondition(new TossCondition() { Condition = "Day", Decision = "Bat", Planet = "L" });
            tossConditionRepository.AddCondition(new TossCondition() { Condition = "Cloudy", Decision = "Bowl", Planet = "L" });
            tossConditionRepository.AddCondition(new TossCondition() { Condition = "Night", Decision = "Bowl", Planet = "L" });
            tossConditionRepository.AddCondition(new TossCondition() { Condition = "Clear", Decision = "Bowl", Planet = "E" });
            tossConditionRepository.AddCondition(new TossCondition() { Condition = "Day", Decision = "Bowl", Planet = "E" });
            tossConditionRepository.AddCondition(new TossCondition() { Condition = "Cloudy", Decision = "Bat", Planet = "E" });
            tossConditionRepository.AddCondition(new TossCondition() { Condition = "Night", Decision = "Bat", Planet = "E" });

            Random rdm = new Random();

            ITossConditionService tossConditionService = new TossConditionService(tossConditionRepository);
            PlanetEnum randomPlanet =(PlanetEnum) rdm.Next(0, 2);
            Console.WriteLine(string.Format("{0} wins toss and {1}",
               randomPlanet, 
                tossConditionService.getDecision(new InputTossCondition(randomPlanet, Weather.Clear, DayNight.Day))));
            Console.ReadLine();
        }
    }
}
