using System;
using MapsCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MapsTests
{
    [TestClass]
    public class GridTest
    {
        public GridTest()
        {
        }

        [TestMethod]
        public void ShouldCreateGridWithExpectedDimensions()
        {
            Grid grid = new Grid(7, 10);
            Assert.AreEqual(7, grid.Width);
            Assert.AreEqual(10, grid.Height);
        }

        [TestMethod]
        public void ShouldAddWallToExpectedPosition_WhenWallAdded()
        {
            Grid grid = new Grid(7, 10);
            grid.PutWall(0, 0);
            Assert.IsTrue(grid.IsWall(0, 0));
        }

        [TestMethod]
        public void ShouldIndicateEmpty_WhenNothingInGridPosition()
        {
            Grid grid = new Grid(7, 10);
            Assert.IsTrue(grid.IsEmpty(0, 0));

        }

        [TestMethod]
        public void ShouldGenerateExpectedStringMap_WhenMapCreated()
        {
            Grid grid = new Grid(2, 2);
            grid.PutWall(0, 0);
            grid.PutWall(1, 1);
            Assert.AreEqual("W \n W\n", grid.ToString());
        }

        [TestMethod]
        public void ShouldGenerateExpectedMap_WhenInitialisedFromStrings()
        {
            Grid grid = new Grid(new string[] {
                "WWWW      WWWWWWW             ",
                "WCCW      WCCCCCW             ",
                "WCCCCCCCCCCCCCCCW        WWWWW",
                "WCCW      WCCCCCW        WCCCW",
                "WWCW      WCCCCCW        WCCCW",
                "  C       WWWWWWW        WCCCW",
                "  C                      WCCCW",
                "  C                      WWCWW",
                "  C                        C  ",
                "  CCCCCCCCCCCCCCCCCCCCCCCCCC  "
            });

            Assert.IsTrue(grid.IsCorridor(1, 1));
        }
    }
}
