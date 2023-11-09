using AutoMapper;
using mandate.Domain.Models;
using mandate.Domain.Po;
using mandate.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace mandate.Application.QueryCustInfo;

/// <summary>
/// 取得顧客資料
/// </summary>
public class QueryCustInfoCommandHandler : IRequestHandler<GetCustomerRequest, GetCustomerResponse>
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
    public QueryCustInfoCommandHandler(IMapper mapper, ManDateDBContext context)
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