using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameProgII_FirstPlayable_BenF
{
    internal class Program
    {
        #region Variables
        static int enemiesDead;
        static bool hasWon;
        static string area;
        static bool isPlayerTurn;
        static ICharacter lastEnemy;

        //create entities
        static Map map = new Map();
        static Player player = new Player(6, 5, map, 10);
        //static GameManager = new GameManager();

        //list of enemies
        static List<ICharacter> enemies = new List<ICharacter>();
        //area1;
        static List<ICharacter> area1Enemies = new List<ICharacter>();
        static Enemy enemy1 = new Enemy((10, 10), 10, 'E', player, map);
        static ConfusedEnemy enemy2 = new ConfusedEnemy((5, 10), 10, '?', player, map);
        static HeavyEnemy enemy3 = new HeavyEnemy((15, 10), 15, 'H', player, map);

        //area2
        static List<ICharacter> area2Enemies = new List<ICharacter>();
        static Enemy enemy8 = new Enemy((62, 3), 10, 'E', player, map);
        static Enemy enemy9 = new Enemy((70, 2), 10, 'E', player, map);
        static Enemy enemy10 = new Enemy((79, 3), 10, 'E', player, map);
        static Enemy enemy11 = new Enemy((79, 6), 10, 'E', player, map);
        static Enemy enemy12 = new Enemy((79, 11), 10, 'E', player, map);
        static Enemy enemy13 = new Enemy((70, 11), 10, 'E', player, map);
        static Enemy enemy14 = new Enemy((63, 11), 10, 'E', player, map);

        //area 3
        static List<ICharacter> area3Enemies = new List<ICharacter>();
        static Enemy enemy17 = new Enemy((7, 27), 10, 'E', player, map);
        static Enemy enemy18 = new Enemy((7, 30), 10, 'E', player, map);
        static Enemy enemy19 = new Enemy((9, 33), 10, 'E', player, map);
        static Enemy enemy20 = new Enemy((16, 33), 10, 'E', player, map);
        static Enemy enemy21 = new Enemy((22, 33), 10, 'E', player, map);
        static Enemy enemy22 = new Enemy((22, 31), 10, 'E', player, map);
        static Enemy enemy23 = new Enemy((19, 30), 10, 'E', player, map);
        static Enemy enemy24 = new Enemy((19, 31), 10, 'E', player, map);
        static Enemy enemy25 = new Enemy((19, 24), 10, 'E', player, map);

        //area4
        static List<ICharacter> area4Enemies = new List<ICharacter>();
        static HeavyEnemy enemy4 = new HeavyEnemy((64, 24), 15, 'H', player, map);
        static HeavyEnemy enemy5 = new HeavyEnemy((78, 24), 15, 'H', player, map);
        static HeavyEnemy enemy6 = new HeavyEnemy((63, 28), 15, 'H', player, map);
        static HeavyEnemy enemy7 = new HeavyEnemy((68, 31), 15, 'H', player, map);
        static Enemy enemy15 = new Enemy((78, 28), 10, 'E', player, map);
        static Enemy enemy16 = new Enemy((63, 31), 10, 'E', player, map);



        //list of pickups
        static List<IEntity> pickups = new List<IEntity>();
        static Coin coin1 = new Coin((11, 3), 'o', player);
        static Coin coin2 = new Coin((24, 1), 'o', player);
        static Coin coin3 = new Coin((62, 10), 'o', player);
        static Coin coin4 = new Coin((81, 4), 'o', player);
        static Coin coin5 = new Coin((82, 29), 'o', player);
        static Coin coin6 = new Coin((74, 33), 'o', player);
        static Coin coin7 = new Coin((62, 25), 'o', player);
        static Coin coin8 = new Coin((14, 29), 'o', player);
        static Coin coin9 = new Coin((14, 34), 'o', player);
        static Coin coin10 = new Coin((4, 34), 'o', player);

        static Upgrade upgrade1 = new Upgrade((21, 11), '/', player);
        static Upgrade upgrade2 = new Upgrade((63, 3), '/', player);
        static Upgrade upgrade3 = new Upgrade((72, 17), '/', player);
        static Upgrade upgrade4 = new Upgrade((39, 6), '/', player);
        static Upgrade upgrade5 = new Upgrade((41, 28), '/', player);

        static HealthItem healthPickup1 = new HealthItem((21, 3), '+', player);
        static HealthItem healthPickup2 = new HealthItem((76, 2), '+', player);
        static HealthItem healthPickup3 = new HealthItem((78, 25), '+', player);
        static HealthItem healthPickup4 = new HealthItem((81, 10), '+', player);
        static HealthItem healthPickup5 = new HealthItem((63, 32), '+', player);



        //list of hazards
        static List<IEntity> hazards = new List<IEntity>();
        static Hazard hazard1 = new Hazard((4, 8), '#');
        static Hazard hazard2 = new Hazard((5, 8), '#');
        static Hazard hazard3 = new Hazard((4, 9), '#');
        static Hazard hazard4 = new Hazard((5, 9), '#');
        static Hazard hazard5 = new Hazard((70, 27), '#');
        static Hazard hazard6 = new Hazard((71, 27), '#');
        static Hazard hazard7 = new Hazard((72, 27), '#');
        static Hazard hazard8 = new Hazard((73, 27), '#');
        static Hazard hazard9 = new Hazard((74, 27), '#');
        static Hazard hazard10 = new Hazard((74, 28), '#');
        static Hazard hazard11 = new Hazard((71, 28), '#');
        static Hazard hazard12 = new Hazard((70, 28), '#');
        static Hazard hazard13 = new Hazard((69, 28), '#');
        static Hazard hazard14 = new Hazard((69, 29), '#');
        static Hazard hazard15 = new Hazard((68, 29), '#');
        static Hazard hazard16 = new Hazard((71, 29), '#');
        static Hazard hazard17 = new Hazard((73, 29), '#');
        static Hazard hazard18 = new Hazard((74, 29), '#');
        static Hazard hazard19 = new Hazard((75, 29), '#');
        static Hazard hazard20 = new Hazard((72, 29), '#');
        static Hazard hazard21 = new Hazard((73, 28), '#');
        static Hazard hazard22 = new Hazard((72, 28), '#');
        static Hazard hazard23 = new Hazard((75, 28), '#');
        static Hazard hazard24 = new Hazard((76, 29), '#');
        static Hazard hazard25 = new Hazard((70, 29), '#');
        static Hazard hazard26 = new Hazard((75, 30), '#');
        static Hazard hazard27 = new Hazard((74, 30), '#');
        static Hazard hazard28 = new Hazard((73, 30), '#');
        static Hazard hazard29 = new Hazard((72, 30), '#');
        static Hazard hazard30 = new Hazard((71, 30), '#');
        static Hazard hazard31 = new Hazard((70, 30), '#');
        static Hazard hazard32 = new Hazard((69, 30), '#');
        static Hazard hazard33 = new Hazard((70, 31), '#');
        static Hazard hazard34 = new Hazard((71, 31), '#');
        static Hazard hazard35 = new Hazard((72, 31), '#');
        static Hazard hazard36 = new Hazard((73, 31), '#');
        static Hazard hazard37 = new Hazard((74, 31), '#');

        #endregion

        static void Main(string[] args)
        {

            GameManager.GameStart();

        }
    }
}

#region old code
/*
static void CheckCollides(bool PlayerTurn)
{
    (int, int) playerPos = (playerPosX, playerPosY);

    if (PlayerTurn)
    {
        if (playerPos == enemy1Pos)
        {
            enemy1Health -= 1;

            //back to spawn
            enemy1Pos = (1, 12);
        }

        else if (playerPos == enemy2Pos)
        {
            enemy2Health -= 1;

            //back to spawn
            enemy2Pos = (23, 1);
        }

        else if (playerPos == enemy3Pos)
        {
            enemy3Health -= 1;

            //back to spawn
            enemy3Pos = (23, 12);
        }

        else
        {
            //do nothing
        }

        playerTurn = false;
    }

    else
    {
        if (playerPos == enemy1Pos)
        {
            playerHealth -= 1;

            //back to spawn
            enemy1Pos = (1, 12);
        }

        else if (playerPos == enemy2Pos)
        {
            playerHealth -= 1;

            //back to spawn
            enemy2Pos = (23, 1);
        }

        else if (playerPos == enemy3Pos)
        {
            playerHealth -= 1;

            //back to spawn
            enemy3Pos = (23, 12);
        }

        else
        {
            //do nothing
        }

        playerTurn = true;
    }
}
*/
#endregion
