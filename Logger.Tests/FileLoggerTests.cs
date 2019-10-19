using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {
        [TestMethod]
        public void Log_FileCreated_IsTrue()
        {
            string filePath = "TestFile.txt";
            try
            {
                //Arrange
                string className = "TestClass";
                FileLogger fileLogger = new FileLogger(filePath) { ClassName = className };

                //Act
                fileLogger.Error("Test Message");

                //Assert
                Assert.IsTrue(File.Exists(filePath));
            }
            finally
            {
                File.Delete(filePath);
            }
        }
        
        [TestMethod]
        public void Log_FileFormatIsCorrect_IsTrue()
        {
            string filePath = "TestFile.txt";
            try
            {
                //Arrange
                string className = "TestClass";
                string testLog = $"{DateTime.Now} TestClass Error: Test Message{Environment.NewLine}";
                FileLogger fileLogger = new FileLogger(filePath) { ClassName = className };

                //Act
                fileLogger.Error("Test Message");

                //Assert
                Assert.AreEqual(testLog, File.ReadAllText(filePath));
            }
            finally
            {
                File.Delete(filePath);
            }
        }
    }
}
