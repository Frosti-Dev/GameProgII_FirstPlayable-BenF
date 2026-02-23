using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgII_FirstPlayable_BenF
{
    internal class Pickup : IEntity
    {
        public (int, int) _pos;
        public char _model;
        public bool _isDestroyed;

        public Pickup((int,int) pos, char model)
        {
            _pos = pos;

            _model = model;
        }

        public void Draw()
        {
            if (!_isDestroyed)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(_pos.Item1, _pos.Item2);

                Console.Write(_model);

                Console.SetCursorPosition(_pos.Item1, _pos.Item2);
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            
        }

        public void Destroy()
        {
            _isDestroyed = true;
            _pos = (0, 0);
        }
    }
}
