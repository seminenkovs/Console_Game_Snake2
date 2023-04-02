using Snake2.Lines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake2.Installer
{
    internal class LineInstaller
    {
        private List<AbstractShape> _shapes;

        public LineInstaller()
        {
            _shapes = new List<AbstractShape>();

            AbstractShape upperLine = new HorizontalLine(0, 0, '-', 120);
            AbstractShape bottomLine = new HorizontalLine(0, 20, '-', 120);

            AbstractShape leftSideLine = new VerticalLine(0, 1, '|', 20);
            AbstractShape rightSideLine = new VerticalLine(119, 1, '|', 20);

            _shapes.AddRange(new List<AbstractShape> { upperLine, bottomLine, leftSideLine, rightSideLine });            
        }

        public void DrawShapes()
        {
            foreach (var shape in _shapes)
            {
                shape.DrawLine();
            }
        }

        public bool Collision(AbstractShape shape)
        {
            foreach (var item in _shapes)
            {
                if (item.Collision(shape))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
