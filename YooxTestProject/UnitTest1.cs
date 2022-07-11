using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using YooxExercise;
using System.Diagnostics;

namespace YooxTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string[] triangleToy = new string[] { "4", "36 36 30", "47 8 60", "46 96 90", "86 86 86" };
            Result TestResult = new Result();
            string[] CheckResult = TestResult.TriangleType(triangleToy);

        }
    }
}
