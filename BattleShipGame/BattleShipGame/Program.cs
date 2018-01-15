using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid_x = 11;
            var grid_y = 11;
            var grid_object = new string[grid_x, grid_y];
            for (var x = 1; x < grid_x; x++)
            {
                for (var y = 1; y < grid_y; y++)
                {
                    grid_object[x, y] = "~";
                }
            }

            Display(grid_x, grid_y, grid_object);
        }

        static void Display(int gridX, int gridY, string[,] gridObject)
        {
            for (var x = 1; x < gridX; x++)
            {
                for (var y = 1; y < gridY; y++)
                {
                    Console.Write("|" + gridObject[x, y] + "|");
                }

                DrawShip(1, 4, gridObject);
                Console.WriteLine("");

            }



            Shoot(gridX, gridY, gridObject);
        }


        static void Shoot(int grid_x, int grid_y, string[,] grid_object)
        {
            int shoot_x;
            int shoot_y;
            Console.WriteLine("x coordinate");
            shoot_x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("y coordinate");
            shoot_y = Convert.ToInt32(Console.ReadLine());
            grid_object[shoot_x, shoot_y] = "X";
            Display(grid_x, grid_y, grid_object);
            Console.Clear();
        }

        static string[,] DrawShip(int direction, int shipLength, string[,] grid)
        {
            var noShips = false;

            if (direction == 1) //vertical
            {
                var shipsY = RandomNumber(0, 9 - shipLength);
                var shipsX = RandomNumber(0, 9);

                noShips = CheckForShips(1, shipsX, shipsY, grid, shipLength);
                if (noShips)
                {
                    for (var i = 0; i < shipLength; i++)
                    {
                        grid[shipsX, shipsY++] = "v";
                    }
                }
                else
                {
                    DrawShip(direction, shipLength, grid);
                }

            }
            else //Horizontal
            {
                var shipsX = RandomNumber(0, 10 - shipLength);
                var shipsY = RandomNumber(0, 10);

                noShips = CheckForShips(0, shipsX, shipsY, grid, shipLength);

                if (noShips)
                {
                    for (var i = 0; i < shipLength; i++)
                    {
                        grid[shipsX++, shipsY] = "s";
                    }
                }
                else
                {
                    CheckForShips(0, shipsX, shipsY, grid, shipLength);
                }
            }

            return grid;
        }

        public static int RandomNumber(int min, int max)
        {
           var ran = new Random();
           var number = ran.Next(min, max);
           return number;
        }

        static bool CheckForShips(int direction, int positionX, int positionY, string[,] grid, int shipLength)
        {
            if (direction == 1) //vertical
            {
                for (var i = positionX; i < positionX + shipLength; i++)
                {
                    if (grid[i, positionY] != "~")
                    {
                        return false;
                    }
                }
            }
            else //Horizontal
            {
                for (var i = positionY; i < shipLength + positionY; i++)
                 {
                  if (grid[positionX, i] != "~")
                      {
                           return false;
                       }


                    }
                }
            

            return true;
        }
    }
}

                
             
         
                 