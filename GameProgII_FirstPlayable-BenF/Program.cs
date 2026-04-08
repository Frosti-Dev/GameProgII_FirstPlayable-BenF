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
