using System;
using System.Windows.Data;
using System.Windows.Markup;

namespace MarkupExtensionBox
{
    [MarkupExtensionReturnType(typeof(BindingExpression))]
    public class DesignTimeExtension : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var instance = DesignTimeValue.Instance;
            var binding = new Binding(nameof(instance.CurrentValue))
            {
                Source = instance,
                Mode = BindingMode.OneWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            return binding.ProvideValue(serviceProvider);
        }
    }
}
