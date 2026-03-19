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

        //list of pickups
        static List<IEntity> pickups = new List<IEntity>();
        static Coin coin = new Coin((11, 3), 'o', player);
        static Upgrade upgrade = new Upgrade((21, 11), '/', player);
        static HealthItem healthPickup = new HealthItem((21, 3), '+', player);


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

            //add to lists
            pickups.Add(coin);
            pickups.Add(healthPickup);
            pickups.Add(upgrade);

            hazards.Add(hazard1);
            hazards.Add(hazard2);
            hazards.Add(hazard3);
            hazards.Add(hazard4);


            enemies.Add(enemy1);
            enemies.Add(enemy2);
            enemies.Add(enemy3);

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
