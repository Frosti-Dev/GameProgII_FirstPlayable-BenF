using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgII_FirstPlayable_BenF
{
    class HealthItem : Pickup
    {
        Player _player;

        public HealthItem((int, int) pos, char model, Player player) : base(pos, model)
        {
            _player = player;
        }


        public override void Use()
        {
            _player._health += 3;

            _isUsed = true;
            _pos = (0, 0);
        }
    }
}
