using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Markup;
using System.Xaml;

namespace MarkupExtensionBox
{
    //[TypeConverter(typeof(StaticExtensionConverter))]
    [MarkupExtensionReturnType(typeof(Type))]
    //[XamlSetMarkupExtension()]
    public class StaticExtension : System.Windows.Markup.MarkupExtension
    {
        private static readonly TypeExtension TypeExtension = new TypeExtension();

        public StaticExtension(string member)
        {
            Member = member;
        }

        [ConstructorArgument("member")]
        public string Member { get; set; }

        public Type MemberType { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (MemberType == null)
            {
                TypeExtension.TypeName = Member.Split('.').First();
                var nr = (IXamlNameResolver)serviceProvider.GetService(typeof (IXamlNameResolver));
                var resolve = nr.Resolve(TypeExtension.TypeName);
                MemberType = (Type) TypeExtension.ProvideValue(serviceProvider);
            }

            return MemberType;
        }
    }
}