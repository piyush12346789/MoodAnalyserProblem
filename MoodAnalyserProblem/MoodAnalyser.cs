using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyserProblem
{
    public class MoodAnalyser
    {
        private string message;
        public MoodAnalyser(string message)
        {
            this.message = message;
        }
        public string AnalyseMood(string mesaage)
        {
            try
            {
                if (this.message.Contains("sad"))
                {
                    return "SAD";
                }
                else
                {
                    return "HAPPY";
                }
            }
            catch
            {
                //Returning Happy when case of Null exception
                return "HAPPY";
            }

        }
        public string AnalyseMoodLive()
        {
            try
            {
                if (this.message.Equals(string.Empty))
                {
                    throw new MACustomException(MACustomException.ExceptionType.EMPTY_MESSAGE, "mood should not be empty");
                }
                if (this.message.Contains("sad"))
                    return "SAD";
                else
                    return "HAPPY";
            }
            catch (NullReferenceException)
            {
                throw new MACustomException(MACustomException.ExceptionType.NULL_MESSAGE, "mood should not be null");
            }
        }
    }
}
