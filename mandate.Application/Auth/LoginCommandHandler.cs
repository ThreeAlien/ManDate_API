using AutoMapper;
using mandate.Domain.Models;
using mandate.Domain.Models.Auth;
using mandate.Domain.Po;
using mandate.Domain.Vo;
using mandate.Infrastructure;
using mandate.Utility.Crypto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace mandate.Application.Auth;

public class LoginCommandHandler : IRequestHandler<LoginRequest, LoginResponse>
{
    /// <summary>
    /// Db Context
    /// </summary>
    private readonly ManDateDBContext _context;

    /// <summary>
    /// mapper
    /// </summary>
    private readonly IMapper _mapper;

    /// <summary>
    /// Config設定檔
    /// </summary>
    private readonly IConfiguration _configuration;

    /// <summary>
    /// 建構子
    /// </summary>
    public LoginCommandHandler(IMapper mapper, ManDateDBContext context, IConfiguration configuration)
    {
        _mapper = mapper;
        _context = context;
        _configuration = configuration;
    }

    public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        LoginResponse response = new();
        try
        {
            if (string.IsNullOrEmpty(request.Account) || string.IsNullOrEmpty(request.Password))
            {
                return response = new()
                {
                    Code = "404",
                    Data = null,
                    Msg = "帳戶、密碼為必填"
                };
            }

            string iv = _configuration.GetSection("Login").GetValue<string>("IV");
            string key = _configuration.GetSection("Login").GetValue<string>("Key");
            string passWordEncode = AESHelper.Encrypt(key, iv, request.Password);

            List<SysUserPo> userDatas = await _context.SysUser.ToListAsync();
            
            if(userDatas.Count(s => s.UserAccount == request.Account && s.UserPassword == passWordEncode) > 0)
            {
                return response = new()
                {
                    Code = "200",
                    Data = null,
                    Msg = "驗證成功！"
                };
            }

            return response = new()
            {
                Code = "200",
                Data = null,
                Msg = "請註冊帳號！"
            };
        }
        catch (Exception ex)
        {
            response = new()
            {
            };
        }
        return response;
    }
}