using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgII_FirstPlayable_BenF
{
    internal class Player
    {
        public int _posX;
        public int _posY;
        public int _health;
        public int _limiter;

        public Player(int posX, int posY, int health, int limiter)
        {
            _posX = posX;
            _posY = posY;
            _health = health;
            _limiter = limiter;
        }

        public void PlayerDraw()
        {
            Console.SetCursorPosition(_posX, _posY);
            Console.Write("X");
            Console.SetCursorPosition(_posX, _posY);
        }

        public void PlayerUpdate()
        {

            ConsoleKeyInfo keyinfo = Console.ReadKey(true);

            switch (keyinfo.Key)
            {
                case ConsoleKey.W:
                    _posY -= 1;
                    if (_posY <= 0)
                    {
                        _posY += 1;
                    }
                    break;

                case ConsoleKey.A:

                    _posX -= 1;

                    if (_posX <= 0)
                    {
                        _posX += 1;
                    }

                    break;

                case ConsoleKey.S:

                    _posY += 1;

                    if (_posY > 12 * _limiter)
                    {
                        _posY -= 1;
                    }
                    break;

                case ConsoleKey.D:

                    _posX += 1;

                    if (_posX > 24 * _limiter)
                    {
                        _posX -= 1;
                    }
                    break;

                case ConsoleKey.Escape:

                    Console.Clear();
                    Console.WriteLine("You Quit.");
                    Environment.Exit(0);
                    break;
            }
        }

    }
}
