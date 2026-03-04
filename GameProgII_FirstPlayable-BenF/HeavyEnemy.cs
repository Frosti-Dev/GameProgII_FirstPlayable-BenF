using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GameProgII_FirstPlayable_BenF
{
    class HeavyEnemy : ICharacter
    {
        public (int, int) _pos;

        public int _health;
        public bool _isAlive = true;

        public char _model;
        public Player _target;

        public int _attack = 4;


        public HeavyEnemy((int, int) pos, int health, char model, Player target)
        {
            _pos = pos;
            _health = health;
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
            Random random = new Random();
            int rNum = random.Next(0, 2);
            if (Absolute(_target._posX - _pos.Item1) > Absolute(_target._posY - _pos.Item2))
            {
                //aligns enemy x with player x
                if (_pos.Item1 > _target._posX)
                {
                    if (rNum == 1)
                    {
                        _pos.Item1 -= 1;
                    }

                    else
                    {
                        //do nothing
                    }
                }

                else if (_pos.Item1 < _target._posX)
                {
                    if (rNum == 1)
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
                    //do nothing
                }
            }

            else
            {
                //aligns enemy y with player y
                if (_pos.Item2 > _target._posY)
                {
                    if (rNum == 1)
                    {
                        _pos.Item2 -= 1;
                    }

                    else
                    {
                        //do nothing
                    }
                }

                else if (_pos.Item2 < _target._posY)
                {
                    if (rNum == 1)
                    {
                        _pos.Item2 += 1;
                    }

                    else
                    {
                        //do nothing
                    }
                }
                else
                {
                    //do nothing
                }
            }

            #region Debug Lines
            //Debug.WriteLine($"{Normalize(_target._posX - _pos.Item1)}, {Normalize(_target._posY - _pos.Item2)}"); ///(relative to the target pos)
            //Debug.WriteLine($"{_model} Pos: {_pos}"); ///(pos)
            #endregion
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

            if (_health < 0)
            {
                Destroy();
                _pos = (0, 0);
            }
        }

        public void Destroy()
        {
            _health = 0;
            _isAlive = false;
            _pos = (0, 0);
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

        public (int, int) CheckPOS()
        {
            return _pos;
        }

        public int CheckAttack()
        {
            return _attack;
        }
    }
}
