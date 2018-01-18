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
            var ran = new Random();
            var grid_x = 11;
            var grid_y = 11;
            var gridObject = new string[grid_x, grid_y];
            DrawShip(1, 4, gridObject);
            for (var x = 1; x < grid_x; x++)
            {
                for (var y = 1; y < grid_y; y++)
                {
                    if (gridObject[x, y] == "V" || gridObject[x, y] == "H")
                    {

                    }
                    else
                    {
                        gridObject[x, y] = "~";
                    }
                    }
            }
            

            Display(grid_x, grid_y, gridObject);
        }

        static void Display(int gridX, int gridY, string[,] gridObject)
        {
            Console.Clear();
            Console.WriteLine("   A  B  C  D  E  F  G  H  I  J");
            for (int x = 1; x < gridX; x++)
            {
                if (x<10)
                {
                    Console.Write(" " + x);
                }
                else if (x>=10)
                {
                    Console.Write(x);
                }
                for (int y = 1; y < gridY; y++)
                {
                    //Console.Write(y);
                    if (gridObject[x,y] == "~" )
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    else if (gridObject[x,y] == "X")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write("|" + gridObject[x, y] + "|");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                Console.WriteLine("");

            }



            Shoot(gridX, gridY, gridObject);
        }


        static void Shoot(int grid_x, int grid_y, string[,] gridObject)
        {
            int shoot_x = 0;
            int shoot_y = 0;
            string coordinate;
            int length;
            string placeholder_1, placeholder_2,placeholder_3 = "#";
            bool test_1,test_2;
            Console.WriteLine("input coordinate");
            coordinate = Console.ReadLine();
            length = coordinate.Length - 1;
            Console.WriteLine("Lengtth"+length);
            Console.ReadLine();
            placeholder_1 = coordinate.Substring(0,1);
            placeholder_2 = coordinate.Substring(1,length);
            Console.WriteLine(placeholder_1 + " " + placeholder_2);
            Console.ReadLine();
            test_1 = placeholder_1.All(char.IsDigit);
            test_2 = placeholder_2.All(char.IsDigit);
            if (test_1 == true)
            {
                placeholder_3 = placeholder_2;
                shoot_x = Convert.ToInt32(placeholder_1);
                //placeholder_3 = placeholder_1;
                //shoot_y = Convert.ToInt32(placeholder_2);
                //Console.WriteLine("test1");
                //Console.ReadLine();
            }
            else if (test_2 == true)
            {
                placeholder_3 = placeholder_1;
                shoot_x = Convert.ToInt32(placeholder_2);
                //placeholder_3 = placeholder_2;
                //shoot_y = Convert.ToInt32(placeholder_1);
                //Console.WriteLine("test2");
                //Console.ReadLine();
            }
            else
            {
                Console.WriteLine("ERROR");
                Console.ReadLine();
            }
            placeholder_3 = placeholder_3.ToLower();

            if (placeholder_3 == "a")
            {
                shoot_y = 1;
            }
            else if (placeholder_3 == "b")
            {
                shoot_y = 2;
            }
            else if (placeholder_3 == "c")
            {
                shoot_y = 3;
            }
            else if (placeholder_3 == "d")
            {
                shoot_y = 4;
            }
            else if (placeholder_3 == "e")
            {
                shoot_y = 5;
            }
            else if (placeholder_3 == "f")
            {
                shoot_y = 6;
            }
            else if (placeholder_3 == "g")
            {
                shoot_y = 7;
            }
            else if (placeholder_3 == "h")
            {
                shoot_y = 8;
            }
            else if (placeholder_3 == "i")
            {
                shoot_y = 9;
            }
            else if (placeholder_3 == "j")
            {
                shoot_y = 10;
            }
            else
            {
                Display(grid_x, grid_y, gridObject);
            }
            gridObject[shoot_x,shoot_y] = "X";
            Display(grid_x, grid_y, gridObject);
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
                        grid[shipsX, shipsY++] = "V";
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
                        grid[shipsX++, shipsY] = "H";
                    }
                }
                else
                {
                    CheckForShips(0, shipsX, shipsY, grid, shipLength);
                }
            }

            return grid;
        }

        public static int RandomNumber(int min, int max,Random ran)
        {
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

                
             
         
                 