using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgII_FirstPlayable_BenF
{
    class ConfusedEnemy : Enemy
    {
        public int _limiter;

        private Random r = new Random();


        public ConfusedEnemy((int, int) pos, int health, char model, int limiter, Player target) : base(pos, health, model, target)
        {
            _limiter = limiter;   
        }

        override public void Update()
        {
            _prevPOS = _pos;

            int rNum = r.Next(0, 4);

            if (rNum == 0)
            {
                _pos.Item1 -= 1;

                if (_pos.Item1 <= 0)
                {
                    _pos.Item1 += 1;
                }
            }

            else if (rNum == 1)
            {
                _pos.Item1 += 1;

                if (_pos.Item1 > 24 * _limiter)
                {
                    _pos.Item1 -= 1;
                }
            }

            else if (rNum == 2)
            {
                 _pos.Item2 -= 1;

                if (_pos.Item2 <= 0)
                {
                    _pos.Item2 += 1;
                }

            }

            else
            {
                _pos.Item2 += 1;

                if (_pos.Item2 > 12 * _limiter)
                {
                    _pos.Item2 -= 1;
                }
            }

        }

    }
}
