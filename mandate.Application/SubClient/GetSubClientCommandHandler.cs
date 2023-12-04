using AutoMapper;
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
                Data = _mapper.Map<List<GetSubClientInfo>>(respData)
            };
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return response;
    }
}
