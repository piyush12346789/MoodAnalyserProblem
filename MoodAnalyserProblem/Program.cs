using System;
namespace MoodAnalyserProblem
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter message: ");
            string message = Console.ReadLine();
            MoodAnalyser checkmood = new MoodAnalyser(message);
            string result = checkmood.AnalyseMood(message);
            Console.WriteLine(result + " MOOD");
        }
    }
}