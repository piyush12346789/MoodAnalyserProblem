using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserProblem;
namespace MoodTester
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            string message = "I am in Happy Mood";
            string expected = "HAPPY";
            MoodAnalyser mood = new MoodAnalyser(message);
            //Act
            string result = mood.AnalyseMood(message);
            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}