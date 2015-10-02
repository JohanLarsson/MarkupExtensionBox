//using System;
//using System.Collections;
//using System.ComponentModel;
//using System.ComponentModel.Design.Serialization;
//using System.Diagnostics;
//using System.Globalization;
//using System.Reflection;
//using System.Security;

//namespace MarkupExtensionBox
//{
//    public class StaticExtensionConverter : TypeConverter
//    {
//        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
//        {
//            if (destinationType == typeof(InstanceDescriptor))
//            {
//                return true;
//            }
//            return base.CanConvertTo(context, destinationType);
//        }

//        [SecurityCritical]
//        [SecurityTreatAsSafe]
//        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
//        {
//            Debugger.Break();
//            if (!(destinationType == typeof(InstanceDescriptor)))
//            {
//                return base.ConvertTo(context, culture, value, destinationType);
//            }
//            var resourceExtension = value as TypeAndMemberExtension;
//            if (resourceExtension == null)
//            {
//                throw new ArgumentException("MustBeOfType: " + typeof(TypeAndMemberExtension).Name);
//            }
//            var constructor = (MemberInfo)typeof(TypeAndMemberExtension).GetConstructor(new[] { typeof(Type), typeof(string) });
//            var collection = (ICollection)new object[] { resourceExtension.Type, resourceExtension.Key };
//            return new InstanceDescriptor(constructor, collection);
//        }
//    }
//}