using static System.Console;
using HtmlParser;

namespace Console
{
	class Program
    {
        static void Main(string[] args)
        {
            var dom = Parser.Parse("<html><title>cucu</title><body><p class='important'>Hello parser</p></body></html>");

            WriteLine(dom);
        }
    }
}
