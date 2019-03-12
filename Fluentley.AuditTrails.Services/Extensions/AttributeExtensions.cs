using System;
using System.Reflection;

namespace Fluentley.AuditTrails.Services.Extensions
{
    internal static class AttributeExtensions
    {
        public static TAttribute CustomAttribute<TAttribute>(this Type entryType) where TAttribute : Attribute
        {
            return (TAttribute) Attribute.GetCustomAttribute(entryType, typeof(TAttribute));
        }

        public static TAttribute PropertyCustomAttribute<TAttribute>(this PropertyInfo entryType) where TAttribute : Attribute
        {
            return (TAttribute) Attribute.GetCustomAttribute(entryType, typeof(TAttribute));
        }
    }
}