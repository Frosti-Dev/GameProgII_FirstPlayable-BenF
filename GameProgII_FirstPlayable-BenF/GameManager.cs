using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgII_FirstPlayable_BenF
{
    class GameManager
    {
        #region Variables

        //create entities
        static Map map = new Map();
        static Player player = new Player(6, 5, map, 10);

        //list of enemies
        static Enemy e1 = new Enemy((10, 10), 10, 'E', player, map);
        static ConfusedEnemy e2 = new ConfusedEnemy((5, 10), 10, '?', player, map);
        static HeavyEnemy e3 = new HeavyEnemy((15, 10), 15, 'H', player, map);
        static HeavyEnemy e4 = new HeavyEnemy((64, 24), 15, 'H', player, map);
        static HeavyEnemy e5 = new HeavyEnemy((78, 24), 15, 'H', player, map);
        static HeavyEnemy e6 = new HeavyEnemy((63, 28), 15, 'H', player, map);
        static HeavyEnemy e7 = new HeavyEnemy((68, 31), 15, 'H', player, map);
        static Enemy e8 = new Enemy((62, 3), 10, 'E', player, map);
        static Enemy e9 = new Enemy((70, 2), 10, 'E', player, map);
        static Enemy e10 = new Enemy((79, 3), 10, 'E', player, map);
        static Enemy e11 = new Enemy((79, 6), 10, 'E', player, map);
        static Enemy e12 = new Enemy((79, 11), 10, 'E', player, map);
        static Enemy e13 = new Enemy((70, 11), 10, 'E', player, map);
        static Enemy e14 = new Enemy((63, 11), 10, 'E', player, map);
        static Enemy e15 = new Enemy((78, 28), 10, 'E', player, map);
        static Enemy e16 = new Enemy((63, 31), 10, 'E', player, map);
        static Enemy e17 = new Enemy((10, 10), 10, 'E', player, map);
        static Enemy e18 = new Enemy((10, 10), 10, 'E', player, map);
        static Enemy e19 = new Enemy((10, 10), 10, 'E', player, map);
        static Enemy e20 = new Enemy((10, 10), 10, 'E', player, map);
        static Enemy e21 = new Enemy((10, 10), 10, 'E', player, map);
        static Enemy e22 = new Enemy((10, 10), 10, 'E', player, map);
        static Enemy e23 = new Enemy((10, 10), 10, 'E', player, map);
        static Enemy e24 = new Enemy((10, 10), 10, 'E', player, map);
        static Enemy e25 = new Enemy((10, 10), 10, 'E', player, map);
        static Enemy e26 = new Enemy((10, 10), 10, 'E', player, map);
        static Enemy e27 = new Enemy((10, 10), 10, 'E', player, map);
        static Enemy e28 = new Enemy((10, 10), 10, 'E', player, map);
        static Enemy e29 = new Enemy((10, 10), 10, 'E', player, map);
        static Enemy e30 = new Enemy((10, 10), 10, 'E', player, map);


        //list of pickups
        static Coin coin = new Coin((11, 3), 'o', player);
        static Upgrade upgrade = new Upgrade((21, 11), '/', player);
        static HealthItem healthPickup = new HealthItem((21, 3), '+', player);


        //list of hazards
        static Hazard hazard1 = new Hazard((4, 8), '#');
        static Hazard hazard2 = new Hazard((5, 8), '#');
        static Hazard hazard3 = new Hazard((4, 9), '#');
        static Hazard hazard4 = new Hazard((5, 9), '#');


        #endregion

        //public ICharacter EnemyReturn(int enemyNum)
        //{
        //    for (int i = 0; i < 30; i++ )
        //    {
        //        List<ICharacter> enemies = new List<ICharacter>();

                

        //        enemies.Add(new Enemy);
        //    }
        //}


    }
}
