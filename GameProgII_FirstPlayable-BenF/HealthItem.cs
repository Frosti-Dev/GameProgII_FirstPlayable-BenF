using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgII_FirstPlayable_BenF
{
    class HealthItem : Pickup
    {
        public (int, int) _pos;
        public char _model;
        Player _player;

        public HealthItem((int, int) pos, char model, Player player) : base(pos, model)
        {
            _pos = pos;
            _model = model;
            _player = player;
        }


        public override void Destroy()
        {
            _player._health += 3;
            if (_player._health < 10 )
            {
                _player._health = 10;
            }

            _isDestroyed = true;
            _pos = (0, 0);
        }
    }
}
