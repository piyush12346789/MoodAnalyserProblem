using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserProblem;

namespace MoodAnalyserMSTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Given_I_Am_In_Sad_Mood_Should_Return_SAD()
        {
            //Arrange
            string message = "I am in sad mood.";
            MoodAnalyser moodAnalyser = new MoodAnalyser(message);
            //Act
            string result = moodAnalyser.AnalyseMood();
            //Assert
            Assert.AreEqual("SAD", result);
        }
        [TestMethod]
        public void Given_I_Am_In_Happy_Mood_Should_Return_HAPPY()
        {
            //Arrange
            string message = "I am in happy mood.";
            MoodAnalyser moodAnalyser = new MoodAnalyser(message);
            //Act
            string result = moodAnalyser.AnalyseMood();
            //Assert
            Assert.AreEqual("HAPPY", result);
        }
        //Removed TC2.1 Given_Null_Should_Return_HAPPY() because now null mood will throw custom exception
        [TestMethod]
        public void Given_Null_Mood_Should_Throw_MoodAnalysisException_Indicating_Null_Mood()
        {
            try
            {
                //Arrange
                string message = null;
                MoodAnalyser moodAnalyser = new MoodAnalyser(message);
                //Act
                string result = moodAnalyser.AnalyseMood();
            }
            catch (MoodAnalysisException e)
            {
                //Assert
                Assert.AreEqual("Mood should not be null.", e.Message);
            }
        }
        [TestMethod]
        public void Given_Empty_Mood_Should_Throw_MoodAnalysisException_Indicating_Empty_Mood()
        {
            try
            {
                //Arrange
                string message = "";
                MoodAnalyser moodAnalyser = new MoodAnalyser(message);
                //Act
                string result = moodAnalyser.AnalyseMood();
            }
            catch (MoodAnalysisException e)
            {
                //Assert
                Assert.AreEqual("Mood should not be empty.", e.Message);
            }
        }
        //TC 4.1
        [TestMethod]
        public void Given_MoodAnalyser_Class_Name_Should_Return_MoodAnalyser_Object()
        {
            //Arrange
            string className = "MoodAnalyserProblem.MoodAnalyser";
            string constructorName = "MoodAnalyser";
            //Act
            MoodAnalyser expected = new MoodAnalyser();
            object resultObj = MoodAnalyserFactory.CreateMoodAnalyserObject(className, constructorName);
            //Assert
            expected.Equals(resultObj);
        }
        //TC 4.2
        [TestMethod]
        public void Given_Improper_Class_Name_Should_Throw_MoodAnalysisException_Indicating_No_Such_Class()
        {
            try
            {
                //Arrange
                string className = "WrongNamespace.MoodAnalyser";
                string constructorName = "MoodAnalyser";
                //Act
                object resultObj = MoodAnalyserFactory.CreateMoodAnalyserObject(className, constructorName);
            }
            catch (MoodAnalysisException e)
            {
                //Assert
                Assert.AreEqual("class not found.", e.Message);
            }
        }
        //TC4.3
        [TestMethod]
        public void Given_Improper_Constructor_Name_Should_Throw_MoodAnalysisException_Indicating_No_Such_Constructor()
        {
            try
            {
                //Arrange
                string className = "MoodAnalyzerProblem.MoodAnalyser";
                string constructorName = "WrongConstructorName";
                //Act
                object resultObj = MoodAnalyserFactory.CreateMoodAnalyserObject(className, constructorName);
            }
            catch (MoodAnalysisException e)
            {
                //Assert
                Assert.AreEqual("constructor not found.", e.Message);
            }
        }
        //TC5.1
        [TestMethod]
        public void Given_MoodAnalyser_Class_Name_Should_Return_MoodAnalyser_Object_Using_Parametrized_Constructor()
        {
            //Arrange
            string className = "MoodAnalyserProblem.MoodAnalyser";
            string constructorName = "MoodAnalyser";
            MoodAnalyser expectedObj = new MoodAnalyser("HAPPY");
            //Act
            object resultObj = MoodAnalyserFactory.CreateMoodAnalyserUsingParameterizedConstructor(className, constructorName, "HAPPY");
            //Assert
            expectedObj.Equals(resultObj);
        }
        //TC5.2
        [TestMethod]
        public void Given_Improper_Class_Name_Should_Throw_MoodAnalysisException_For_Parameterized_Constructor()
        {
            try
            {
                //Arrange
                string className = "WrongNameSpace.MoodAnalyser";
                string constructorName = "MoodAnalyser";
                MoodAnalyser expectedObj = new MoodAnalyser("HAPPY");
                //Act
                object resultObj = MoodAnalyserFactory.CreateMoodAnalyserUsingParameterizedConstructor(className, constructorName, "HAPPY");
            }
            catch (MoodAnalysisException e)
            {
                //Assert
                Assert.AreEqual("class not found.", e.Message);
            }
        }
        //TC5.3
        [TestMethod]
        public void Given_Improper_Constructor_Name_Should_Throw_MoodAnalysisException_For_Parameterized_Constructor()
        {
            try
            {
                //Arrange
                string className = "MoodAnalyserProblem.MoodAnalyser";
                string constructorName = "WrongConstructorName";
                MoodAnalyser expectedObj = new MoodAnalyser("HAPPY");
                //Act
                object resultObj = MoodAnalyserFactory.CreateMoodAnalyserUsingParameterizedConstructor(className, constructorName, "HAPPY");
            }
            catch (MoodAnalysisException e)
            {
                //Assert
                Assert.AreEqual("constructor is not found.", e.Message);
            }
        }
        //TC6.1
        [TestMethod]
        public void Given_Happy_Message_Using_Reflection_When_Proper_Should_Return_Happy()
        {
            //Arrange
            string message = "HAPPY";
            string methodName = "AnalyseMood";
            //Act
            string actual = MoodAnalyserFactory.InvokeAnalyseMood(message, methodName);
            //Assert
            Assert.AreEqual("HAPPY", actual);
        }
        //TC6.2
        [TestMethod]
        public void Given_Improper_Method_Name_Should_Throw_MoodAnalysisException_Indicating_No_Such_Method()
        {
            try
            {
                //Arrange
                string message = "HAPPY";
                string methodName = "WrongMethodName";
                //Act
                string actual = MoodAnalyserFactory.InvokeAnalyseMood(message, methodName);
            }
            catch (MoodAnalysisException e)
            {
                //Assert
                Assert.AreEqual("no such method.", e.Message);
            }
        }
        //TC7.1
        [TestMethod]
        public void Given_Happy_Message_With_Reflection_Should_Return_Happy()
        {
            //Arrange
            string message = "HAPPY";
            string fieldName = "message";
            //Act
            string actual = MoodAnalyserFactory.SetField(message, fieldName);
            //Assert
            Assert.AreEqual("HAPPY", actual);
        }
        //TC7.2
        [TestMethod]
        public void Given_Improper_Field_Name_Should_Throw_MoodAnalysisException_Indicating_No_Such_Field()
        {
            try
            {
                //Arrange
                string message = "HAPPY";
                string fieldName = "wrongName";
                //Act
                string actual = MoodAnalyserFactory.SetField(message, fieldName);
            }
            catch (MoodAnalysisException e)
            {
                //Assert
                Assert.AreEqual("no such field found.", e.Message);
            }
        }
        //TC7.3
        [TestMethod]
        public void Given_Null_Message_Should_Throw_MoodAnalysisException_Indicating_Null_Message()
        {
            try
            {
                //Arrange
                string message = null;
                string fieldName = "message";
                //Act
                string actual = MoodAnalyserFactory.SetField(message, fieldName);
            }
            catch (MoodAnalysisException e)
            {
                //Assert
                Assert.AreEqual("message should not be null.", e.Message);
            }
        }
    }
}