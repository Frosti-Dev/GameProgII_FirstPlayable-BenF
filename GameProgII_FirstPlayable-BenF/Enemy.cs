using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgII_FirstPlayable_BenF
{
    internal class Enemy
    {
        public (int, int) _pos;
        public int _health;
        public bool _alive;
        public char _model;
        public Player _target;


        public Enemy((int, int) pos, int health, bool alive, char model, Player target)
        {
            _pos = pos;
            _health = health;
            _alive = alive;
            _model = model;
            _target = target;
        }


        public void EnemyDraw()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(_pos.Item1, _pos.Item2);

            Console.Write(_model);

            Console.SetCursorPosition(_pos.Item1, _pos.Item2);
            Console.ForegroundColor = ConsoleColor.White;

        }

        public void EnemyUpdate()
        {
            //aligns enemy x with player x
            if (_pos.Item1 > _target._posX)
            {
                _pos.Item1 -= 1;
            }

            else if (_pos.Item1 < _target._posX)
            {
                _pos.Item1 += 1;
            }
            else
            {
                //do nothing
            }

            //aligns enemy y with player y
            if (_pos.Item2 > _target._posY)
            {
                _pos.Item2 -= 1;
            }

            else if (_pos.Item2 < _target._posY)
            {
                _pos.Item2 += 1;
            }
            else
            {
                //do nothing
            }

            if (_health == 0)
            {
                _alive = false;
                _pos = (50, 0);
            }
        }

    }
}
