using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Bala.DataContext.Sqlite;

public static class JournalDbContextExtensions
{
    /// <summary>
    /// Adds JournalDbContaxt to the specified IServiceCollection. Uses the Sqlite database provider.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="relativePath">Default is ".."</param>
    /// <param name="databaseName">Default is "Northwind.db"</param>
    /// <returns>An IServiceCollection that can be used to add more services.</returns>
    public static IServiceCollection AddJournalDbContext(
        this IServiceCollection services,
        string relativePath = "..",
        string databaseName = "Journal.db")
    {
        string path = Path.Combine(relativePath, databaseName);
        path = Path.GetFullPath(path);

        // Ensure directory exists
        string? directory = Path.GetDirectoryName(path);
        if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        services.AddDbContext<JournalDbContext>(options =>
        {
            options.UseSqlite($"Filename={path}");
        },
        contextLifetime: ServiceLifetime.Transient,
        optionsLifetime: ServiceLifetime.Transient);



        return services;
    }
}

