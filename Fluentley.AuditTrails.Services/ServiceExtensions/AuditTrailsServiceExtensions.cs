using System;
using Fluentley.AuditTrails.Services.ServiceExtensions.Options;
using Microsoft.Extensions.DependencyInjection;

namespace Fluentley.AuditTrails.Services.ServiceExtensions
{
    public static class AuditTrailsServiceExtensions
    {
        public static IServiceCollection AddAuditTrails(this IServiceCollection services, Action<AuditTrailServiceOption> configureOptions)
        {
            services.AddScoped(typeof(AuditTrailService), provider =>
            {
                var service = provider.GetRequiredService<AuditTrailService>();
                var options = new AuditTrailServiceOption();
                configureOptions?.Invoke(options);

                service.AddAuditingMethod(options.Method);
                return service;
            });
            return services;
        }
    }

}
