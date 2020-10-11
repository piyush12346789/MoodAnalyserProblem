using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyserProblem
{
    public class MACustomException : Exception
    {
        public enum ExceptionType
        {
            NULL_MESSAGE,
            EMPTY_MESSAGE,
        }
        private readonly ExceptionType type;
        public MACustomException(ExceptionType Type, String message) : base(message)
        {
            this.type = Type;
        }
    }
}
