using Ignateva_Exzam;
using System;
using Xunit;

namespace XUnitTestDijkstra
{
    public class UnitTest1
    {
        [Fact]
        public void ValidateStartingPoint_InvalidStartingPoint_ReturnsErrorMessage()
        {
            int n = 0;
            var expected = "¬ведите начальную точку маршрута от 1 до 9: ";
            var result = Program.ValidateStartingPoint(n);
            Assert.Equal(expected, result);
        }
    }
}