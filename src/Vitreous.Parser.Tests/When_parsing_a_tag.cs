using Machine.Specifications;
using Vitreous.Parser.Elements;

namespace Vitreous.Parser.Tests
{
    public class When_parsing_a_simple_tag
    {
        protected static string simpleTag;
        protected static Tag tag;
    }

    public class When_parsing_a_tag_without_attributes
        : When_parsing_a_simple_tag
    {
        Establish context = () =>
        {
            simpleTag = "%p";
        };

        Because of = () =>
            tag = new Tag(simpleTag);

        It sets_the_name_of_the_tag = () =>
            tag.Name.ShouldEqual("p");

        It has_no_attributes = () =>
            tag.Attributes.Length.ShouldEqual(0);
    }

    public class When_parsing_a_tag_with_attributes
        : When_parsing_a_simple_tag
    {
        Establish context = () =>
            {
                simpleTag = "%p(data-first-name='howdy', data-last-name='doody') This is some content.";
            };

        Because of = () =>
            tag = new Tag(simpleTag);

        It sets_the_name_of_the_tag = () =>
            tag.Name.ShouldEqual("p");

        It parses_its_attributes = () =>
            tag.Attributes.Length.ShouldNotEqual(0);

        It sets_the_content = () =>
            tag.Content.ShouldEqual("This is some content.");
    }

    public class When_parsing_an_indented_tag
        : When_parsing_a_simple_tag
    {
        Establish context = () =>
        {
            simpleTag = "   %p(data-first-name='howdy', data-last-name='doody')";
        };

        Because of = () =>
            tag = new Tag(simpleTag);

        It sets_the_indent_level = () =>
            tag.IndentLevel.ShouldEqual(3);
    }

    public class When_parsing_a_self_closing_tag_with_attributes
        : When_parsing_a_simple_tag
    {
        Establish context = () =>
        {
            simpleTag = "   %p(data-first-name='howdy', data-last-name='doody')/";
        };

        Because of = () =>
            tag = new Tag(simpleTag);

        It sets_self_closing = () =>
            tag.IsSelfClosing.ShouldBeTrue();
    }

    public class When_parsing_a_self_closing_tag_without_attributes
        : When_parsing_a_simple_tag
    {
        Establish context = () =>
        {
            simpleTag = "   %p/";
        };

        Because of = () =>
            tag = new Tag(simpleTag);

        It sets_self_closing = () =>
            tag.IsSelfClosing.ShouldBeTrue();
    }

    public class When_chomping_outer_whitespace
        : When_parsing_a_simple_tag
    {
        Establish context = () =>
        {
            simpleTag = "   %p(data-first-name='howdy', data-last-name='doody')>";
        };

        Because of = () =>
            tag = new Tag(simpleTag);

        It sets_self_closing = () =>
            tag.ShouldChompOuterWhiteSpace.ShouldBeTrue();
    }
}