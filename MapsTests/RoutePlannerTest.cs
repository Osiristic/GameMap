using System;
using System.Collections.Generic;
using System.Diagnostics;
using MapsCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace MapsTests
{
    [TestClass]
    public class RoutePlannerTest
    {

        [TestMethod]
        public void ShouldReachTarget()
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


            CoOrd from = new CoOrd(6, 9);
            CoOrd to = new CoOrd(28, 5);

            RoutePlanner planner = new RoutePlanner(grid, from, to);
            List<CoOrd> route = planner.route();

            foreach(CoOrd c in route)
            {
                grid.PutVisited(c.X, c.Y);
                Debug.WriteLine(grid.ToString());
            }
            

        }
    }
}
