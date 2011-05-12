using Machine.Specifications;
using Vitreous.Parser.Elements;

namespace Vitreous.Parser.Tests
{
    public class When_parsing_content
    {
        static ContentElement content;

        Because of = () => 
            content = new ContentElement("  This is some content");

        It sets_the_indent_level = () => 
            content.IndentLevel.ShouldEqual(2);

        It sets_the_content = () => 
            content.Text.ShouldEqual("This is some content");
    }
}