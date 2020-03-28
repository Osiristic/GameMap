using System;
using System.Collections.Generic;

namespace MapsCore
{
    public class RoutePlanner
    {
        private Grid grid;
        private CoOrd from;
        private CoOrd to;

        public RoutePlanner(Grid grid, CoOrd from, CoOrd to)
        {
            this.grid = grid;
            this.from = from;
            this.to = to;
        }

        public List<CoOrd> route()
        {
            CoOrd current = from;
            List<CoOrd> options = getOptions(current, new List<CoOrd>());

            foreach(CoOrd next in options)
            {
                List<CoOrd> path = new List<CoOrd>();
                path.Add(current);
                if(find(next, path))
                {
                    return path;
                }
            }

            throw new Exception("Could not get to target coordinate!");
        }

        private bool find(CoOrd current, List<CoOrd> pathTaken)
        {
            if (current.Equals(to))
            {
                return true;
            }

            List<CoOrd> options = getOptions(current, pathTaken);

            pathTaken.Add(current);
            foreach (CoOrd next in options)
            {
                List<CoOrd> path = new List<CoOrd>(pathTaken);
                if (find(next, path))
                {
                    pathTaken.Clear();
                    pathTaken.AddRange(path);
                    return true;
                }
            }

            return false;
        }



        private List<CoOrd> getOptions(CoOrd current, List<CoOrd> pathTaken)
        {
            List<CoOrd> options = new List<CoOrd>();

            CheckCoOrd(current.X, current.Y - 1, options, pathTaken);
            CheckCoOrd(current.X, current.Y + 1, options, pathTaken);
            CheckCoOrd(current.X + 1, current.Y, options, pathTaken);
            CheckCoOrd(current.X - 1, current.Y, options, pathTaken);

            return options;
        }

        private void CheckCoOrd(int x, int y, List<CoOrd> options, List<CoOrd> pathTaken)
        {
            try
            {
                if (grid.IsCorridor(x, y) && !pathTaken.Contains(new CoOrd(x,y)))
                {
                    options.Add(new CoOrd(x, y));
                }
            } catch(Exception)
            {
                // Ignore because we dont want to move off the grid.
            }
        }
    }
}
