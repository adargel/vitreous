namespace Vitreous.Parser.Elements
{
    public class DivTag
        : Tag
    {
        public DivTag(string divTag)
            : base("%div" + divTag)
        {

        }
    }
}