using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC480_HW1_EightPuzzle
{
    public abstract class Manager
    {
        public Manager()
        {
            this.numNodes = 0;
        }

        public StateNode baseCreateNode(StateNode InNode)
        {
            StateNode sNode = new StateNode(InNode.StateArray2);
            return sNode;
        }

        public void baseAddNode(StateNode node)
        {

        }

        public void baseRemoveNode(StateNode node)
        {

        }

        //data:----------------------------
        int numNodes;
    }
}
