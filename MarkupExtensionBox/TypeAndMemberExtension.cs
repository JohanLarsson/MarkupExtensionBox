using System;
using System.Windows.Markup;

namespace MarkupExtensionBox
{
    [MarkupExtensionReturnType(typeof(Type))]
    public class TypeAndMemberExtension : System.Windows.Markup.MarkupExtension
    {
        public TypeAndMemberExtension()
        {
        }

        public TypeAndMemberExtension(TypeAndMember member)
        {
            Member = member;
        }

        [ConstructorArgument("Member")]
        public TypeAndMember Member { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Member.Type;
        }
    }
}
