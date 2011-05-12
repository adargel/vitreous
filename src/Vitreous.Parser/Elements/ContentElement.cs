namespace Vitreous.Parser.Elements
{
    public class ContentElement
        : Element
    {
        public ContentElement(string tag) : base(tag)
        {
            Text = tag.Trim();
        }

        public string Text { get; private set; }
    }
}