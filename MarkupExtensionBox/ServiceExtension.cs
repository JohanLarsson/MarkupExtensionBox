using System;
using System.ComponentModel;
using System.Windows.Markup;

namespace MarkupExtensionBox
{
    public class ServiceExtension : MarkupExtension
    {
        public ServiceExtension()
        {
        }

        public ServiceExtension(Type serviceType)
        {
            ServiceType = serviceType;
        }

        [ConstructorArgument("serviceType")]
        public Type ServiceType { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object Service { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (ServiceType == null)
            {
                Service= "ServiceType == null";
                return this;
            }
            var nsr = serviceProvider.GetService(ServiceType);
            Service= nsr ?? "null";
            return this;
        }
    }
}