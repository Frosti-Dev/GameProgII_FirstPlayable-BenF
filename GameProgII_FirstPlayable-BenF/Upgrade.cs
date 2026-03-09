using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgII_FirstPlayable_BenF
{
    class Upgrade : Pickup
    {
        Player _player;
        public Upgrade((int, int) pos, char model, Player player) : base(pos, model)
        {
            _player = player;
        }

        public override void Destroy()
        {
            _player._attack = 3;

            _isUsed = true;
            _pos = (0, 0);
        }

    }
}
