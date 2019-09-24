using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace evasystem.Helpers
{
    public static class EnumHelper
    {
        public static string GetEnumDisplayName(this Enum enumType)
        {
            return enumType.GetType()
                                .GetMember(enumType.ToString())
                                .FirstOrDefault().GetCustomAttributesData()
                                .FirstOrDefault()?.NamedArguments
                                .FirstOrDefault().TypedValue.Value?.ToString() ?? enumType.ToString();
        }
        public static string GetDescription(this Enum enumVal)
        {
            var fieldInfo = enumVal.GetType().GetRuntimeField(enumVal.ToString());
            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}
