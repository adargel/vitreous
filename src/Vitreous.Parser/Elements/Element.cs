using System.Collections.Generic;
using System.Linq;

namespace Vitreous.Parser.Elements
{
    public abstract class Element
    {
        protected Element(IEnumerable<char> tag)
        {
            IndentLevel = tag.TakeWhile(x => x == ' ').Count();
        }
        public int IndentLevel { get; private set; }
    }
}