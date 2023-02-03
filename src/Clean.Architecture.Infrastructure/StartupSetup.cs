namespace Clean.Architecture.Infrastructure;

using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// TODO.
/// </summary>
public static class StartupSetup
{
  /// <summary>
  /// TODO.
  /// </summary>
  /// <param name="services">TODO LATER1.</param>
  /// <param name="connectionString">TODO LATER2.</param>
  public static void AddDbContext(this IServiceCollection services, string connectionString) =>
    services.AddDbContext<AppDbContext>(options =>
      options.UseSqlite(connectionString)); // will be created in web project root
}
