using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;

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

        //area2
        static List<ICharacter> area2Enemies = new List<ICharacter>();

        //area 3
        static List<ICharacter> area3Enemies = new List<ICharacter>();

        //area4
        static List<ICharacter> area4Enemies = new List<ICharacter>();

        //list of pickups
        static List<IEntity> pickups = new List<IEntity>();

        //list of hazards
        static List<IEntity> hazards = new List<IEntity>();

        #endregion

        #region read data
        //coin pickup data
        static public string coinPath = @"Files/CoinInfoFile.txt";
        static public string[] coinData = File.ReadAllLines(coinPath);

        //health pickup data
        static public string healthPath = @"Files/HealthInfoFile.txt";
        static public string[] healthData = File.ReadAllLines(healthPath);

        //upgrade pickup data
        static public string upgradePath = @"Files/UpgradeInfoFile.txt";
        static public string[] upgradeData = File.ReadAllLines(upgradePath);

        //hazard data
        static public string hazardPath = @"Files/HazardInfoFile.txt";
        static public string[] hazardData = File.ReadAllLines(hazardPath);

        //enemy data
        static public string enemyPath = @"Files/EnemyInfoFile.txt";
        static public string[] enemyData = File.ReadAllLines(enemyPath);

        #endregion

        public GameManager()
        {

        }

        private void CheckHits()
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
                Console.WriteLine("!: Attack Up | +: Health Up | o: Coin");
            }
            

        }

        private void CheckArea()
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

        private void ChangeWindowSize()
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

        public void GameStart()
        {
            Console.CursorVisible = false;

            map.MakeOccupiedMap(); //make boundary map
            map.MakeReferenceMap(); //make reference map

            #region add to lists
            
            //coins
            if (File.Exists(coinPath))
            {
                for (int i = 0; i < coinData.Length; i++)
                {
                    string[] coinString = coinData[i].Split(',');

                    if (int.TryParse(coinString[0], out int result1) && int.TryParse(coinString[1], out int result2))
                    {
                        (int, int) coinPOS = (result1, result2);
                        pickups.Add(new Coin(coinPOS, 'o', player));
                    }

                    else
                    {
                        Debug.WriteLine($"{coinData[i]} failed to convert.");
                    }

                }
            }

            //health
            if (File.Exists(healthPath))
            {
                for (int i = 0; i < healthData.Length; i++)
                {
                    string[] healthString = healthData[i].Split(',');

                    if (int.TryParse(healthString[0], out int result1) && int.TryParse(healthString[1], out int result2))
                    {
                        (int, int) healthPOS = (result1, result2);
                        pickups.Add(new HealthItem(healthPOS, '+', player));
                    }

                    else
                    {
                        Debug.WriteLine($"{healthData[i]} failed to convert.");
                    }

                }
            }

            //upgrades
            if (File.Exists(upgradePath))
            {
                for (int i = 0; i < upgradeData.Length; i++)
                {
                    string[] upgradeString = upgradeData[i].Split(',');

                    if (int.TryParse(upgradeString[0], out int result1) && int.TryParse(upgradeString[1], out int result2))
                    {
                        (int, int) upgradePOS = (result1, result2);
                        pickups.Add(new Upgrade(upgradePOS, '!', player));
                    }

                    else
                    {
                        Debug.WriteLine($"{upgradeData[i]} failed to convert.");
                    }

                }
            }


            if (File.Exists(hazardPath))
            {
                for (int i = 0; i < hazardData.Length; i++)
                {
                    string[] hazardString = hazardData[i].Split(',');


                    if (int.TryParse(hazardString[0], out int result1) && int.TryParse(hazardString[1], out int result2))
                    {
                        (int, int) hazardPOS = (result1, result2);
                        hazards.Add(new Hazard(hazardPOS, '#'));
                    }

                    else
                    {
                        Debug.WriteLine($"{hazardData[i]} failed to convert.");
                    }
                }
            }


            if (File.Exists(enemyPath))
            {
                for (int i = 0; i < enemyData.Length; i++)
                {
                    string[] enemyString = enemyData[i].Split(',');


                    if (int.TryParse(enemyString[0], out int result1) && int.TryParse(enemyString[1], out int result2))
                    {
                        (int, int) enemyPOS = (result1, result2);

                        if (int.TryParse(enemyString[2], out int healthResult))
                        {
                            int enemyHealth = healthResult;

                            if (int.TryParse(enemyString[4], out int areaResult))
                            {
                                int enemyArea = areaResult;

                                Debug.Write(enemyString[3]);
                                if (char.TryParse(enemyString[3], out char modelResult))
                                {
                                    char enemyModel = modelResult;
                                   


                                    if (enemyModel == '?')
                                    {
                                        ConfusedEnemy confusedEnemy = new ConfusedEnemy(enemyPOS, enemyHealth, enemyModel, player, map);
                                        enemies.Add(confusedEnemy);

                                        if (enemyArea == 1)
                                        {
                                            area1Enemies.Add(confusedEnemy);
                                        }

                                        else if (enemyArea == 2)
                                        {
                                            area2Enemies.Add(confusedEnemy);
                                        }

                                        else if (enemyArea == 3)
                                        {
                                            area3Enemies.Add(confusedEnemy);
                                        }

                                        else
                                        {
                                            area4Enemies.Add(confusedEnemy);
                                        }
                                    }

                                    else if (enemyModel == 'H')
                                    {
                                        HeavyEnemy heavyEnemy = new HeavyEnemy(enemyPOS, enemyHealth, enemyModel, player, map);
                                        enemies.Add(heavyEnemy);

                                        if (enemyArea == 1)
                                        {
                                            area1Enemies.Add(heavyEnemy);
                                        }

                                        else if (enemyArea == 2)
                                        {
                                            area2Enemies.Add(heavyEnemy);
                                        }

                                        else if (enemyArea == 3)
                                        {
                                            area3Enemies.Add(heavyEnemy);
                                        }

                                        else
                                        {
                                            area4Enemies.Add(heavyEnemy);
                                        }
                                    }

                                    else
                                    {
                                        Enemy enemy = new Enemy(enemyPOS, enemyHealth, enemyModel, player, map);
                                        enemies.Add(enemy);

                                        if(enemyArea == 1)
                                        {
                                            area1Enemies.Add(enemy);
                                        }

                                        else if(enemyArea == 2)
                                        {
                                            area2Enemies.Add(enemy);
                                        }

                                        else if (enemyArea == 3)
                                        {
                                            area3Enemies.Add(enemy);
                                        }

                                        else 
                                        {
                                            area4Enemies.Add(enemy);
                                        }
                                    }
                                }

                                else
                                {
                                    Debug.WriteLine($"{enemyData[i]} failed to convert model.");
                                   
                                }
                            }

                            else
                            {
                                Debug.WriteLine($"{enemyData[i]} failed to convert area.");

                            }
                        }

                        else
                        {
                            Debug.WriteLine($"{enemyData[i]} failed to convert health.");
                        }

                    }

                    else
                    {
                        Debug.WriteLine($"{enemyData[i]} failed to convert POS.");
                    }
                }
            }


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
            Console.WriteLine("!: Attack Up | +: Health Up | o: Coin");


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

        }

        public bool GameEnd()
        {
            while (true)
            {
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
                Console.WriteLine("Do you want to play again? (Y/N)");

                ConsoleKeyInfo keyinfo = Console.ReadKey(true);

                if (keyinfo.Key == ConsoleKey.Y)
                {
                    string currentAppPath = Process.GetCurrentProcess().MainModule.FileName;

                    Process.Start(currentAppPath);

                    Environment.Exit(0);
                    return true;
                }

                else if (keyinfo.Key == ConsoleKey.N)
                {
                    Environment.Exit(0);
                }

                else
                {
                   
                }

            }
            
        }
    }
}
