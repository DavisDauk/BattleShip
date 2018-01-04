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
            int grid_x = 10;
            int grid_y = 10;
            string[,] grid_object = new string[grid_x,grid_y]; 
            for (int x = 0; x < grid_x; x++)
            {
                for (int y = 0; y < grid_y; y++)
                {
                    grid_object[x, y] = "~";
                }
            }
            for (int x = 0; x < grid_x; x++)
            {
                for (int y = 0; y < grid_y; y++)
                {
                    Console.Write("|" + grid_object[x, y] + "|");
                }
                Console.WriteLine("");
            }
            Console.ReadLine();

        }
    }
}
