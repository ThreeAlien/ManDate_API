using AutoMapper;

namespace mandate.Utility.Extension;

/// <summary>
/// AutoMapper擴充功能
/// </summary>
public static class AutoMapperExtension
{
    /// <summary>
    /// 略過Mapping
    /// </summary>
    /// <typeparam name="TSourse"></typeparam>
    /// <typeparam name="TDestination"></typeparam>
    /// <param name="expr"></param>
    /// <returns></returns>
    public static IMappingExpression<TSourse, TDestination> IgnoreAllMember<TSourse, TDestination>(this IMappingExpression<TSourse, TDestination> expr)
    {
        Type destinationType = typeof(TDestination);

        foreach (System.Reflection.PropertyInfo property in destinationType.GetProperties())
        {
            expr.ForMember(property.Name, map => map.Ignore());
        }
        return expr;
    }
}