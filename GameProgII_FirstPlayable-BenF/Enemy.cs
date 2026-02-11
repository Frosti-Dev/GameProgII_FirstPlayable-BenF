using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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
            if(Normalize(_target._posX - _pos.Item1) > Normalize(_target._posY - _pos.Item2))
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
            }
            
            else
            {
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
            }

            Debug.WriteLine($"{Normalize(_target._posX - _pos.Item1)}, {Normalize(_target._posY - _pos.Item2)}");

            if (_health == 0)
            {
                _alive = false;
                _pos = (50, 0);
            }
        }

        private int Normalize(int value)
        {
            if(value < 0)
            {
                value -= value * 2;
                return value;
            }

            else
            {
                return value;
            }
        }
    }
}
