using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using Microsoft.Windows.Design;
using Microsoft.Windows.Design.Metadata;
using Microsoft.Windows.Design.Model;

namespace MarkupExtensionBox.Design
{
    public class RegisterMetadata : IProvideAttributeTable
    {
        public AttributeTable AttributeTable
        {
            get
            {
                Debugger.Break();
                AttributeTableBuilder builder = new AttributeTableBuilder();
                builder.AddCustomAttributes(typeof(Window), nameof(FuuAttribute), DesignOnlyAttribute.Yes);
                builder.AddCustomAttributes(typeof(Window), nameof(Meh), DesignOnlyAttribute.Yes);
                return builder.CreateTable();
            }
        }
    }

    public class Meh : DesignModeValueProvider
    {
        public override object TranslatePropertyValue(ModelItem item, PropertyIdentifier identifier, object value)
        {
            var modelProperty = item.Properties["Background"];
            modelProperty.SetValue(Colors.HotPink);
            return base.TranslatePropertyValue(item, identifier, value);
        }
    }
}
