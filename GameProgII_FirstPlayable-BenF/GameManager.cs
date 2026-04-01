using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace GameProgII_FirstPlayable_BenF
{
    internal class GameManager
    {
        #region Variables
        static int enemiesDead;
        static bool hasWon;
        static string area;
        static bool isPlayerTurn;
        static ICharacter lastEnemy;

        static int prevWindowWidth;
        static int prevWindowHeight;

        //create entities
        static Map map = new Map();
        static Player player = new Player(6, 5, map, 10);

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

        #region read data
        //coin data
        static public string coinPath = @"Files/CoinInfoFile.txt";
        static public string[] coinData = File.ReadAllLines(coinPath);

        //health pickup data
        static public string healthPath = @"Files/HealthInfoFile.txt";
        static public string healthData = File.ReadAllText(healthPath);

        //attack pickup data
        static public string attackPath = @"Files/AttackInfoFile.txt";
        static public string attackData = File.ReadAllText(healthPath);

        #endregion


        public GameManager()
        {

        }

        static private void CheckHits()
        {
            /*
             * Checks Entity Collision
             */
            (int, int) playerPos = (player._posX, player._posY); //converts player POS into (int,int)

            if (isPlayerTurn)
            {
                foreach (ICharacter enemy in enemies) //checks if player hit any enemies
                {
                    if (playerPos == enemy.CheckPOS(false))
                    {
                        enemy.TakeDamage(player._attack);
                        lastEnemy = enemy;
                        player.SetPOS(player._prevPOS);
                    }
                }

                foreach (Pickup pickup in pickups) //checks if player hit any pickups
                {
                    if (playerPos == pickup._pos)
                    {
                        pickup.Destroy();
                        player.SetPOS(player._prevPOS);
                    }
                }

                foreach (Hazard hazard in hazards)
                {
                    if (playerPos == hazard._pos)
                    {
                        hazard.Effect(player);
                    }

                    foreach(Enemy enemy in enemies)
                    {
                        if(enemy.CheckPOS(false) == hazard._pos)
                        {
                            hazard.Effect(enemy);
                        }
                    }

                }


            }

            else //enemy turn
            {
                foreach (ICharacter enemy in enemies) //checks if enemy hit player
                {
                    if (playerPos == enemy.CheckPOS(false))
                    {
                        player.TakeDamage(enemy.CheckAttack());
                        enemy.SetPOS(enemy.CheckPOS(true));
                    }
                }

                foreach (ICharacter enemy in enemies) //check if enemy hit enemy
                {
                    foreach (ICharacter otherEnemy in enemies)
                    {
                        if (enemy != otherEnemy)
                        {
                            if (enemy.CheckPOS(false) == otherEnemy.CheckPOS(false))
                            {
                                enemy.SetPOS(enemy.CheckPOS(true));
                            }
                        }
                    }
                }

            }

            if(Console.WindowHeight > 38)
            {
                Console.SetCursorPosition(0, 38);
                //update HUD
                if (player._health < 10)
                {
                    Console.WriteLine($"Player Health: 0{player._health}");
                }
                else
                {
                    Console.WriteLine($"Player Health: {player._health}");
                }
                Console.WriteLine($"Player Attack: 0{player._attack}");
                Console.WriteLine($"Coins: {player._coins}");
                Console.WriteLine($"Area: {area}");
            }
            

        }

        static private void CheckArea()
        {
            if (player._posY < 13)
            {
                if (player._posX > 26)
                {
                    if (player._posX < 57) area = "Hallway";

                    else if (player._posX > 57) area = "Area  2";

                }

                else if (player._posX < 26) area = "Area  1";
            }

            else if (player._posY > 22)
            {
                if (player._posX > 26)
                {
                    if (player._posX < 57) area = "Hallway";

                    else if (player._posX > 57) area = "Area  4";

                }

                else if (player._posX < 26) area = "Area  3";
            }

            else
            {
                area = "Hallway";
            }

        }

        static private void ChangeWindowSize()
        {
            int curWindowWidth = Console.WindowWidth;
            int curWindowHeight = Console.WindowHeight;

            if(curWindowWidth == prevWindowWidth)
            {
                return;
            }

            else if (curWindowHeight == prevWindowHeight)
            {
                return;
            }

            else
            {
                Console.Clear();
                map.DisplayMap();
            }

            prevWindowHeight = curWindowHeight;
            prevWindowWidth = curWindowWidth;
        }

        static public void GameStart()
        {
            Console.CursorVisible = false;

            map.MakeOccupiedMap(); //make boundary map
            map.MakeReferenceMap(); //make reference map

            #region add to lists
            pickups.Add(coin1);
            pickups.Add(coin2);
            pickups.Add(coin3);
            pickups.Add(coin4);
            pickups.Add(coin5);
            pickups.Add(coin6);
            pickups.Add(coin7);
            pickups.Add(coin8);
            pickups.Add(coin9);
            pickups.Add(coin10);

            //if (File.Exists(coinPath))
            //{
            //    for (int i = 0; i < coinData.Length; i++)
            //    {
            //        pickups.Add(new Coin(coinData[i], 'o', player));
            //    }
            //}
            pickups.Add(healthPickup1);
            pickups.Add(healthPickup2);
            pickups.Add(healthPickup3);
            pickups.Add(healthPickup4);
            pickups.Add(healthPickup5);

            pickups.Add(upgrade1);
            pickups.Add(upgrade2);
            pickups.Add(upgrade3);
            pickups.Add(upgrade4);
            pickups.Add(upgrade5);

            hazards.Add(hazard1);
            hazards.Add(hazard2);
            hazards.Add(hazard3);
            hazards.Add(hazard4);
            hazards.Add(hazard5);
            hazards.Add(hazard6);
            hazards.Add(hazard7);
            hazards.Add(hazard8);
            hazards.Add(hazard9);
            hazards.Add(hazard10);
            hazards.Add(hazard11);
            hazards.Add(hazard12);
            hazards.Add(hazard13);
            hazards.Add(hazard14);
            hazards.Add(hazard15);
            hazards.Add(hazard16);
            hazards.Add(hazard17);
            hazards.Add(hazard18);
            hazards.Add(hazard19);
            hazards.Add(hazard20);
            hazards.Add(hazard21);
            hazards.Add(hazard22);
            hazards.Add(hazard23);
            hazards.Add(hazard24);
            hazards.Add(hazard25);
            hazards.Add(hazard26);
            hazards.Add(hazard27);
            hazards.Add(hazard28);
            hazards.Add(hazard29);
            hazards.Add(hazard30);
            hazards.Add(hazard31);
            hazards.Add(hazard32);
            hazards.Add(hazard33);
            hazards.Add(hazard34);
            hazards.Add(hazard35);
            hazards.Add(hazard36);
            hazards.Add(hazard37);


            enemies.Add(enemy1);
            enemies.Add(enemy2);
            enemies.Add(enemy3);
            enemies.Add(enemy4);
            enemies.Add(enemy5);
            enemies.Add(enemy6);
            enemies.Add(enemy7);
            enemies.Add(enemy8);
            enemies.Add(enemy9);
            enemies.Add(enemy10);
            enemies.Add(enemy11);
            enemies.Add(enemy12);
            enemies.Add(enemy13);
            enemies.Add(enemy14);
            enemies.Add(enemy15);
            enemies.Add(enemy16);
            enemies.Add(enemy17);
            enemies.Add(enemy18);
            enemies.Add(enemy19);
            enemies.Add(enemy20);
            enemies.Add(enemy21);
            enemies.Add(enemy22);
            enemies.Add(enemy23);
            enemies.Add(enemy24);
            enemies.Add(enemy25);


            //add to area Lists
            area1Enemies.Add(enemy1);
            area1Enemies.Add(enemy2);
            area1Enemies.Add(enemy3);

            area2Enemies.Add(enemy8);
            area2Enemies.Add(enemy9);
            area2Enemies.Add(enemy10);
            area2Enemies.Add(enemy11);
            area2Enemies.Add(enemy12);
            area2Enemies.Add(enemy13);
            area2Enemies.Add(enemy14);

            area3Enemies.Add(enemy17);
            area3Enemies.Add(enemy18);
            area3Enemies.Add(enemy19);
            area3Enemies.Add(enemy20);
            area3Enemies.Add(enemy21);
            area3Enemies.Add(enemy22);
            area3Enemies.Add(enemy23);
            area3Enemies.Add(enemy24);
            area3Enemies.Add(enemy25);

            area4Enemies.Add(enemy4);
            area4Enemies.Add(enemy5);
            area4Enemies.Add(enemy6);
            area4Enemies.Add(enemy7);
            area4Enemies.Add(enemy15);
            area4Enemies.Add(enemy16);


            #endregion

            Console.WriteLine("Please enter full screen and then press any key to play!");
            Console.ReadKey(true);

            Console.Clear();

            map.DisplayMap();

            //display HUD
            Console.WriteLine($"Player Health: {player._health}");
            Console.WriteLine($"Player Attack: {player._attack}");
            Console.WriteLine($"Coins: {player._coins}");
            Console.WriteLine($"Area: {area}");

            /*
             * GAMEPLAY LOOP
             */


            while (player._isAlive)
            {
                player._prevPOS = (player._posX, player._posY);

                CheckArea();

                //If Window Size is changed, reprint map
                ChangeWindowSize();

                isPlayerTurn = true;

                if (lastEnemy != null)
                {
                    Console.WriteLine($"Last Enemy: {lastEnemy.CheckModel()} Health: {lastEnemy.CheckHealth()} Strength: {lastEnemy.CheckAttack()}");
                }


                //display pickups
                foreach (Pickup pickup in pickups)
                {
                    if (!pickup._isUsed)
                    {
                        pickup.Draw();
                    }
                }

                foreach (Hazard hazard in hazards)
                {
                    hazard.Draw();
                }

                //display enemies
                foreach (ICharacter enemy in enemies)
                {
                    if (enemy.CheckAlive() == true)
                    {
                        enemy.Draw();
                    }
                }

                //display player
                player.Draw();

                CheckHits();


                if (isPlayerTurn)
                {

                    player.Update();
                    //map.DisplayMap();

                    if (lastEnemy != null)
                    {
                        Console.WriteLine($"Last Enemy: {lastEnemy.CheckModel()} Health: {lastEnemy.CheckHealth()} Strength: {lastEnemy.CheckAttack()}");
                    }

                    //display pickups
                    foreach (Pickup pickup in pickups)
                    {
                        if (!pickup._isUsed)
                        {
                            pickup.Draw();
                        }
                    }

                    foreach (Hazard hazard in hazards)
                    {
                        hazard.Draw();
                    }

                    //display enemies
                    foreach (ICharacter enemy in enemies)
                    {
                        if (enemy.CheckAlive() == true)
                        {
                            enemy.Draw();
                        }
                    }

                    //display player
                    player.Draw();

                    CheckHits();

                    isPlayerTurn = false;
                }

                //move enemies (if still alive)

                if (area == "Area  1")
                {
                    foreach (ICharacter enemy in area1Enemies)
                    {
                        if (enemy.CheckAlive() == true)
                        {
                            enemy.Update();
                        }
                    }
                }

                else if (area == "Area  2")
                {
                    foreach (ICharacter enemy in area2Enemies)
                    {
                        if (enemy.CheckAlive() == true)
                        {
                            enemy.Update();
                        }
                    }
                }

                else if (area == "Area  3")
                {
                    foreach (ICharacter enemy in area3Enemies)
                    {
                        if (enemy.CheckAlive() == true)
                        {
                            enemy.Update();
                        }
                    }
                }

                else if (area == "Area  4")
                {
                    foreach (ICharacter enemy in area4Enemies)
                    {
                        if (enemy.CheckAlive() == true)
                        {
                            enemy.Update();
                        }
                    }
                }

                else
                {
                    //nobody move
                }
                CheckHits();

                //Thread.Sleep(100);

                /*
                 * WIN CONDITION CHECK
                 */

                foreach (ICharacter enemy in enemies)
                {

                    if (enemy.CheckAlive() == false)
                    {
                        enemiesDead++;

                    }

                    if (enemy.CheckAlive() == true)
                    {
                        continue;
                    }

                    if (enemiesDead == enemies.Count)
                    {
                        hasWon = true;
                        break;
                    }
                }

                enemiesDead = 0;

                if (hasWon)
                {
                    break;
                }


                if (!player._isAlive)
                {
                    hasWon = false;
                    break;
                }

            }

            #region Win Screens
            if (hasWon)
            {
                Console.Clear();
                Console.WriteLine("You have Won!");
            }

            else
            {
                Console.Clear();
                Console.WriteLine("You have lost!");
            }
            #endregion

        }
    }
}
