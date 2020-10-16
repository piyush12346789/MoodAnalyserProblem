﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MoodAnalyserProblem
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
                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_CLASS, "class not found.");
                }
            }
            else
            {
                throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_METHOD, "constructor not found.");
            }
        }
        public static object CreateMoodAnalyserUsingParameterizedConstructor(string className, string constructorName, string message)
        {
            Type type = typeof(MoodAnalyser);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo ctor = type.GetConstructor(new[] { typeof(string) });
                    object instance = ctor.Invoke(new object[] { message } );
                    return instance;
                }
                else
                {
                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_METHOD, "constructor is not found.");
                }
            }
            else
            {
                throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_CLASS, "no such class.");
            }
        }
        public static string InvokeAnalyseMood(string message, string methodName)
        {
            try
            {
                Type type = Type.GetType("MoodAnalyserProblem.MoodAnalyser");
                object moodAnalyserObj = MoodAnalyserFactory.CreateMoodAnalyserUsingParameterizedConstructor("MoodAnalyserProblem.MoodAnalyser", "MoodAnalyser", message);
                MethodInfo methodInfo = type.GetMethod(methodName);
                object mood = methodInfo.Invoke(moodAnalyserObj, null);
                return mood.ToString();
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_METHOD, "no such method.");
            }
        }
        public static string SetField(string message, string fieldName)
        {
            try
            {
                MoodAnalyser moodAnalyser = new MoodAnalyser();
                Type type = typeof(MoodAnalyser);
                FieldInfo field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
                if (message == null)
                {
                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.EMPTY_MESSAGE, "message should not be null.");
                }
                field.SetValue(moodAnalyser, message);
                return moodAnalyser.message;
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_FIELD, "no such field found.");
            }
        }
    }
}