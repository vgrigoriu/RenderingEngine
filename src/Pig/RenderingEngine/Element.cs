using System.Collections.Generic;
using System.Collections.Immutable;

namespace RenderingEngine
{
    public class Element : Node<ElementData>
    {
        public Element(string tagName, IDictionary<string, string> attributes, IEnumerable<Node> children)
            : base(new ElementData(tagName, attributes.ToImmutableDictionary()), children)
        {

        }
    }
}