using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mandate.Domain.Models.Customer
{
    /// <summary>
    /// 新增顧客資料(from Google) Request
    /// </summary>
    public class CreatCustomerRequest : IRequest<CreatCustomerResponse>
    {
    }
}
