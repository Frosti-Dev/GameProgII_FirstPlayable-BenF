using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgII_FirstPlayable_BenF
{
    internal class Hazard : IEntity
    {
        public (int, int) _pos;
        public char _model;

        public Hazard((int,int) pos, char model)
        {
            _pos = pos;
            _model = model;
        }

        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(_pos.Item1, _pos.Item2);

            Console.Write(_model);

            Console.SetCursorPosition(_pos.Item1, _pos.Item2);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Destroy()
        {
            //should never happen
            _pos = (0, 0);
        }

        virtual public void Effect(ICharacter victim)
        {
            victim.TakeDamage(1);
        }
    }
}
