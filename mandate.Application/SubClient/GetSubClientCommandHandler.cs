using AutoMapper;
using mandate.Business.Constants;
using mandate.Domain.Models.SubClient;
using mandate.Domain.Po;
using mandate.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace mandate.Application.SubClient;

public class GetSubClientCommandHandler : IRequestHandler<GetSubClientRequest, GetSubClientResponse>
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
    public GetSubClientCommandHandler(IMapper mapper, ManDateDBContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<GetSubClientResponse> Handle(GetSubClientRequest request, CancellationToken cancellationToken)
    {
        GetSubClientResponse response = new();
        try
        {
            List<SysSubClientPo> respData = await _context.SysSubClient.ToListAsync();

            response = new()
            {
                Code = ResponseCode.Success,
                Data = _mapper.Map<List<GetSubClientInfo>>(respData),
                Msg = ResponseMsg.Success
            };
        }
        catch (Exception ex)
        {
            response = new()
            {
                Code = ResponseCode.Error,
                Data = null,
                Msg = ResponseMsg.Error
            };
        }

        return response;
    }
}
