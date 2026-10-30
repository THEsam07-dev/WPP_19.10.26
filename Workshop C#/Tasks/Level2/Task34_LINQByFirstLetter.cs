using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_C_.Common;

namespace Workshop_C_.Tasks.Level2
{
    public class Task34_LINQByFirstLetter : ITask
    {
        public string Title => "LINQ: группировка слов по первой букве";
        public string Description => "Сгруппировать слова по первой букве с помощью LINQ.";
        public string[] Requirements => new[]
        {
            "Взять список слов (10+).",
            "Сгруппировать через LINQ GroupBy(w => w[0]).",
            "Отсортировать группы по первой букве.",
            "Внутри группы — отсортировать слова.",
            "Вывести «Буква: слово1, слово2, ...»."
        };

        public void Run()
        {
            List<string> words = new List<string>
            {
                "FrostPuck", "MassEffectLE", "Control", "KingsBounty", "GTAV",
                "PathfinderKingmaker", "EliteDangerous", "Beholder", "TheCrewII", "Hades",
                "CrysisRemastered", "AlanWake", "LeftForDeadII", "MafiaDE", "EuroTrackSimulator",
                "Terraria", "ForzaHorizonV", "Gothic", "SleepingDogs", "BeyondTwoSoul",
                "WatchDogs", "Steep", "LANoir", "DragonsDogma", "KingdomComeDeliverance",
                "FinalFantasyVIIRemake", "NeedForSpeedHeat", "Prey", "DeusExHumanRevolution",
                "FalloutNewVegas", "HeavyRain", "Injastice", "Wolfenstein"

            };

            Console.WriteLine("Исходный список слов");
            Console.WriteLine(string.Join(", ", words));
            Console.WriteLine();

            var groupedWords = words
                .GroupBy(w => w[0])
                .OrderBy(group => group.Key)
                .Select(group => new
                {
                    Letter = group.Key,
                    SortedWords = group.OrderBy(w => w).ToList()
                });

            Console.WriteLine("Результат группировки");

            foreach (var group in groupedWords)
            {
                Console.WriteLine($"{char.ToUpper(group.Letter)}: {string.Join(", ", group.SortedWords)}");
            }
        }
    }
}
