using AutoMapper;
using mandate.Business.Service;
using mandate.Domain.Models.Customer;
using mandate.Domain.Models.SubClient;
using mandate.Infrastructure;
using MediatR;

namespace mandate.Application.CustomerInfo
{
    /// <summary>
    /// 新增顧客資料(from Google)
    /// </summary>
    public class AddSubClientCommandHandler : IRequestHandler<AddSubClientRequest, AddSubClientResponse>
    {
        #region DI
        /// <summary>
        /// Db Context
        /// </summary>
        private readonly ManDateDBContext _context;
        /// <summary>
        /// mapper
        /// </summary>
        private readonly IMapper _mapper;
        /// <summary>
        /// Google Ads服務
        /// </summary>
        private readonly IGoogleAdsService _googleAdsService;
        #endregion


        /// <summary>
        /// 建構子
        /// </summary>
        public AddSubClientCommandHandler(IMapper mapper, ManDateDBContext context, IGoogleAdsService googleAdsService)
        {        
            _mapper = mapper;
            _context = context;
            _googleAdsService = googleAdsService;
        }

        public async Task<AddSubClientResponse> Handle(AddSubClientRequest request, CancellationToken cancellationToken)
        {
            
            string? refreshToken = await _googleAdsService.GenerateRefreshToken();
            List<SysClientPo> subAccountList = _googleAdsService.FetchAdsAdvertiseAccount(refreshToken);

            foreach (SysClientPo item in subAccountList)
            {
                try
                {
                    Domain.Po.SysSubClientPo sysSubClientPo = new()
                    {
                        SubId = item.ClientId,
                        SubName = item.ClientName,
                    };
                    _context.SysSubClient.Add(sysSubClientPo);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
            AddSubClientResponse response = new();
            response = new()
            {
                // 執行GoogleAds Api範例
                Data = null
            };


            return response;
        }

    }
}
