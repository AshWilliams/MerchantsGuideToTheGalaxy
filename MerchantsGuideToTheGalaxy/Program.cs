using System;
using MerchantsGuideToTheGalaxy.Core.CommandProcessor;

namespace MerchantsGuideToTheGalaxy
{
    class Program
    {
        static void Main(string[] args)
        {
            var interpreter = new LineInterpreter();

            while (true)
            {
                Console.Write("Hello Galaxy Merchant, how can I help you? ");
                var sentence = Console.ReadLine();

                if (sentence == "exit") break;

                var result = interpreter.ParseAndExecute(sentence);
                Console.WriteLine(result.ResultText);                
            } 
        }
    }


}
