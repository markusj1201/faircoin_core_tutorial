using System;
using System.IO;

namespace Rudolph
{
   class Source
   {
      static void Main(string[] args)
      {
          bool programState = true;
          
          while (programState)
          {
              Memory.talk("Welcome, you may begin speaking!");
          }

      }
      
   }
   public class Memory
   {

        public static string statement;
        public static string response;
        public static Random rdm = new Random();

        // Possible statements
        public static string[] greetings = File.ReadAllLines("greet.txt");

        // Response to statements
        public static string[] replyGreeting = File.ReadAllLines("replyGreeting.txt");

        // Functions
        public static void talk(string response)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\nRudolph~> ");
            Console.ResetColor();
            Console.WriteLine(response);
            say();
        }
        public static void say()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Say~> ");
            Console.ResetColor();
            statement = Console.ReadLine();
            statement = statement.ToLower();
            statement = statement.Replace(" ","");
            checkSum(statement);
        }
        public static void checkSum(string statement)
        {
            // Checks if greeting
            foreach (var i in greetings)
            {
                if(statement == i)
                {
                    int count = 0;
                    foreach (var item in replyGreeting)
                    {
                        count++;
                    }
                    talk(replyGreeting[rdm.Next(count - 1)]);
                    break;
                }
            }
        }
        // End of Class Memory
   }
}
