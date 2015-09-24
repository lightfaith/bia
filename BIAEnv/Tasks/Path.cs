using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Tasks
{
    public class Path
    {
        public List<Point> Points{get; private set;}

        public Path(List<Point> points)
        {
            Points = points;
        }
    }
}
