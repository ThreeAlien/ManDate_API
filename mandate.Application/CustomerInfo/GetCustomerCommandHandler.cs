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
        if (request.CustomerID == null){
            List<SysClientPo> respData = await _context.SysClient.ToListAsync();

             response = new()
            {
                Data = _mapper.Map<List<GetCustInfo>>(respData)
            };
        }
        else
        {
            List<SysClientPo> respDatas = await _context.SysClient.ToListAsync();
            var respData = respDatas.Where(x => x.ClientId == request.CustomerID);

             response = new()
            {
                Data = _mapper.Map<List<GetCustInfo>>(respData)
            };
        }


        return response;
    }

}