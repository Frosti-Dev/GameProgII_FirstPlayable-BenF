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
        public (int, int) _prevPOS;

        public int _health;
        public bool _isAlive = true;

        public int _limiter;
        public Map _map;

        public int _coins;
        public int _attack = 1;
        
        public Player(int posX, int posY, Map map, int health, int limiter)
        {
            _posX = posX;
            _posY = posY;
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

                    _posY -= 1;

                    Debug.WriteLine(_map.isOccupiedMap[_posX, _posY]);

                    if (_posY <= 0)
                    {
                        _posY += 1;
                    }

                    //if (_map.isOccupiedMap[_posX,_posY] == true)
                    //{
                    //    _posY += 1;
                    //}
                    break;

                case ConsoleKey.A:

                    _posX -= 1;

                    Debug.WriteLine(_map.isOccupiedMap[_posX, _posY]);

                    if (_posX <= 0)
                    { 
                        _posX += 1;
                    }

                    //if(_map.isOccupiedMap[_posX, _posY] == true)
                    //{
                    //    _posX += 1;
                    //}

                    break;

                case ConsoleKey.S:

                    _posY += 1;

                    //Debug.WriteLine(_map.isOccupiedMap[_posX, _posY]);

                    if (_posY > 12 * _limiter)
                    {
                        _posY -= 1;
                    }

                    //if (_map.isOccupiedMap[_posX, _posY] == true)
                    //{
                    //    _posY -= 1;
                    //}
                    break;

                case ConsoleKey.D:

                    _posX += 1;

                    //Debug.WriteLine(_map.isOccupiedMap[_posX, _posY]);

                    if (_posX > 24 * _limiter)
                    {
                        _posX -= 1;
                    }
                    
                    //if (_map.isOccupiedMap[_posX, _posY] == true)
                    //{
                    //    _posX -= 1;
                    //}
                    break;

                case ConsoleKey.Escape:

                    Console.Clear();
                    Console.WriteLine("You Quit.");
                    Environment.Exit(0);
                    break;
            }

            Debug.WriteLine($"Player Pos: {_posX},{_posY}"); ///(pos)

        }

        public void TakeDamage(int amount)
        {
            _health -= amount; 

            if (_health < 0)
            {
                _health = 0;    
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

        public int CheckAttack()
        {
            return _attack;
        }

    }
}
