using System.Collections.Generic;

namespace RenderingEngine
{
    public abstract class Node<T> : Node
    {
        public T Content { get; }

        public Node(T content, IEnumerable<Node> children)
            : base(children)
        {
            Content = content;
        }
    }
}