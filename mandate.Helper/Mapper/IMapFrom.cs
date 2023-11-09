using AutoMapper;

namespace mandate.Helper.Mapper;

/// <summary>
/// 建立Map介面
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IMapFrom<T>
{
    /// <summary>
    /// 建立Map
    /// </summary>
    /// <param name="profile"></param>
    void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
}