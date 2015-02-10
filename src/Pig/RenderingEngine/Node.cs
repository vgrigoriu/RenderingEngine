using System.Collections.Generic;

namespace RenderingEngine
{
    public abstract class Node
    {
        public IEnumerable<Node> Children { get; }

        protected Node(IEnumerable<Node> children)
        {
            Children = children;
        }

        public abstract void Accept(INodeVisitor visitor);
    }
}