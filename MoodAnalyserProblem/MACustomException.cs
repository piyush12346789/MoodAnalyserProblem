﻿using System;
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
            NO_SUCH_CLASS,
            NO_SUCH_METHOD
        }
        private readonly ExceptionType type;
        public MACustomException(ExceptionType Type, String message) : base(message)
        {
            this.type = Type;
        }
    }
}
