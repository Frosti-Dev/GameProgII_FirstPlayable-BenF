using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgII_FirstPlayable_BenF
{
    internal class Map
    {
        static public string path = @"Map/MapFile.txt";

        static public string mapData = File.ReadAllText(path); 

        //scale of map
        static public int rows = 89;
        static public int cols = 36;

        public bool[,] isOccupiedMap = new bool[rows, cols];

        public char[,] refMap = new char[rows, cols];

        public Map()
        {
            
        }

        public void MakeOccupiedMap()
        {
            if (File.Exists(path))
            {
                int lineNum = -1;
                int charNum = -1;

                foreach(string line in File.ReadLines(path))
                {
                    charNum = -1;
                    lineNum++;

                    //Debug.WriteLine(lineNum + " " + line);

                    foreach (char character in line)
                    {
                        charNum++;

                        //Debug.Write(character + " ");

                        if (character == '^')
                        {
                            isOccupiedMap[charNum, lineNum] = true;
                            //Debug.Write("True(^) ");
                        }

                        else if (character == '`')
                        {
                            isOccupiedMap[charNum, lineNum] = false;
                            //Debug.Write("False(') ");
                        }

                        else if (character == '~')
                        {
                            isOccupiedMap[charNum, lineNum] = true;
                            //Debug.Write("True(~) ");
                        }

                        else if (character == '*')
                        {
                            isOccupiedMap[charNum, lineNum] = true;
                            //Debug.Write("True(*) ");
                        }

                        else if (character == ' ')
                        {
                            isOccupiedMap[charNum, lineNum] = false;
                            //Debug.Write("False() ");
                        }

                        else if (character == '|')
                        {
                            isOccupiedMap[charNum, lineNum] = true;
                            //Debug.Write("True(|) ");
                        }

                        else if (character == '-')
                        {
                            isOccupiedMap[charNum, lineNum] = true;
                            //Debug.Write("True(-) ");
                        }

                        else if (character == '+')
                        {
                            isOccupiedMap[charNum, lineNum] = true;
                            //Debug.Write("True(+) ");
                        }

                        else
                        {
                            isOccupiedMap[charNum, lineNum] = false;
                            //Debug.Write("False(else) ");
                        }
                    }
                }
            }
        }


        public void MakeReferenceMap()
        {
            if (File.Exists(path))
            {
                int lineNum = -1;
                int charNum = -1;

                foreach (string line in File.ReadLines(path))
                {
                    charNum = -1;
                    lineNum++;

                  

                    foreach (char character in line)
                    {
                        charNum++;

                        //Debug.Write(character + " ");

                        if (character == '^')
                        {
                            refMap[charNum, lineNum] = character;
                          
                        }

                        else if (character == '`')
                        {
                            refMap[charNum, lineNum] = character;

                        }

                        else if (character == '~')
                        {
                            refMap[charNum, lineNum] = character;

                        }

                        else if (character == '*')
                        {
                            refMap[charNum, lineNum] = character;

                        }

                        else if (character == ' ')
                        {
                            refMap[charNum, lineNum] = character;

                        }

                        else if (character == '|')
                        {
                            refMap[charNum, lineNum] = character;

                        }

                        else if (character == '-')
                        {
                            refMap[charNum, lineNum] = character;

                        }

                        else if (character == '+')
                        {
                            refMap[charNum, lineNum] = character;

                        }

                        else
                        {
                            refMap[charNum, lineNum] = character;

                        }
                    }
                }
            }
        }


        public void DisplayMap()
        {
            //Debug.WriteLine(mapData.Length);

            if (File.Exists(path))
            {
                for (int i = 0; i < mapData.Length; i++)
                {
                    if (mapData[i] == '^')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }

                    if (mapData[i] == '`')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }
                    
                    if (mapData[i] == '~')
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }

                    if (mapData[i] == '*')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.Write(mapData[i]);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine(" ");
            }

            #region old code
            //#region border top
            //            Console.Write("+");
            //            for (int k = 0; k < map.GetLength(0) * _scale; k++)
            //            {
            //                Console.Write('-');
            //            }
            //            Console.Write('+');
            //            Console.WriteLine(" ");

            //            #endregion

            //#region print map
            //            for (int i = 0; i < map.GetLength(0); i++)
            //            {

            //                int row = 0;
            //                while (row < _scale)
            //                {
            //                    Console.Write('|');
            //                    for (int j = 0; j < map.GetLength(0); j++)
            //                    {
            //                        int timer = 0;
            //                        while (timer < _scale)
            //                        {
            //                            if (map[i, j] == '^')
            //                            {
            //                                Console.ForegroundColor = ConsoleColor.DarkGray;

            //                                _isOccupied.Add(true);
            //                                _isOccupied.Add(true);

            //                            }

            //                            if (map[i, j] == '~')
            //                            {
            //                                Console.ForegroundColor = ConsoleColor.Blue;
            //                                _isOccupied.Add(true);
            //                                _isOccupied.Add(true);
            //                            }

            //                            if (map[i, j] == '*')
            //                            {
            //                                Console.ForegroundColor = ConsoleColor.Green;
            //                                _isOccupied.Add(true);
            //                                _isOccupied.Add(true);
            //                            }

            //                            if (map[i,j] == '`')
            //                            {
            //                                Console.ForegroundColor = ConsoleColor.DarkGreen;
            //                                _isOccupied.Add(false);
            //                                _isOccupied.Add(false);
            //                            }

            //                            Console.Write(map[i, j]);

            //                            timer++;
            //                        }
            //                    }
            //                    Console.ForegroundColor = ConsoleColor.White;

            //                    Console.Write('|');
            //                    Console.WriteLine(" ");
            //                    row++;
            //                }
            //            }

            //            #endregion

            //            #region bottom border
            //            Console.Write("+");
            //            for (int f = 0; f < map.GetLength(0) * _scale; f++)
            //            {
            //                Console.Write('-');
            //            }
            //            Console.Write('+');
            //            Console.WriteLine(" ");

            //            #endregion

            //Debug.WriteLine(_isOccupied[0]);

            //Displays
            //Console.WriteLine("Map legend: ");
            //Console.WriteLine("^ = mountain");
            //Console.WriteLine("` = grass");
            //Console.WriteLine("~ = water");
            //Console.WriteLine("* = trees");
        }
    }
}

//string path = @"Data\data101.txt";

//string data = File.ReadAllText(path);

//string[] data = File.ReadAllLines(path);

//if (File.Exists(path))
//{
//    //safely reads the file
//}

//for (int i = 0; i < data.Length; i++)
//{
//    Console.WriteLine($"Line {i}: {data[i]}");
//}

/*
{'^','^','^','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
{'^','^','`','`','`','`','*','*','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','~','~','~','`','`','`'},
{'^','^','`','`','`','*','*','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','~','~','~','`','`','`','`','`'},
{'^','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
{'`','`','`','`','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
{'`','`','`','`','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
{'`','`','`','~','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','`','`','`','`','`','`'},
{'`','`','`','`','`','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','^','^','`','`','`','`','`'},
{'`','`','`','`','`','~','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','^','^','`','`','`'},
{'`','`','`','`','`','`','`','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
{'`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
{'`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
*/

#endregion