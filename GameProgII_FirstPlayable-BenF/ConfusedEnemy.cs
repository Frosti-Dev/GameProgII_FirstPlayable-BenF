using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgII_FirstPlayable_BenF
{
    class ConfusedEnemy : Enemy
    {
        private Random r = new Random();

        public ConfusedEnemy((int, int) pos, int health, char model, Player target, Map map) : base(pos, health, model, target, map)
        {
            _attack = 1;
        }

        override public void Update()
        {
            _prevPOS = _pos;

            int rNum = r.Next(0, 4);

            if (rNum == 0)
            {
                _pos.Item1--; ;

                if (_map.isOccupiedMap[_pos.Item1, _pos.Item2] == true)
                {
                    _pos = _prevPOS;
                }
            }

            else if (rNum == 1)
            {
                _pos.Item1++;

                if (_map.isOccupiedMap[_pos.Item1, _pos.Item2] == true)
                {
                    _pos = _prevPOS;
                }
            }

            else if (rNum == 2)
            {
                 _pos.Item2--;

                if (_map.isOccupiedMap[_pos.Item1, _pos.Item2] == true)
                {
                    _pos = _prevPOS;
                }

            }

            else
            {
                _pos.Item2++;

                if (_map.isOccupiedMap[_pos.Item1, _pos.Item2] == true)
                {
                    _pos = _prevPOS;
                }
            }

        }

    }
}
