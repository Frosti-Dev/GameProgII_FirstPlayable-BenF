using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
        static Player player = new Player(6, 5, map, 10, mapScale);

        static List<ICharacter> enemies = new List<ICharacter>();
        static Enemy enemy1 = new Enemy((10, 10), 10, 'E', player);
        static ConfusedEnemy enemy2 = new ConfusedEnemy((5, 10), 10, '?', mapScale, player);
        static HeavyEnemy enemy3 = new HeavyEnemy((15, 10), 15, 'H', player);

        static List<IEntity> pickups = new List<IEntity>();
        static Coin coin = new Coin((11, 3), 'o', player);
        static Upgrade upgrade = new Upgrade((21, 11), '/', player);
        static HealthItem healthPickup = new HealthItem((21, 3), '+', player);
       

        #endregion

        static public void CheckHits()
        {
            (int, int) playerPos = (player._posX, player._posY);

            if(isPlayerTurn)
            {
                foreach (ICharacter enemy in enemies)
                {
                    if (playerPos == enemy.CheckPOS(false))
                    {
                        enemy.TakeDamage(player._attack);
                        player._posX = player._prevPOS.Item1;
                        player._posY = player._prevPOS.Item2;
                    }
                }
                
                foreach (Pickup pickup in pickups)
                {
                    if (playerPos == pickup._pos)
                    {
                        pickup.Use();
                        player.SetPOS(player._prevPOS);
                    }
                }
                
                
            }

            else
            {
                foreach(ICharacter enemy in enemies)
                {
                    if (playerPos == enemy.CheckPOS(false))
                    {
                        player.TakeDamage(enemy.CheckAttack());
                        enemy.SetPOS(enemy.CheckPOS(true));
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            map.MakeOccupiedMap();

            //add to lists
            pickups.Add(coin);
            pickups.Add(healthPickup);
            pickups.Add(upgrade);

            enemies.Add(enemy1);
            enemies.Add(enemy2);
            enemies.Add(enemy3);

            while (player._isAlive)
            {
                player._prevPOS = (player._posX, player._posY);

                isPlayerTurn = true;
                Console.Clear();
                map.DisplayMap();

                Console.WriteLine($"Player Health: {player._health}");
                Console.WriteLine($"Player Attack: {player._attack}");
                Console.WriteLine($"Coins: {player._coins}");
                Console.WriteLine($"{enemy1._model} Health: {enemy1._health}");
                Console.WriteLine($"{enemy2._model} Health: {enemy2._health}");
                Console.WriteLine($"{enemy3._model} Health: {enemy3._health}");



                foreach (Pickup pickup in pickups)
                {
                    if (!pickup._isUsed)
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
                    
                        player.Update();
                        Console.Clear();
                        map.DisplayMap();


                        Console.WriteLine($"Player Health: {player._health}");
                        Console.WriteLine($"Player Attack: {player._attack}");
                        Console.WriteLine($"Coins: {player._coins}");
                        Console.WriteLine($"{enemy1._model} Health: {enemy1._health}");
                        Console.WriteLine($"{enemy2._model} Health: {enemy2._health}");
                        Console.WriteLine($"{enemy3._model} Health: {enemy3._health}");

                        foreach (Pickup pickup in pickups)
                        {
                            if (!pickup._isUsed)
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

                    isPlayerTurn = false;
                }
                
                foreach(ICharacter enemy in enemies)
                {
                    if (enemy.CheckAlive() == true)
                    {
                        enemy.Update();
                    }
                }

                CheckHits();

                foreach(ICharacter enemy in enemies)
                {
                    int enemiesDead = 0;
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

                if (hasWon)
                {
                    break;
                }
             

                if (!player._isAlive)
                {
                    hasWon = false;
                    break;
                }

                //Thread.Sleep(200);
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
