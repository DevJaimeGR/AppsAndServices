using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Packt.Shared;

public static class NorthwindContextExtensions
{
    /// <summary>
    /// Adds NorthwindContext to the specified IServiceCollection. Uses the SqlServer database provider.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="connectionString">Set to override the default.</param>
    /// <returns>An IServiceCollection that can be used to add more services.</returns>
    public static IServiceCollection AddNorthwindContext(
        this IServiceCollection services,
        string connectionString = "Data Source=DDC-CO-JGONZALE;Initial Catalog=Northwind;Persist Security Info=True;User ID=sa;Password=admin2023;TrustServerCertificate=True;")
    {
        services.AddDbContext<NorthwindContext>(options =>
        {
            options.UseSqlServer(connectionString);
            options.LogTo(Console.WriteLine,
        new[] { Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.CommandExecuting });
        });
        return services;
    }
}
