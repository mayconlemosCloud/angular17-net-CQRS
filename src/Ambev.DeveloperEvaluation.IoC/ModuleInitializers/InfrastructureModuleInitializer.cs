using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.ORM;
using Ambev.DeveloperEvaluation.ORM.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ambev.DeveloperEvaluation.IoC.ModuleInitializers;

public class InfrastructureModuleInitializer : IModuleInitializer
{
    public void Initialize(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<DbContext>(provider => provider.GetRequiredService<DefaultContext>());
        builder.Services.AddScoped<DbContext>(provider => provider.GetRequiredService<SalesContext>());

    
        var serviceProvider = builder.Services.BuildServiceProvider();

        using (var scope = serviceProvider.CreateScope())
        {
            var defaultContext = scope.ServiceProvider.GetRequiredService<DefaultContext>();
            defaultContext.Database.Migrate();

            var salesContext = scope.ServiceProvider.GetRequiredService<SalesContext>();
            salesContext.Database.Migrate();
        }

        builder.Services.AddScoped<ISalesRepository, SalesRepository>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
    }
}