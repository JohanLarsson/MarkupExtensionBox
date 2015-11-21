using System.Windows.Media;
using Microsoft.Windows.Design.Metadata;
using Microsoft.Windows.Design.Model;

namespace MarkupExtensionBox.Design
{
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