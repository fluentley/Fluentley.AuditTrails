using System;

namespace Fluentley.AuditTrails.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class AuditTrailsAttribute : Attribute
    {
        public bool Ignore { get; set; }
    }
}