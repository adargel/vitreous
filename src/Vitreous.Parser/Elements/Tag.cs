using System.Text.RegularExpressions;

namespace Vitreous.Parser.Elements
{
    public class Tag
        : Element
    {
        static readonly Regex Expression = new Regex(@"%([-:\w]+)([-:\w\.\#]*)(\(.*\))?(/|>|<)?(.*)$");

        public Tag(string simpleTag)
            : base(simpleTag)
        {
            var match = Expression.Match(simpleTag);

            Name = match.Groups[1].Value;
            ClassOrIdAttributes = match.Groups[2].Value;
            Attributes = match.Groups[3].Value;
            IsSelfClosing = match.Groups[4].Value.Equals("/");
            ShouldChompOuterWhiteSpace = match.Groups[4].Value.Equals(">");
            ShouldChompInnerWhiteSpace = match.Groups[4].Value.Equals("<");
            Content = match.Groups[5].Value.Trim();
        }

        public string Name { get; private set; }
        public string Attributes { get; private set; }
        public string Content { get; private set; }
        public string ClassOrIdAttributes { get; private set; }
        public bool IsSelfClosing { get; private set; }
        public bool ShouldChompOuterWhiteSpace { get; private set; }
        public bool ShouldChompInnerWhiteSpace { get; private set; }
    }
}