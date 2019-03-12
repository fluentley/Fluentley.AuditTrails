using System;

namespace Fluentley.AuditTrails.Core.Models
{
    public class AuditTrail
    {
        public string TableName { get; set; }
        public DateTime DateTime { get; set; }
        public string KeyValues { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
        public string UserName { get; set; }
    }
}