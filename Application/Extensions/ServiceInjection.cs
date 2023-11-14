using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions
{
    public static class ServiceInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(ServiceInjection).Assembly;

            services.AddMediatR(c => c.RegisterServicesFromAssembly(assembly));
            services.AddValidatorsFromAssembly(assembly);

            return services;
        }
    }
}
