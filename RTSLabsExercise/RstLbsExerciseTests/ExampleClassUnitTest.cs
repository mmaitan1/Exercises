using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace RTSLabsExercise.Tests
{
    [TestClass]
    public class ExampleClassUnitTest
    {
        [TestMethod]
        public void aboveBelow()
        {
            ExampleClass example = new ExampleClass();
            Dictionary<string, int> result = example.aboveBelow(new List<int> { 1, 5, 2, 1, 10 }, 6);

            Assert.Equals(result["above"], 1);
            Assert.Equals(result["below"], 4);
        }
        
        [TestMethod]
        public void stringRotation()
        {
            ExampleClass example = new ExampleClass();
            string result = example.stringRotation("MyString", 2);

            Assert.IsTrue(result.Contains("ngMyStri"));
        }
    }
}