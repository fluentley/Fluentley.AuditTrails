using System;
using System.Collections.Generic;
using Fluentley.AuditTrails.Core.Models;

namespace Fluentley.AuditTrails.Services.ServiceExtensions.Options
{
    public class AuditTrailServiceOption
    {
        internal Action<List<AuditTrail>> Method { get; set; }

        public AuditTrailServiceOption HandleRecordAuditing(Action<List<AuditTrail>> auditTrails)
        {
            Method = auditTrails;
            return this;
        }
    }
}