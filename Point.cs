using Snake2.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake2
{
    internal class Point
    {
        private int _left = default(int);
        private int _top = default(int);
        private char _symbol = default(char);


        public char Symbol
        {
            get { return _symbol; }
            set { _symbol = value; }
        }


        public Point(int left, int top, char symbol)
        {
            _left = left;
            _top = top;
            _symbol = symbol;
        }
        public Point(Point point)
        {
            _left = point._left;
            _top = point._top;
            _symbol = point._symbol;
        }

        public void SetDirection(DirectionEnum direction)
        {
            switch (direction)
            {
                case DirectionEnum.Left:
                    _left = _left - 1;
                    break;
                case DirectionEnum.Right:
                    _left = _left + 1;
                    break;
                case DirectionEnum.Up:
                    _top = _top - 1;
                    break;
                case DirectionEnum.Down:
                    _top = _top + 1;
                    break;
            }
        }

        public void DrawPoint()
        {
            Console.SetCursorPosition(_left, _top);
            Console.Write(_symbol);
        }

        public void ClearPoint()
        {
            _symbol = ' ';
            DrawPoint();
        }

        public bool ComparePoints(Point point)
        {
            return point._left == _left && point._top == _top;
        }
    }
}
