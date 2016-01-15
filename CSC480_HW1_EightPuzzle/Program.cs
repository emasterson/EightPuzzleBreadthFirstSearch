using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC480_HW1_EightPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] PuzzleArray = new int[] { 1, 0, 3, 8, 2, 4, 7, 6, 5 };
            int[] GoalState = new int[] { 1, 2, 3, 8, 0, 4, 7, 6, 5 };
            
            foreach (var item in PuzzleArray)
            {
                Console.Write(item.ToString() + " ");

            }
            
            Console.WriteLine();
            Console.WriteLine();
            
            

            SwapNums(PuzzleArray, 0, 1);

            foreach (var item in PuzzleArray)
            {
                Console.Write(item.ToString() + " ");

            }
            Console.WriteLine();
            Console.WriteLine("State array");
            Console.WriteLine();

            StateNode node = new StateNode();
            StateNode node2 = new StateNode(PuzzleArray);

            foreach (var item in node.StateArray)
            {
                
                Console.Write(item.ToString() + " ");

            }

            Console.WriteLine();
            Console.WriteLine("State array Passing PuzzleArray");
            Console.WriteLine();

            foreach (var item in node2.StateArray2)
            {

                Console.Write(item.ToString() + " ");

            }

            

            Console.ReadLine();
        }

        public static void SwapNums(int[] Array, int position1, int position2)
        {
            int temp = Array[position1];
            Array[position1] = Array[position2];
            Array[position2] = temp;
        }

        
    }
}
