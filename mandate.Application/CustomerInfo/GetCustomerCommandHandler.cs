using AutoMapper;
using mandate.Domain.Models.Customer;
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
        GetCustomerResponse response = new();

        try
        {
            if (request.ClientId == string.Empty)
            {
                List<SysClientPo> respData = await _context.SysClient.ToListAsync();

                response = new()
                {
                    Data = _mapper.Map<List<GetCustInfo>>(respData)
                };
            }
            else
            {
                List<SysClientPo> respDatas = await _context.SysClient.ToListAsync();
                IEnumerable<SysClientPo> respData = respDatas.Where(x => x.ClientId == request.ClientId);

                response = new()
                {
                    Data = _mapper.Map<List<GetCustInfo>>(respData)
                };
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return response;
    }

}