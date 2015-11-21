using System;
using System.Windows.Markup;
using System.Xaml;

namespace MarkupExtensionBox
{
    public class XamlNameProviderExtension : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var nsr = serviceProvider.GetService(typeof(IXamlNameProvider));
            return nsr ?? "null";
        }
    }
}