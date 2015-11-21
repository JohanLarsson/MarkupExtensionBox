using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Threading;
using MarkupExtensionBox.Annotations;

namespace MarkupExtensionBox
{
    [MarkupExtensionReturnType(typeof(BindingExpression))]
    public class CounterExtension : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var counter = new Counter();
            var binding = new Binding(nameof(counter.Value))
            {
                Source = counter,
                Mode = BindingMode.OneWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            return binding.ProvideValue(serviceProvider);
        }
    }
}
