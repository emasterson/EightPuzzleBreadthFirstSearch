using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CSC480_HW1_EightPuzzle
{
    public class NodeManager:Manager
    {
        //DATA: -------------------
        public static NodeManager NodeManagerInstance;

        // constructor
        public NodeManager()
            :base()
        {

        }

        public static NodeManager getInstance()
        {
            if (NodeManagerInstance == null)
            {
                NodeManagerInstance = new NodeManager();
            }
            return NodeManagerInstance;
        }

        public static void Add(StateNode node)
        {
            // make sure not null
            Debug.Assert(node != null);

            // get Singleton instance
            NodeManager nManager = NodeManager.getInstance();

            // call base class function
        }

        public static StateNode CreateNode(StateNode node)
        {
            NodeManager nManager = NodeManager.getInstance();

            // call base function
            return nManager.baseCreateNode(node);
        }
    }
}
