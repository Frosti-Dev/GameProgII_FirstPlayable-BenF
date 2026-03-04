using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgII_FirstPlayable_BenF
{
    class ConfusedEnemy : ICharacter
    {
        public (int, int) _pos;
        public int _health;
        public bool _alive;
        public char _model;
        public Player _target;

        private Random r = new Random();

        public bool _isAlive = true;

        public ConfusedEnemy((int, int) pos, int health, bool alive, char model, Player target)
        {
            _pos = pos;
            _health = health;
            _alive = alive;
            _model = model;
            _target = target;
        }

        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(_pos.Item1, _pos.Item2);

            Console.Write(_model);

            Console.SetCursorPosition(_pos.Item1, _pos.Item2);
            Console.ForegroundColor = ConsoleColor.White;

        }

        public void Update()
        {
            int rNum = r.Next(0, 4);

            if (rNum == 0)
            {
                _pos.Item1 -= 1;
            }

            else if (rNum == 1)
            {
                _pos.Item1 += 1;
            }

            else if (rNum == 2)
            {
                 _pos.Item2 -= 1;
            }

            else
            {
                _pos.Item2 += 1;
            }

        }

        

        public void TakeDamage(int amount)
        {
            _health -= amount;

            if (Absolute(_target._prevPOS.Item1 - _pos.Item1) > Absolute(_target._prevPOS.Item2 - _pos.Item2))
            {
                //gets knocked back
                if (_pos.Item1 > _target._prevPOS.Item1)
                {
                    _pos.Item1 += 2;
                }

                else if (_pos.Item1 < _target._prevPOS.Item1)
                {
                    _pos.Item1 -= 2;
                }
                else
                {
                    //do nothing
                }
            }

            else
            {

                if (_pos.Item2 > _target._prevPOS.Item2)
                {
                    _pos.Item2 += 2;
                }

                else if (_pos.Item2 < _target._prevPOS.Item2)
                {
                    _pos.Item2 -= 2;
                }
                else
                {
                    //do nothing
                }
            }

            if (_health == 0)
            {
                Destroy();
            }
        }

        public void Destroy()
        {
            _isAlive = false;
        }

        private int Absolute(int value)
        {
            if (value < 0)
            {
                value -= value * 2;
                return value;
            }

            else
            {
                return value;
            }

        }

        public bool CheckAlive()
        {
            if (_isAlive)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}
