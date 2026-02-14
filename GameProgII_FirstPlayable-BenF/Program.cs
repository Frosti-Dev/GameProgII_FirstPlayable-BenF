using System;
using System.Collections.Generic;
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
        static Player player = new Player(5, 5, 10, mapScale);
        static Enemy enemy1 = new Enemy((10, 10), 10, true, '1', player);
        static Enemy enemy2 = new Enemy((5, 10), 10, true, '2', player);
        #endregion

        static public void CheckHits()
        {
            (int, int) playerPos = (player._posX, player._posY);

            if(isPlayerTurn)
            {
                if (playerPos == enemy1._pos)
                {
                    enemy1.TakeDamage(1);
                    enemy1._pos = (10, 10);
                }

                if (playerPos == enemy2._pos)
                {
                    enemy2.TakeDamage(1);
                    enemy2._pos = (5, 10);
                }
            }

            else
            {
                if (playerPos == enemy1._pos)
                {
                    player.TakeDamage(1);
                    enemy1._pos = (10, 10);
                }

                if (playerPos == enemy2._pos)
                {
                    player.TakeDamage(1);
                    enemy2._pos = (5, 10);
                }
            }
        }

        static void Main(string[] args)
        {
            while (player._isAlive)
            {    
                isPlayerTurn = true;
                Console.Clear();
                map.DisplayMap();

                Console.WriteLine($"Player Health: {player._health}");
                Console.WriteLine($"{enemy1._model} Health: {enemy1._health}");
                Console.WriteLine($"{enemy2._model} Health: {enemy2._health}");

                if (enemy1._isAlive)
                {
                    enemy1.EnemyDraw();
                }
                if (enemy2._isAlive)
                {
                    enemy2.EnemyDraw();
                }

                player.PlayerDraw();
                CheckHits();
          

                if (isPlayerTurn)
                {
                    int turnCounter = 0;
                    
                    while(turnCounter < 2)
                    {
                        player.PlayerUpdate();
                        Console.Clear();
                        map.DisplayMap();

                        Console.WriteLine($"Player Health: {player._health}");
                        Console.WriteLine($"{enemy1._model} Health: {enemy1._health}");
                        Console.WriteLine($"{enemy2._model} Health: {enemy2._health}");

                        if (enemy1._isAlive)
                        {
                            enemy1.EnemyDraw();
                        }
                        if (enemy2._isAlive)
                        {
                            enemy2.EnemyDraw();
                        }

                        player.PlayerDraw();
                        CheckHits();

                        turnCounter++;
                    }
                    isPlayerTurn = false;
                }
                
                enemy1.EnemyUpdate();
                enemy2.EnemyUpdate();
                CheckHits();


                if (!enemy1._isAlive)
                {
                    hasWon = true;
                    break;
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
