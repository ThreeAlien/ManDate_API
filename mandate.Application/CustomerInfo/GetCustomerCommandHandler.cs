using AutoMapper;
using mandate.Domain.Models;
using mandate.Domain.Po;
using mandate.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace mandate.Application.CustomerInfo;

/// <summary>
/// 取得顧客資料
/// </summary>
public class GetCustomerCommandHandler : IRequestHandler<GetCustomerRequest, GetCustomerResponse>
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
    /// 建構子
    /// </summary>
    public GetCustomerCommandHandler(IMapper mapper, ManDateDBContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<GetCustomerResponse> Handle(GetCustomerRequest request, CancellationToken cancellationToken)
    {
        List<SysClientPo> respData = await _context.SysClient.ToListAsync();

        GetCustomerResponse response = new()
        {
            Data = _mapper.Map<List<GetCustInfo>>(respData)
        };

        return response;
    }
}