using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake2.Enum;

namespace Snake2
{
    internal sealed class Snake : AbstractShape
    {
        #region Singleton CreateSnake()

        public static Snake _snake = null; // changed to public, solving proper break of gameplay while loop

        private static readonly Object locker = new Object();

        DirectionEnum _direction;
        private Snake(int length, Point snakeTail, DirectionEnum direction) 
        {
            _direction = direction;

            _points = new List<Point>();

            for (int i = 0; i < length; i++)
            {
                Point point = new Point(snakeTail);
                point.SetDirection(direction);
                _points.Add(point);
            }
        }

        public static Snake CreateSnake(int length, Point snakeTail, DirectionEnum direction)
        {
            if (_snake == null)
            {
                lock (locker)
                {
                    if (_snake == null)
                    {
                        _snake = new Snake(length, snakeTail, direction);
                    }
                }
            }
            return _snake;
        }
        #endregion

        #region Snake Move()
        public void Move()
        { 
            Point tail  = _points.First();
            tail.ClearPoint();
            
            Point head = new Point(_points.Last());
            head.SetDirection(_direction);
            _points.Add(head);

            _points.Remove(tail);
            head.DrawPoint();
        }
        #endregion

        #region Snake Control PressKey()
        public void PressKey(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow)
            {
                _direction = DirectionEnum.Left;
            }
            else if (key == ConsoleKey.RightArrow)
            {
                _direction = DirectionEnum.Right;
            }
            else if (key == ConsoleKey.UpArrow)
            {
                _direction = DirectionEnum.Up;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                _direction = DirectionEnum.Down;
            }
        }
        #endregion

        #region Snake EatFood()
        public bool EatFood(Point food)
        {
            Point head = new Point(_points.Last());
            head.SetDirection(_direction);

            if (head.ComparePoints(food))
            {
                food.Symbol = head.Symbol;
                _points.Add(food);
                return true;
            }

            return false;
        }
        #endregion

        #region Snake CollisionWithTail()
        public bool CollisionWithTail()
        {
            Point head = _points.Last();

            for (int i = 0; i < _points.Count - 2; i++)
            {
                if (head.ComparePoints(_points[i]))
                {
                    return true;
                }
            }

            return false;
        }
        #endregion
    }
}
