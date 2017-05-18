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
            int[] PuzzleArray = new int[] { 1, 2, 3, 0, 8, 4, 7, 6, 5 };
            int[] Easy = new int[] { 1, 3, 4, 8, 6, 2, 7, 0, 5 };
            int[] Medium = new int[] { 2, 8, 1, 0, 4, 3, 7, 6, 5 };
            int[] Hard = new int[] { 5, 6, 7, 4, 0, 8, 3, 2, 1 };
            int[] GoalState = new int[] { 1, 2, 3, 8, 0, 4, 7, 6, 5 };
            StateNode GoalStateNode = new StateNode();
            int Time = 0;
            int TotalCostOfAllMoves;
            int MaxOfQueue = 0;
            int SizeOfQueue = 0;

            PuzzleArray = Hard ;
            
            foreach (var item in PuzzleArray)
            {
                Console.Write(item.ToString() + " ");

            }
            
            Console.WriteLine();
            Console.WriteLine();

            foreach (var item in PuzzleArray)
            {
                Console.Write(item.ToString() + " ");

            }
            Console.WriteLine();
            Console.WriteLine("State array");
            Console.WriteLine();

            StateNode node = new StateNode();
            StateNode root = new StateNode(PuzzleArray);

            //foreach (var item in node.StateArray)
            //{
                
            //    Console.Write(item.ToString() + " ");

            //}

            Console.WriteLine();
            Console.WriteLine("State array Passing PuzzleArray");
            Console.WriteLine();

            foreach (var item in root.StateArray2)
            {

                Console.Write(item.ToString() + " ");

            }

            // Create Queue of Nodes
            Queue<StateNode> q = new Queue<StateNode>();

            // Create Queue that will accept queue returned from Successor function
            Queue<StateNode> qFromSuccessorFunction = new Queue<StateNode>();

            // Put original puzzle state in queue
            q.Enqueue(root);
            SizeOfQueue = 1;
            MaxOfQueue = MaxOfQueue + 1;


            // Beginning of General Search Loop
            bool keepRunning = true;
            while (keepRunning)
            {
                if (q.Count == 0)
                {
                    Console.WriteLine("queue empty");
                    keepRunning = false;
                }
                if (keepRunning == false)
                {
                    break;
                }

                
                
                
                // Remove nodes from front of queue for Breadth-First Search
                StateNode removeFromFront = new StateNode();
                removeFromFront = q.Dequeue();
                Time = Time + 1;

                // Check to see if ArrayState of node that was popped from queue matches Puzzle Solution(GoalState)


                bool isEqual = Enumerable.SequenceEqual(removeFromFront.StateArray2, GoalState);
                if (isEqual)
                {
                    Console.WriteLine();
                    Console.WriteLine("Puzzle is Solved!");
                    GoalStateNode = removeFromFront;
                    Console.WriteLine();
                    break;
                }
                

                



                // REturn the Node that matches solution


                // Call Successor Function to get the next nodes to add to list and Expand
                //Console.WriteLine();
                //Console.WriteLine("Entering Successor Function");
                //Console.WriteLine();

                // create a queue to accept the queue returned from successor function

                
                qFromSuccessorFunction = StateNode.Successor(removeFromFront);
                
                

                // add nodes from Successor Function into the q for the loop

                while (qFromSuccessorFunction.Count != 0)
                {
                    StateNode removeFromFrontOfSuccessorQueue = new StateNode();
                    removeFromFrontOfSuccessorQueue = qFromSuccessorFunction.Dequeue();
                    q.Enqueue(removeFromFrontOfSuccessorQueue);
                    SizeOfQueue = q.Count;
                    if (MaxOfQueue < SizeOfQueue)
                    {
                        MaxOfQueue = SizeOfQueue;
                    }
                }


            }
            Console.WriteLine();
            Console.WriteLine("out of loop");
            Console.WriteLine();


            Console.WriteLine();
            Console.WriteLine("Here were the successful moves to solve the puzzle:");
            Console.WriteLine();

            StateNode.PrettyPrintPathToSolvePuzzle(GoalStateNode);

            Console.WriteLine();
            Console.WriteLine("Time = " + Time);
            Console.WriteLine();
            Console.WriteLine("MaxOfQueue " + MaxOfQueue);
            Console.WriteLine();


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
