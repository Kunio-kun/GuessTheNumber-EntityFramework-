using System;
using System.Data.Entity;
using System.Linq;

namespace GuessNumber_EntityFramework_
{
    class Program
    {

        static void Main(string[] args)
        {
            InitSettings();
            using (var contex = new GameContext())
            {
                var today = DateTime.Now.Date;
                var res = contex.GameResults.Where(x => DbFunctions.TruncateTime(x.Date) == today).ToList();
                foreach (var gameresult in res)
                {
                    Console.WriteLine($" Day: {gameresult.Date}, number of turns: {gameresult.Turns}");
                }
            }
            Console.WriteLine("Hello!!!!!!!Please, think numbers at 1 to 100.");
            //const int a = 100;
            //const int b = 1;
            //int currentMax = a;
            //int currentMin = b;

            int currentMax = int.Parse(ReadSetting("maxValue"));
            int currentMin = int.Parse(ReadSetting("minValue"));
            int guess = (currentMin + currentMax) / 2;
            int counter = 0;
            while (true)
            {
                counter++;
                Console.WriteLine("Your number is {0}?", guess);
                Console.WriteLine("1 - yes, 2 - bigger, 3 - smaller");
                string response = Console.ReadLine();

                if (response == "1")
                {
                    break;
                }
                else if (response == "2")
                {
                    currentMin = guess + 1;
                    guess = (currentMax + guess) / 2;

                }
                else if (response == "3")
                {
                    currentMax = guess - 1;
                    guess = (currentMin + guess) / 2;
                }
                else
                {
                    counter--;
                    Console.WriteLine("Your input is wrong");
                }
            }
            Console.WriteLine("Gongratulation to me. Your number: {0}. Counter = {1}", guess, counter);
            GameResult result = new GameResult()
            {
                Date = DateTime.Now,
                Turns = counter
            };
            using (var contex = new GameContext())
            {
                contex.GameResults.Add(result);
                contex.SaveChanges();


            }
            Console.ReadLine();
        }


        static void InitSettings()
        {
            using (var context = new GameContext())
            {
                context.Settings.Add(new Setting()
                {
                    Key = "maxValue",
                    Value = "100"
                });
                context.Settings.Add(new Setting()
                {
                    Key = "minValue",
                    Value = "1"
                });
                context.SaveChanges();
            }

        }

        static string ReadSetting(string settingName)
        {
            using (var context = new GameContext())
            {
                return context.Settings.FirstOrDefault(x => x.Key == settingName).Value;
            }
        }
    }


}
