using System;
using System.ComponentModel;

namespace MarkupExtensionBox
{
    [TypeConverter(typeof(TypeAndMemberConverter))]
    public class TypeAndMember
    {
        public Type Type { get; set; }

        public string Member { get; set; }
    }
}