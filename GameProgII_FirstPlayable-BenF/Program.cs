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
        static bool isPlayerTurn;
        static ICharacter lastEnemy;

        //create entities
        static Map map = new Map();
        static Player player = new Player(6, 5, map, 10);

        //list of enemies
        static List<ICharacter> enemies = new List<ICharacter>();
        static Enemy enemy1 = new Enemy((10, 10), 10, 'E', player, map);
        static ConfusedEnemy enemy2 = new ConfusedEnemy((5, 10), 10, '?', player, map);
        static HeavyEnemy enemy3 = new HeavyEnemy((15, 10), 15, 'H', player, map);
        static HeavyEnemy enemy4 = new HeavyEnemy((64, 24), 15, 'H', player, map);
        static HeavyEnemy enemy5 = new HeavyEnemy((78, 24), 15, 'H', player, map);
        static HeavyEnemy enemy6 = new HeavyEnemy((63, 28), 15, 'H', player, map);
        static HeavyEnemy enemy7 = new HeavyEnemy((68, 31), 15, 'H', player, map);
        static Enemy enemy8 = new Enemy((62, 3), 10, 'E', player, map);
        static Enemy enemy9 = new Enemy((70, 2), 10, 'E', player, map);
        static Enemy enemy10 = new Enemy((79, 3), 10, 'E', player, map);
        static Enemy enemy11 = new Enemy((79, 6), 10, 'E', player, map);
        static Enemy enemy12 = new Enemy((79, 11), 10, 'E', player, map);
        static Enemy enemy13 = new Enemy((70, 11), 10, 'E', player, map);
        static Enemy enemy14 = new Enemy((63, 11), 10, 'E', player, map);
        static Enemy enemy15 = new Enemy((78, 28), 10, 'E', player, map);
        static Enemy enemy16 = new Enemy((63, 31), 10, 'E', player, map);
        static Enemy enemy17 = new Enemy((7, 27), 10, 'E', player, map);
        static Enemy enemy18 = new Enemy((7, 30), 10, 'E', player, map);
        static Enemy enemy19 = new Enemy((9, 33), 10, 'E', player, map);
        static Enemy enemy20 = new Enemy((16, 33), 10, 'E', player, map);
        static Enemy enemy21 = new Enemy((22, 33), 10, 'E', player, map);
        static Enemy enemy22 = new Enemy((22, 31), 10, 'E', player, map);
        static Enemy enemy23 = new Enemy((19, 30), 10, 'E', player, map);
        static Enemy enemy24 = new Enemy((19, 31), 10, 'E', player, map);
        static Enemy enemy25 = new Enemy((19, 24), 10, 'E', player, map);
        


        //list of pickups
        static List<IEntity> pickups = new List<IEntity>();
        static Coin coin1 = new Coin((11, 3), 'o', player);
        static Coin coin2 = new Coin((24, 1), 'o', player);
        static Coin coin3 = new Coin((62, 10), 'o', player);
        static Coin coin4 = new Coin((81, 4), 'o', player);
        static Coin coin5 = new Coin((82, 29), 'o', player);
        static Coin coin6 = new Coin((74, 33), 'o', player);
        static Coin coin7 = new Coin((62, 24), 'o', player);
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
        static HealthItem healthPickup3 = new HealthItem((78, 24), '+', player);
        static HealthItem healthPickup4 = new HealthItem((81, 10), '+', player);
        static HealthItem healthPickup5 = new HealthItem((63, 32), '+', player);



        //list of hazards
        static List<IEntity> hazards = new List<IEntity>();
        static Hazard hazard1 = new Hazard((4, 8), '#');
        static Hazard hazard2 = new Hazard((5, 8), '#');
        static Hazard hazard3 = new Hazard((4, 9), '#');
        static Hazard hazard4 = new Hazard((5, 9), '#');


        #endregion

        static public void CheckHits()
        {
            /*
             * Checks Entity Collision
             */
            (int, int) playerPos = (player._posX, player._posY); //converts player POS into (int,int)

            if(isPlayerTurn)
            {
                foreach (ICharacter enemy in enemies) //checks if player hit any enemies
                {
                    if (playerPos == enemy.CheckPOS(false))
                    {
                        enemy.TakeDamage(player._attack);
                        lastEnemy = enemy;
                        player._posX = player._prevPOS.Item1;
                        player._posY = player._prevPOS.Item2;
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

                }
                
                
            }

            else //enemy turn
            {
                foreach(ICharacter enemy in enemies) //checks if enemy hit player
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
                            if(enemy.CheckPOS(false) == otherEnemy.CheckPOS(false))
                            {
                                enemy.SetPOS(enemy.CheckPOS(true));
                            }
                        }
                    }
                }

            }
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            //int scale = 5;
            //Console.SetWindowSize(Console.WindowWidth * scale, Console.WindowHeight * scale);

            map.MakeOccupiedMap(); //make boundary map

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

            #endregion

            Console.WriteLine("Please enter full screen and then press any key to play!");
            Console.ReadKey(true);

            /*
             * GAMEPLAY LOOP
             */

            while (player._isAlive)
            {
                player._prevPOS = (player._posX, player._posY);

                isPlayerTurn = true;
                Console.Clear();
                map.DisplayMap();


                //display HUD
                Console.WriteLine($"Player Health: {player._health}");
                Console.WriteLine($"Player Attack: {player._attack}");
                Console.WriteLine($"Coins: {player._coins}");
                if(lastEnemy != null)
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
                foreach(ICharacter enemy in enemies)
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
                        Console.Clear();
                        //map.DisplayMap();

                        //display hud
                        Console.WriteLine($"Player Health: {player._health}");
                        Console.WriteLine($"Player Attack: {player._attack}");
                        Console.WriteLine($"Coins: {player._coins}");
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
                foreach (ICharacter enemy in enemies)
                {

                    if (enemy.CheckAlive() == true)
                    {
                        enemy.Update();
                    }
                }

                CheckHits();

                /*
                 * WIN CONDITION CHECK
                 */

                foreach(ICharacter enemy in enemies)
                {
                    
                    if (enemy.CheckAlive() == false)
                    {
                        enemiesDead++;
                 
                    }

                    if (enemy.CheckAlive() == true)
                    {
                        continue;
                    }

                    if(enemiesDead == enemies.Count)
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
