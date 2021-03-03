using FirstApp.Application.Interfaces;
using FirstApp.Application.Services;
using FirstApp.Domain.Interfaces;
using FirstApp.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FirstApp.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
