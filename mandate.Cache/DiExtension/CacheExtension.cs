using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace mandate.Cache.DiExtension;

public static class CacheExtension
{
    /// <summary>
    /// Cache DI extension method
    /// </summary>
    /// <param name="services">ServiceCollection</param>
    /// <param name="configuration">config</param>
    /// <returns></returns>
    public static IServiceCollection AddCache(this IServiceCollection services, IConfiguration configuration)
    {
        CacheOption opt = configuration.GetSection(CacheOption.SectionName).Get<CacheOption>()!;
        if (!string.IsNullOrWhiteSpace(opt.RedisConnectionString))
        {
            services.AddStackExchangeRedisCache(option =>
            {
                option.Configuration = opt.RedisConnectionString;
                option.InstanceName = opt.InstanceName;
            });
            //services.AddScoped<ICacheService, RedisCacheService>();
        }
        else
        {
            services.AddMemoryCache();
            services.AddScoped<ICacheService, MemoryCacheService>();
        }
        return services;
    }
}