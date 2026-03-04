using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgII_FirstPlayable_BenF
{
    internal class Coin : Pickup
    {
        Player _player;
        public Coin((int, int) pos, char model, Player player) : base(pos, model)
        {
            _player = player;
        }

        public override void Destroy()
        {
            _player._coins++;

            _isDestroyed = true;
            _pos = (0, 0);
        }
    }
}
