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

        //private int[] StateArrayUp;
        //private int[] StateArrayDown;
        //private int[] StateArrayRight;
        //private int[] StateArrayLeft;

        private int zeroPosition;

        public StateNode pUp;
        public StateNode pDown;
        public StateNode pRight;
        public StateNode pLeft;
        public StateNode pParent;

        public int CostOfMove = 0;
        //public int TotalCostAllMoves = 0;

        DirectionOfMove direction;
        

        //----------------------------------------
        public enum PuzzleStateMatch
        {
            YesMatchSolution,
            DoesNotMatchSolution
        }

        public enum DirectionOfMove
        {
            Up,
            Down,
            Left,
            Right
        }
        public StateNode()
        {
            this.StateArray2 = new int[] {1,2,3,8,9,4,7,6,5};
            this.pUp = null;
            this.pDown = null;
            this.pRight = null;
            this.pLeft = null;
            this.pParent = null;
        }

        public StateNode(int[] array)
        {
            this.StateArray2 = array;
            this.pUp = null;
            this.pDown = null;
            this.pRight = null;
            this.pLeft = null;
            this.pParent = null;
        }

        // Copy Constructor for Deep Copy
        public StateNode(StateNode otherNode)
        {
            this.StateArray2 = new int[] { 9, 9, 9, 9, 9, 9, 9, 9, 9 };
            this.StateArray2 = otherNode.StateArray2;
            this.pUp = null;
            this.pDown = null;
            this.pRight = null;
            this.pLeft = null;
            this.pParent = null;
        }
 
        public static void SwapNums2(int[] Array, int position1, int position2)
        {
            
            int temp = Array[position1];
            Array[position1] = Array[position2];
            Array[position2] = temp;
        }

        public static int[] SwapNums3(int[] Array, int position1, int position2)
        {
            // this function creates a new array, copies the contents of incoming Array, Then makes swaps of the Copy So as to not affect original
            // then returns new array
            
            int[] TempArray = new int[] {9,9,9,9,9,9,9,9,9};
            for (int i = 0; i < 9; i++)
            {
                TempArray[i] = Array[i];
            }
            //int[] TempArray = Array;
            int temp = TempArray[position1];
            TempArray[position1] = TempArray[position2];
            TempArray[position2] = temp;
            return TempArray;
        }

        public static int[] SwapNums4(StateNode node, int position1, int position2)
        {
            StateNode newNode = new StateNode(node);
            int[] TempArray = newNode.StateArray2;
            int temp = TempArray[position1];
            TempArray[position1] = TempArray[position2];
            TempArray[position2] = temp;
            return TempArray;
            
        }

        public static Queue<StateNode> Successor(StateNode sNode)
        //public static void Successor(StateNode sNode)
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

           // Make 4 Nodes
            //StateNode sNodeLeft;
            //sNodeLeft = NodeManager.CreateNode(sNode);
            StateNode sNodeLeft = new StateNode(sNode);
            StateNode sNodeRight = new StateNode(sNode);
            StateNode sNodeUp = new StateNode(sNode);
            StateNode sNodeDown = new StateNode(sNode);

            // point the parent pointer of each node to the sNode
            sNodeLeft.pParent = sNode;
            sNodeUp.pParent = sNode;
            sNodeDown.pParent = sNode;
            sNodeRight.pParent = sNode;
            // point the pointers of the sNode to each of the nodes just created
            sNode.pLeft = sNodeLeft;
            sNode.pRight = sNodeRight;
            sNode.pUp = sNodeUp;
            sNode.pDown = sNodeDown;

            //Now determine all the next possible states the puzzle can be in
            // CREATE A LIST WITH ALL THE NEXT STATES
            Queue<StateNode> qNodes = new Queue<StateNode>();
            

            switch (sNode.zeroPosition)
            {
                case 0:
                    // move left, need to create a node
                   // Console.WriteLine("Case0\n\n");
                    sNodeLeft.StateArray2 = SwapNums3(sNodeLeft.StateArray2, 1, 0);
                    sNodeLeft.CostOfMove = sNodeLeft.StateArray2[0];
                    sNodeLeft.direction = StateNode.DirectionOfMove.Left;

                    // move up
                    
                    sNodeUp.StateArray2 = SwapNums3(sNodeUp.StateArray2, 3, 0);
                    sNodeUp.CostOfMove = sNodeUp.StateArray2[0];
                    sNodeUp.direction = StateNode.DirectionOfMove.Up;
                   // sNodeUp.StateArray2 = SwapNums4(sNodeUp, 3, 0);
                    sNodeRight = null;
                    sNodeDown = null;
                    break;
                case 1:
                   // Console.WriteLine("Case1\n\n");
                    // move right
                    sNodeRight.StateArray2 = SwapNums3(sNodeRight.StateArray2, 1, 0);
                    sNodeRight.CostOfMove = sNodeRight.StateArray2[1];
                    sNodeRight.direction = StateNode.DirectionOfMove.Right;
                    // move left
                    sNodeLeft.StateArray2 = SwapNums3(sNodeLeft.StateArray2, 2, 1);
                    sNodeLeft.CostOfMove = sNodeLeft.StateArray2[1];
                    sNodeLeft.direction = StateNode.DirectionOfMove.Left;
                    // move up
                    sNodeUp.StateArray2 = SwapNums3(sNodeUp.StateArray2, 1, 4);
                    sNodeUp.CostOfMove = sNodeUp.StateArray2[1];
                    sNodeUp.direction = StateNode.DirectionOfMove.Up;
                    // delete down
                    sNodeDown = null;
                    break;
                case 2:
                   // Console.WriteLine("Case2\n\n");
                    // move right
                    sNodeRight.StateArray2 = SwapNums3(sNodeRight.StateArray2, 1, 2);
                    sNodeRight.CostOfMove = sNodeRight.StateArray2[2];
                    sNodeRight.direction = StateNode.DirectionOfMove.Right;
                    // move up
                    sNodeUp.StateArray2 = SwapNums3(sNodeUp.StateArray2, 2, 5);
                    sNodeUp.CostOfMove = sNodeUp.StateArray2[2];
                    sNodeUp.direction = StateNode.DirectionOfMove.Up;
                    // delete down and left
                    sNodeDown = null;
                    sNodeLeft = null;
                    break;
                case 3:
                  //  Console.WriteLine("Case3\n\n");
                    // move down
                    sNodeDown.StateArray2 = SwapNums3(sNodeDown.StateArray2, 3, 0);
                    sNodeDown.CostOfMove = sNodeDown.StateArray2[3];
                    sNodeDown.direction = StateNode.DirectionOfMove.Down;
                    // move left
                    sNodeLeft.StateArray2 = SwapNums3(sNodeLeft.StateArray2, 3, 4);
                    sNodeLeft.CostOfMove = sNodeLeft.StateArray2[3];
                    sNodeLeft.direction = StateNode.DirectionOfMove.Left;
                    // move up
                    sNodeUp.StateArray2 = SwapNums3(sNodeUp.StateArray2, 3, 6);
                    sNodeUp.CostOfMove = sNodeUp.StateArray2[3];
                    sNodeUp.direction = StateNode.DirectionOfMove.Up;

                    sNodeRight = null;
                    break;
                case 4:
                  //  Console.WriteLine("Case4\n\n");
                    // move down
                    sNodeDown.StateArray2 = SwapNums3(sNodeDown.StateArray2, 4, 1);
                    sNodeDown.CostOfMove = sNodeDown.StateArray2[4];
                    sNodeDown.direction = StateNode.DirectionOfMove.Down;
                    // move right
                    sNodeRight.StateArray2 = SwapNums3(sNodeRight.StateArray2, 4, 3);
                    sNodeRight.CostOfMove = sNodeRight.StateArray2[4];
                    sNodeRight.direction = StateNode.DirectionOfMove.Right;
                    // move left
                    sNodeLeft.StateArray2 = SwapNums3(sNodeLeft.StateArray2, 4, 5);
                    sNodeLeft.CostOfMove = sNodeLeft.StateArray2[4];
                    sNodeLeft.direction = StateNode.DirectionOfMove.Left;
                    // move up
                    sNodeUp.StateArray2 = SwapNums3(sNodeUp.StateArray2, 4, 7);
                    sNodeUp.CostOfMove = sNodeUp.StateArray2[4];
                    sNodeUp.direction = StateNode.DirectionOfMove.Up;
                    break;
                case 5:
                  //  Console.WriteLine("Case5\n\n");
                    // move down
                    sNodeDown.StateArray2 = SwapNums3(sNodeDown.StateArray2, 5, 2);
                    sNodeDown.CostOfMove = sNodeDown.StateArray2[5];
                    sNodeDown.direction = StateNode.DirectionOfMove.Down;
                    // move up
                    sNodeUp.StateArray2 = SwapNums3(sNodeUp.StateArray2, 5, 8);
                    sNodeUp.CostOfMove = sNodeUp.StateArray2[5];
                    sNodeUp.direction = StateNode.DirectionOfMove.Up;
                    // move right
                    sNodeRight.StateArray2 = SwapNums3(sNodeRight.StateArray2, 5, 4);
                    sNodeRight.CostOfMove = sNodeRight.StateArray2[5];
                    sNodeRight.direction = StateNode.DirectionOfMove.Right;
                    sNodeLeft = null;
                    break;
                case 6:
                  //  Console.WriteLine("Case6\n\n");
                    // move down
                    sNodeDown.StateArray2 = SwapNums3(sNodeDown.StateArray2, 6, 3);
                    sNodeDown.CostOfMove = sNodeDown.StateArray2[6];
                    sNodeDown.direction = StateNode.DirectionOfMove.Down;
                    // move left
                    sNodeLeft.StateArray2 = SwapNums3(sNodeLeft.StateArray2, 6, 7);
                    sNodeLeft.CostOfMove = sNodeLeft.StateArray2[6];
                    sNodeLeft.direction = StateNode.DirectionOfMove.Left;
                    sNodeUp = null;
                    sNodeRight = null;
                    break;
                case 7:
                  //  Console.WriteLine("Case7\n\n");
                    // move right
                    sNodeRight.StateArray2 = SwapNums3(sNodeRight.StateArray2, 7, 6);
                    sNodeRight.CostOfMove = sNodeRight.StateArray2[7];
                    sNodeRight.direction = StateNode.DirectionOfMove.Right;
                    // move left
                    sNodeLeft.StateArray2 = SwapNums3(sNodeLeft.StateArray2, 7, 8);
                    sNodeLeft.CostOfMove = sNodeLeft.StateArray2[7];
                    sNodeLeft.direction = StateNode.DirectionOfMove.Left;
                    // move down
                    sNodeDown.StateArray2 = SwapNums3(sNodeDown.StateArray2, 7, 4);
                    sNodeDown.CostOfMove = sNodeDown.StateArray2[7];
                    sNodeDown.direction = StateNode.DirectionOfMove.Down;
                    sNodeUp = null;
                    break;
                case 8:
                   // Console.WriteLine("Case8\n\n");
                    // move right
                    sNodeRight.StateArray2 = SwapNums3(sNodeRight.StateArray2, 8, 7);
                    sNodeRight.CostOfMove = sNodeRight.StateArray2[8];
                    sNodeRight.direction = StateNode.DirectionOfMove.Right;
                    // move down
                    sNodeDown.StateArray2 = SwapNums3(sNodeDown.StateArray2, 8, 5);
                    sNodeDown.CostOfMove = sNodeDown.StateArray2[8];
                    sNodeDown.direction = StateNode.DirectionOfMove.Down;
                    sNodeUp = null;
                    sNodeLeft = null;
                    break;

            }
            
            
            
            
            //Now determine all the next possible states the puzzle can be in
            //  ALL THE NEXT STATES in a queue and send it to main loop
            if (sNodeDown != null)
            {
                qNodes.Enqueue(sNodeDown);
                //Console.WriteLine("\nStateArrayDown\n");
                //foreach (var item in sNodeDown.StateArray2)
                //{


                //    Console.Write(item.ToString() + " ");

                //}
                //Console.WriteLine("CostOfMove = " + sNodeDown.CostOfMove);
            }
            if (sNodeUp != null)
            {
                qNodes.Enqueue(sNodeUp);
                //Console.WriteLine("\nStateArrayUp\n");
                //foreach (var item in sNodeUp.StateArray2)
                //{


                //    Console.Write(item.ToString() + " ");

                //}
                //Console.WriteLine("CostOfMove = " + sNodeUp.CostOfMove);
            }
            if (sNodeLeft != null)
            {
                qNodes.Enqueue(sNodeLeft);
                //Console.WriteLine("\nStateArrayLeft\n");
                //foreach (var item in sNodeLeft.StateArray2)
                //{


                //    Console.Write(item.ToString() + " ");

                //}
                //Console.WriteLine("CostOfMove = " + sNodeLeft.CostOfMove);
            }
            if (sNodeRight != null)
            {
                qNodes.Enqueue(sNodeRight);
                //Console.WriteLine("\nStateArrayRight\n");
                //foreach (var item in sNodeRight.StateArray2)
                //{


                //    Console.Write(item.ToString() + " ");

                //}
                //Console.WriteLine("CostOfMove = " + sNodeRight.CostOfMove);
            }

            // return the queue
            return qNodes;

            //switch statement for each index number of the array the zero can be in.
        }

        public static void PrettyPrintPathToSolvePuzzle(StateNode node)
        {
            int TotalCostOfAllMoves = 0;
            // create a stack to put the nodes on. Later we will pop them off to get the order of moves
            // to solve the puzzle
            Stack<StateNode> stackOfNodes = new Stack<StateNode>();

            //StateNode nodePointer = new StateNode();
            StateNode nodePointer = null;
            StateNode nodePointer2 = null;
            nodePointer = node;
            nodePointer2 = node.pParent;
            while (nodePointer != null)
            {

                stackOfNodes.Push(nodePointer);
                
                nodePointer = nodePointer.pParent;
                
                
            }
            int LengthOfSolution = stackOfNodes.Count();

            foreach (StateNode sn in stackOfNodes)
            {
                foreach (var item in sn.StateArray2)
                {


                    Console.Write(item.ToString() + " ");
                    
                }
                Console.WriteLine();
                Console.WriteLine("CostOfMove = " + sn.CostOfMove);
                TotalCostOfAllMoves = TotalCostOfAllMoves + sn.CostOfMove;
                Console.WriteLine("TotalCostOfAllMoves = " + TotalCostOfAllMoves);
                Console.WriteLine();
                Console.WriteLine("Direction of Move = " + sn.direction);
                Console.WriteLine();
                Console.WriteLine("Length =  " + (LengthOfSolution - 1));
                Console.WriteLine();
            }


            Console.WriteLine("\nGoalStateNode\n");
            foreach (var item in node.StateArray2)
            {


                Console.Write(item.ToString() + " ");

            }

            
        }

    }
}
