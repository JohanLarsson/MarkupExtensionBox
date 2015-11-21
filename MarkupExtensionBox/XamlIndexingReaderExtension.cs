using System;
using System.Windows.Markup;
using System.Xaml;
using System.Xml;

namespace MarkupExtensionBox
{
    public class XamlIndexingReaderExtension : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var nsr = serviceProvider.GetService(typeof(IXamlIndexingReader));
            return nsr ?? "null";
        }
    }
}