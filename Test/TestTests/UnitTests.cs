using System.Collections.Generic;
using NUnit.Framework;
using Test;

namespace TestTests
{
    public class UnitTests
    {
        [Test]
        public void When_NotEnoughCubesToFillTheBox_Expect_ReturnsMinusOne()
        {
            var box = new Box(10, 10, 10);
            var cubesList = new List<int>{ 900 };

            var minimumCount = BoxSolver.GetMinimumCubesToFillBoxCount(box, cubesList);

            Assert.AreEqual(-1, minimumCount);
        }

        [Test]
        public void When_LargerBoxDoesNotFit_Expect_TakeSmallerCube()
        {
            var box = new Box(1, 1, 9);
            var cubesList = new List<int> { 9, 1 };

            var minimumCount = BoxSolver.GetMinimumCubesToFillBoxCount(box, cubesList);

            Assert.AreEqual(9, minimumCount);
        }

        [Test]
        public void When_AllBoxesTooLarge_Expect_ReturnsMinusOne()
        {
            var box = new Box(1, 1, 1);
            var cubesList = new List<int> { 0, 1, 1, 1 };

            var minimumCount = BoxSolver.GetMinimumCubesToFillBoxCount(box, cubesList);

            Assert.AreEqual(-1, minimumCount);
        }
    }
}