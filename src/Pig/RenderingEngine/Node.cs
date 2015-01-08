using System.Collections.Generic;

namespace RenderingEngine
{
    public abstract class Node
    {
        public IEnumerable<Node> Children { get; }

        public Node(IEnumerable<Node> children)
        {
            Children = children;
        }
    }
}