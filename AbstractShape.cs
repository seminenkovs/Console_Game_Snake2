using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake2
{
    internal abstract class AbstractShape
    {
        protected List<Point> _points;

        public void DrawLine()
        {
            foreach (Point point in _points)
            {
                point.DrawPoint();
            }
        }
        public bool Collision(AbstractShape shape)
        {
            foreach (var item in _points)
            {
                if (shape.ComparePoits(item))
                {
                    return true;
                }
            }
            return false;
        }

        private bool ComparePoits(Point point)
        {
            foreach (var item in _points)
            {
                if (point.ComparePoints(item))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
