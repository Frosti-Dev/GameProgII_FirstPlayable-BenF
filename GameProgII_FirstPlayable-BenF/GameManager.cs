using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgII_FirstPlayable_BenF
{
    internal class GameManager
    {
        string area;
        bool isPlayerTurn;
        ICharacter lastEnemy;

        Player _player;

        public GameManager(Player player)
        {
            _player = player;
        }

        //static public void CheckHits()
        //{
        //    /*
        //     * Checks Entity Collision
        //     */
        //    (int, int) playerPos = (_player._posX, _player._posY); //converts player POS into (int,int)

        //    if (isPlayerTurn)
        //    {
        //        foreach (ICharacter enemy in enemies) //checks if player hit any enemies
        //        {
        //            if (playerPos == enemy.CheckPOS(false))
        //            {
        //                enemy.TakeDamage(_player._attack);
        //                lastEnemy = enemy;
        //                _player.SetPOS(_player._prevPOS);
        //            }
        //        }

        //        foreach (Pickup pickup in pickups) //checks if player hit any pickups
        //        {
        //            if (playerPos == pickup._pos)
        //            {
        //                pickup.Destroy();
        //                _player.SetPOS(_player._prevPOS);
        //            }
        //        }

        //        foreach (Hazard hazard in hazards)
        //        {
        //            if (playerPos == hazard._pos)
        //            {
        //                hazard.Effect(_player);
        //            }

        //        }


        //    }

        //    else //enemy turn
        //    {
        //        foreach (ICharacter enemy in enemies) //checks if enemy hit player
        //        {
        //            if (playerPos == enemy.CheckPOS(false))
        //            {
        //                _player.TakeDamage(enemy.CheckAttack());
        //                enemy.SetPOS(enemy.CheckPOS(true));
        //            }
        //        }

        //        foreach (ICharacter enemy in enemies) //check if enemy hit enemy
        //        {
        //            foreach (ICharacter otherEnemy in enemies)
        //            {
        //                if (enemy != otherEnemy)
        //                {
        //                    if (enemy.CheckPOS(false) == otherEnemy.CheckPOS(false))
        //                    {
        //                        enemy.SetPOS(enemy.CheckPOS(true));
        //                    }
        //                }
        //            }
        //        }

        //    }

        //    Console.SetCursorPosition(0, 38);
        //    //update HUD
        //    if (_player._health < 10)
        //    {
        //        Console.WriteLine($"Player Health: 0{_player._health}");
        //    }
        //    else
        //    {
        //        Console.WriteLine($"Player Health: {_player._health}");
        //    }
        //    Console.WriteLine($"Player Attack: 0{_player._attack}");
        //    Console.WriteLine($"Coins: {_player._coins}");
        //    Console.WriteLine($"Area: {area}");

        //}

        //static public void CheckArea()
        //{
        //    if (_player._posY < 13)
        //    {
        //        if (_player._posX > 26)
        //        {
        //            if (_player._posX < 57) area = "Hallway";

        //            else if (_player._posX > 57) area = "Area  2";

        //        }

        //        else if (_player._posX < 26) area = "Area  1";
        //    }

        //    else if (_player._posY > 22)
        //    {
        //        if (_player._posX > 26)
        //        {
        //            if (_player._posX < 57) area = "Hallway";

        //            else if (_player._posX > 57) area = "Area  4";

        //        }

        //        else if (_player._posX < 26) area = "Area  3";
        //    }

        //    else
        //    {
        //        area = "Hallway";
        //    }

        //}

    }
}
