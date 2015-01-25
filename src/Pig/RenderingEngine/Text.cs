using System.Linq;

namespace RenderingEngine
{
    public class Text : Node<string>
    {
        public Text(string content)
            : base(content, Enumerable.Empty<Node>())
        {

        }

        public override string ToString()
        {
            return Content;
        }
    }
}