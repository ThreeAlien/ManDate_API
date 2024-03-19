using AutoMapper;
using mandate.Business.Models;
using mandate.Helper.Mapper;

namespace mandate.Domain.Vo;

/// <summary>
/// 取得權限 Vo
/// </summary>
public class GetAccessRoleVo : IMapFrom<GetAccessRoleResult>
{
    /// <summary>
    /// Email
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// 權限
    /// </summary>
    public string AccessRole { get; set; } = null!;

    void IMapFrom<GetAccessRoleResult>.Mapping(Profile profile)
    {
        profile.CreateMap<GetAccessRoleResult, GetAccessRoleVo>()
            .ForMember(d => d.Email, map => map.MapFrom(s => s.Email))
            .ForMember(d => d.AccessRole, map => map.MapFrom(s => s.AccessRole));
    }
}