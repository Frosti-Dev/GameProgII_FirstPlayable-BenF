using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GameProgII_FirstPlayable_BenF
{
    internal interface ICharacter : IEntity
    {
        bool CheckAlive();

        void Update();

        void TakeDamage(int amount);
        
    }
}
