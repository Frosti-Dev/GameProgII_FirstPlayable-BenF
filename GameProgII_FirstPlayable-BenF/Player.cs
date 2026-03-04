using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgII_FirstPlayable_BenF
{
    internal class Player :ICharacter
    {
        public int _posX;
        public int _posY;
        public int _health;
        public int _limiter;
        public int _bound;
        public Map _map;
        public (int, int) _prevPOS;

        public bool _isAlive = true;

        public Player(int posX, int posY, int bound, Map map, int health, int limiter)
        {
            _posX = posX;
            _posY = posY;
            _bound = bound;
            _health = health;
            _limiter = limiter;
            _map = map;
        }

        public void Draw()
        {
            Console.SetCursorPosition(_posX, _posY);
            Console.Write('X');
            Console.SetCursorPosition(_posX, _posY);
        }

        public void Update()
        {

            ConsoleKeyInfo keyinfo = Console.ReadKey(true);

            switch (keyinfo.Key)
            {
                case ConsoleKey.W:

                    _bound -= 12;
                    _posY -= 1;


                    if (_posY <= 0)
                    {
                        _bound += 12;
                        _posY += 1;
                    }

                    if (_map._isOccupied[_bound] == true)
                    {
                        _bound += 12;
                        _posY += 1;
                    }
                    break;

                case ConsoleKey.A:

                    _bound -= 1;
                    _posX -= 1;

                    if (_posX <= 0)
                    {
                        _bound += 1;
                        _posX += 1;
                    }

                    if( _map._isOccupied[_bound] == true)
                    {
                        _bound += 1;
                        _posX += 1;
                    }

                    break;

                case ConsoleKey.S:

                    _bound += 12;
                    _posY += 1;

                    if (_posY > 12 * _limiter)
                    {
                        _bound -= 12;
                        _posY -= 1;
                    }

                    if (_map._isOccupied[_bound])
                    {
                        _bound -= 12;
                        _posY -= 1;
                    }
                    break;

                case ConsoleKey.D:

                    _bound += 1;
                    _posX += 1;

                    if (_posX > 24 * _limiter)
                    {
                        _bound -= 1;
                        _posX -= 1;
                    }
                    
                    if (_map._isOccupied[_bound])
                    {
                        _bound -= 1;
                        _posX -= 1;
                    }
                    break;

                case ConsoleKey.Escape:

                    Console.Clear();
                    Console.WriteLine("You Quit.");
                    Environment.Exit(0);
                    break;
            }

            Debug.WriteLine($"Player Pos: {_posX},{_posY}"); ///(pos)
            Debug.WriteLine($"Bound Number: {_bound} ");
           

        }

        public void TakeDamage(int amount)
        {
            _health -= amount; 

            if (_health == 0)
            {
                Destroy();
            }
        }

        public void Destroy()
        {
            _isAlive = false;
        }

        public bool CheckAlive()
        {
            if (_isAlive)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public (int,int) CheckPOS()
        {
            return (_posX, _posY);
        }

    }
}
