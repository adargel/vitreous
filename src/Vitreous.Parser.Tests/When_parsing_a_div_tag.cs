using Machine.Specifications;
using Vitreous.Parser.Elements;

namespace Vitreous.Parser.Tests
{
    public class When_parsing_a_div_tag
    {
        protected static string divTag;
        protected static Tag div;
    }

    public class When_parsing_a_div_tag_with_the_id_key
        : When_parsing_a_div_tag
    {
        Establish context = () => divTag = "#theid.andclass";

        Because of = () => 
            div = new DivTag(divTag);

        It sets_the_class_or_id_attributes = () =>
            div.ClassOrIdAttributes.ShouldEqual("#theid.andclass");

        It sets_the_name_to_div = () =>
            div.Name.ShouldEqual("div");
    }
}