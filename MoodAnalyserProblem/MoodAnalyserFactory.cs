using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Text.RegularExpressions;
using MoodAnalyserProblem;

namespace MoodAnalyzerProblem
{
    public class MoodAnalyserFactory
    {
        public static object CreateMoodAnalyserObject(string className, string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match result = Regex.Match(className, pattern);
            if (result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);
                }
                catch (ArgumentNullException)
                {
                    throw new MACustomException(MACustomException.ExceptionType.NO_SUCH_CLASS, "class not found.");
                }
            }
            else
            {
                throw new MACustomException(MACustomException.ExceptionType.NO_SUCH_METHOD, "constructor not found.");
            }
        }
    }
}