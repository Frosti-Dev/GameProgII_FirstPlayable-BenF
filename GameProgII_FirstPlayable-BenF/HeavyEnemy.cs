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
    class HeavyEnemy : Enemy
    {
        
        public HeavyEnemy((int, int) pos, int health, char model, Player target): base(pos, health, model, target) 
        {
            _attack = 4;
        }


        override public void Update()
        {
            _prevPOS = _pos;

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
    }
}
