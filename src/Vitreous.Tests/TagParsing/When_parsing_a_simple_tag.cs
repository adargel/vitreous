using System.Collections.Generic;
using Machine.Specifications;
using System.Linq;

namespace Vitreous.Tests.TagParsing
{
    public class When_parsing_a_simple_tag
    {
        static string simpleTag = "%header(data-first-name='howdy', data-last-name='doody')";
        static SimpleTag tag;

        Establish context = () =>
            {
                simpleTag = "%header";
            };

        Because of = () => tag = new SimpleTag(simpleTag);

        It sets_the_name_of_the_tag = ()=> 
            tag.Name.ShouldEqual("header");

        It parses_its_attributes = () =>
            tag.Attributes.Count().ShouldEqual(2);

        It parsed_the_first_tag = () =>
            {
                tag.Attributes[0].Name.ShouldEqual("data-first-name");
                tag.Attributes[0].Value.ShouldEqual("howdy");
            };
    }

    public class SimpleTag
    {
        public SimpleTag(string simpleTag)
        {
            Name = "header";
            Attributes = new List<TagAttribute> {new TagAttribute(), new TagAttribute()};
        }

        public string Name { get; private set; }
        public IList<TagAttribute> Attributes { get; set; }
    }

    public class TagAttribute
    {
        public TagAttribute()
        {
            Name = "data-first-name";
            Value = "howdy";
        }

        public string Name { get; private set; }
        public object Value { get; private set; }
    }
}