using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgII_FirstPlayable_BenF
{
    internal class Map
    {
        public int _scale;

        public char[,] map = new char[,] // dimensions defined by following data:
    {
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
    };

        public Map(int scale)
        {
            _scale = scale;
        }

        public void DisplayMap()
        {

#region border top
            Console.Write("+");
            for (int k = 0; k < map.GetLength(0) * _scale * 2; k++)
            {
                Console.Write('-');
            }
            Console.Write('+');
            Console.WriteLine(" ");

            #endregion

#region print map
            for (int i = 0; i < map.GetLength(0); i++)
            {

                int row = 0;
                while (row < _scale)
                {
                    Console.Write('|');
                    for (int j = 0; j < map.GetLength(0); j++)
                    {
                        int timer = 0;
                        while (timer < _scale)
                        {
                            Console.Write(map[i, j] + " ");
                            timer++;
                        }
                    }
                    Console.Write('|');
                    Console.WriteLine(" ");
                    row++;
                }
            }

            #endregion

            #region bottom border
            Console.Write("+");
            for (int f = 0; f < map.GetLength(0) * _scale * 2; f++)
            {
                Console.Write('-');
            }
            Console.Write('+');
            Console.WriteLine(" ");

            #endregion

            //Displays
            //Console.WriteLine("Map legend: ");
            //Console.WriteLine("^ = mountain");
            //Console.WriteLine("` = grass");
            //Console.WriteLine("~ = water");
            //Console.WriteLine("* = trees");
        }
    }
}
