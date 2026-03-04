using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgII_FirstPlayable_BenF
{
    internal class Program
    {
        #region Variables
        static int mapScale = 1;
        static bool hasWon;
        static bool isPlayerTurn;

        static Map map = new Map(mapScale);
        static Player player = new Player(3, 3, 25, map, 10, mapScale);

        static List<ICharacter> enemies = new List<ICharacter>();
        static NormalEnemy enemy1 = new NormalEnemy((10, 10), 10, true, 'E', player);
        static ConfusedEnemy enemy2 = new ConfusedEnemy((5, 10), 10, true, '?', player);

        static List<IEntity> pickups = new List<IEntity>();
        static Coin coin1 = new Coin((11, 3), 'o', player);
        static Coin coin2 = new Coin((21, 11), 'o', player);
        static HealthItem healthPickup = new HealthItem((21, 3), '+', player);
       

        #endregion

        static public void CheckHits()
        {
            (int, int) playerPos = (player._posX, player._posY);

            if(isPlayerTurn)
            {
                foreach (ICharacter enemy in enemies)
                {
                    if (playerPos == enemy.CheckPOS())
                    {
                        enemy.TakeDamage(1);
                    }
                }
                
                foreach (Pickup pickup in pickups)
                {
                    if (playerPos == pickup._pos)
                    {
                        pickup.Destroy();
                    }
                }
                
                
            }

            else
            {
                foreach(ICharacter enemy in enemies)
                {
                    if (playerPos == enemy.CheckPOS())
                    {
                        player.TakeDamage(1);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            //add to lists
            pickups.Add(coin1);
            pickups.Add(healthPickup);
            pickups.Add(coin2);

            enemies.Add(enemy1);
            enemies.Add(enemy2);

            while (player._isAlive)
            {
                player._prevPOS = (player._posX, player._posY);

                isPlayerTurn = true;
                Console.Clear();
                map.DisplayMap();

                Console.WriteLine($"Player Health: {player._health}");
                Console.WriteLine($"{enemy1._model} Health: {enemy1._health}");
                Console.WriteLine($"{enemy2._model} Health: {enemy2._health}");
                Console.WriteLine($"Coins: {player._coins}");

                foreach(Pickup pickup in pickups)
                {
                    if (!pickup._isDestroyed)
                    {
                        pickup.Draw();
                    }
                }
                
                foreach(ICharacter enemy in enemies)
                {
                    if (enemy.CheckAlive() == true)
                    {
                        enemy.Draw();
                    }
                }

                

                player.Draw();
                CheckHits();
          

                if (isPlayerTurn)
                {
                    int turnCounter = 0;
                    
                    while(turnCounter < 2)
                    {
                        player.Update();
                        Console.Clear();
                        map.DisplayMap();

                        Console.WriteLine($"Player Health: {player._health}");
                        Console.WriteLine($"{enemy1._model} Health: {enemy1._health}");
                        Console.WriteLine($"{enemy2._model} Health: {enemy2._health}");
                        Console.WriteLine($"Coins: {player._coins}");

                        foreach (Pickup pickup in pickups)
                        {
                            if (!pickup._isDestroyed)
                            {
                                pickup.Draw();
                            }
                        }

                        foreach (ICharacter enemy in enemies)
                        {
                            if (enemy.CheckAlive() == true)
                            {
                                enemy.Draw();
                            }
                        }

                        
                        player.Draw();
                        CheckHits();

                        turnCounter++;
                    }
                    isPlayerTurn = false;
                }
                
                foreach(ICharacter enemy in enemies)
                {
                    if (enemy.CheckAlive() == true)
                    {
                        enemy.Update();
                    }
                }

                Debug.WriteLine($"Bound Check: {map._isOccupied[player._bound]}");

                CheckHits();

                foreach(ICharacter enemy in enemies)
                {
                    if (enemy.CheckAlive() == true)
                    {
                        hasWon = true;
                        break;
                    }
                }

             

                if (!player._isAlive)
                {
                    hasWon = false;
                    break;
                }
            }

            #region Win Conditions
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
