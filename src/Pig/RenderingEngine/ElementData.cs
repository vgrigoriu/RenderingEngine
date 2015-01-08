using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

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

    public abstract class Node<T> : Node
    {
        public T Content { get; }

        public Node(T content, IEnumerable<Node> children)
            : base(children)
        {
            Content = content;
        }
    }

    public class Text : Node<string>
    {
        public Text(string content)
            : base(content, Enumerable.Empty<Node>())
        {

        }
    }

    public class Element : Node<ElementData>
    {
        public Element(string tagName, IDictionary<string, string> attributes, IEnumerable<Node> children)
            : base(new ElementData(tagName, attributes.ToImmutableDictionary()), children)
        {

        }
    }

    public class ElementData
    {
        public string TagName { get; }

        public ImmutableDictionary<string, string> Attributes { get; }

        public ElementData(string tagName, ImmutableDictionary<string, string> attributes)
        {
            TagName = tagName;
            Attributes = attributes;
        }
    }
}
