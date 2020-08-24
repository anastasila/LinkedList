using System;
using System.Collections;

namespace LinkedListProject
{
    public class Node
    {

        public Node(int Value)
        {
            this.Value = Value;
        }

        public int Value { get; set; }
        public Node Next { get; set; }

    }
    
}
