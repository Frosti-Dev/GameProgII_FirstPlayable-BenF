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
        #region Variables and Constructor
        public int _posX;
        public int _posY;
        public (int, int) _prevPOS;

        public int _health;
        public bool _isAlive = true;

        public Map _map;

        public int _coins;
        public int _attack = 1;
        
        public Player(int posX, int posY, Map map, int health)
        {
            _posX = posX;
            _posY = posY;
            _health = health;
            _map = map;
        }
        #endregion

        public void Draw()
        {
            Console.SetCursorPosition(_posX, _posY);
            Console.Write('X');
            Console.SetCursorPosition(_posX, _posY);
        }

        public void Update()
        {
            if(true) ///(Console.KeyAvailable for thread.sleep)
            {
                ConsoleKeyInfo keyinfo = Console.ReadKey(true);

                switch (keyinfo.Key)
                {
                    case ConsoleKey.W:

                        _posY--;

                        Debug.WriteLine(_map.isOccupiedMap[_posX, _posY]); //checks if boundary hit

                        if (_map.isOccupiedMap[_posX, _posY] == true)
                        {
                            _posY++;
                        }
                        break;

                    case ConsoleKey.A:

                        _posX--;

                        Debug.WriteLine(_map.isOccupiedMap[_posX, _posY]); //checks if boundary hit


                        if (_map.isOccupiedMap[_posX, _posY] == true)
                        {
                            _posX++;
                        }

                        break;

                    case ConsoleKey.S:

                        _posY++;

                        Debug.WriteLine(_map.isOccupiedMap[_posX, _posY]); //checks if boundary hit


                        if (_map.isOccupiedMap[_posX, _posY] == true)
                        {
                            _posY--;
                        }
                        break;

                    case ConsoleKey.D:

                        _posX++;

                        Debug.WriteLine(_map.isOccupiedMap[_posX, _posY]); //checks if boundary hit

                        if (_map.isOccupiedMap[_posX, _posY] == true)
                        {
                            _posX--;
                        }
                        break;

                    case ConsoleKey.Escape:

                        Console.Clear();
                        Console.WriteLine("You Quit.");
                        Environment.Exit(0);
                        break;

                    case ConsoleKey.Spacebar:
                        Debug.Write("/");
                        break;
                }

                Debug.WriteLine($"Player Pos: {_posX},{_posY}"); ///(pos)

            }
            
        }

        public void TakeDamage(int amount)
        {
            _health -= amount; 

            if (_health <= 0)
            {
                _health = 0;    
                Destroy();
            }
        }

        public void Destroy()
        {
            _isAlive = false;
        }

        #region Checks and Sets

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

        public (int,int) CheckPOS(bool prev)
        {
            if (prev)
            {
                return _prevPOS;
            }

            else
            {
                return (_posX, _posY);
            }
        }

        public void SetPOS((int,int) pos)
        {
            _posX = pos.Item1;
            _posY = pos.Item2;
        }

        public int CheckAttack()
        {
            return _attack;
        }

        public int CheckHealth()
        {
            return _health;
        }

        public char CheckModel()
        {
            return 'X';
        }

        #endregion
    }
}
