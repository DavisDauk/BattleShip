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
            int grid_x = 11;
            int grid_y = 11;
            string[,] grid_object = new string[grid_x,grid_y]; 
            for (int x = 1; x < grid_x; x++)
            {
                for (int y = 1; y < grid_y; y++)
                {
                    grid_object[x, y] = "~";
                }
            }
            Display(grid_x,grid_y,grid_object);
        }
        static void Display(int grid_x, int grid_y, string[,] grid_object)
        {
            for (int x = 1; x < grid_x; x++)
            {
                for (int y = 1; y < grid_y; y++)
                {
                    Console.Write("|" + grid_object[x, y] + "|");
                }
                Console.WriteLine("");
            }
            Shoot(grid_x, grid_y, grid_object);
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
    }
}
