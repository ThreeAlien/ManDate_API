using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using System.Reflection;

namespace mandate.Helper.Mapper;

/// <summary>
/// 注入AutoMapper工具
/// </summary>
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        Assembly[] assemblies = DependencyContext.Default.RuntimeLibraries
            .Where(e => e.Name.StartsWith("mandate"))
            .Select(e => Assembly.Load(new AssemblyName(e.Name))).ToArray();
        ApplyMappingsAssembly(assemblies);
    }

    ///<summary>
	/// 將所有 IMapTo ImapFrom的interface 建立AutoMapper
	/// <param name="assemblies"></param>
    public void ApplyMappingsAssembly(IEnumerable<Assembly> assemblies)
    {
        List<Type> types = assemblies
            .SelectMany(a => a.GetTypes())
            .Where(t => t.GetInterfaces().Any(i => i.IsGenericType &&
            TypeEquals(i.GetGenericTypeDefinition(), new Type[] { typeof(IMapTo<>), typeof(IMapFrom<>) }))).ToList();

        var iMapFroms = types.Select(t => new
        {
            Type = t,
            InterFaces = t.GetInterfaces()
                .Where(i => i.IsGenericType &&
                TypeEquals(i.GetGenericTypeDefinition(), new Type[] { typeof(IMapTo<>), typeof(IMapFrom<>) }))
        });

        foreach (var map in iMapFroms)
        {
            object instance = Activator.CreateInstance(map.Type);

            List<MethodInfo> methods = map.InterFaces
                .Select(i => i.GetMethod(nameof(IMapTo<object>.Mapping)))
                .ToList();

            foreach (MethodInfo method in methods)
            {
                method?.Invoke(instance, new object[] { this });
            }
        }

    }

    private bool TypeEquals(Type source, Type[] target)
            => target.Any(e => e == source);
}

/// <summary>
/// 注入AutoMapper
/// </summary>
public static partial class Mapping
{
    public static IServiceCollection AddAutoMapping(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile).Assembly);
        return services;
    }
}