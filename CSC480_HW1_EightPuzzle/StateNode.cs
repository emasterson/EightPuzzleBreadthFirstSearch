using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC480_HW1_EightPuzzle
{
    public class StateNode
    {

        //data : ---------------------------------

        public int[] StateArray;
        public int[] StateArray2;

        private int zeroPosition;

        public StateNode pUp;
        public StateNode pDown;
        public StateNode pRight;
        public StateNode pLeft;

        //----------------------------------------

        public StateNode()
        {
            this.StateArray = new int[] {1,2,3,8,0,4,7,6,5};
        }

        public StateNode(int[] array)
        {
            this.StateArray2 = array;
            this.pUp = null;
            this.pDown = null;
            this.pRight = null;
            this.pLeft = null;
        }
       // int[] PuzzleArray = new int[] {1,2,3,8,0,4,7,6,5};
        public static void SwapNums2(int[] Array, int position1, int position2)
        {
            int temp = Array[position1];
            Array[position1] = Array[position2];
            Array[position2] = temp;
        }

        public static void Successor(StateNode sNode)
        {
            // determine where the zero is in the array. This will allow us to determine all the next possible moves. 
            // Then we can determine all the next possible states the puzzle can be in.

            
            for (int i = 0; i < 9; i++)
            {
                if (sNode.StateArray2[i] == 0)
                {
                    sNode.zeroPosition = i;
                }
            }
            Console.WriteLine("zeroPosition = " + sNode.zeroPosition);
            Console.WriteLine();

            switch (sNode.zeroPosition)
            {
                case 0:
                    // move left
                    SwapNums2(sNode.StateArray2, 1, 0);
                    // move up
                    SwapNums2(sNode.StateArray2, 3, 0);
                    break;
                case 1:
                    // move right

                    // move left

                    // move up
                    
                    break;
                case 2:
                    // move right

                    // move up
                    break;
                case 3:
                    // move down

                    // move left

                    // move up
                    break;
                case 4:
                    // move down

                    // move right

                    // move left

                    // move up
                    break;
                case 5:
                    // move down

                    // move up

                    // move right

                    break;
                case 6:
                    // move down

                    // move left

                    break;
                case 7:
                    // move right

                    // move left

                    // move down
                    break;
                case 8:
                    // move right

                    // move down
                    break;

            }

            foreach (var item in sNode.StateArray2)
            {

                Console.Write(item.ToString() + " ");

            }
            //Now determine all the next possible states the puzzle can be in

            //switch statement for each index number of the array the zero can be in.
        }

    }
}
