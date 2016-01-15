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

        public StateNode()
        {
            this.StateArray = new int[] {1,2,3,8,0,4,7,6,5};
        }

        public StateNode(int[] array)
        {
            this.StateArray2 = array;
        }
       // int[] PuzzleArray = new int[] {1,2,3,8,0,4,7,6,5};
        public void SwapNums2(int[] Array, int position1, int position2)
        {
            int temp = Array[position1];
            Array[position1] = Array[position2];
            Array[position2] = temp;
        } 

    }
}
