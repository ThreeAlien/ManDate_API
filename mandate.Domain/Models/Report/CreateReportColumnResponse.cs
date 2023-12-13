using AutoMapper;
using mandate.Domain.Po;
using mandate.Helper.Mapper;

namespace mandate.Domain.Models;

/// <summary>
/// 取得顧客資料 Response
/// </summary>
public class CreateReportColumnResponse
{
    public string? Code { get; set; }

    public string? Data { get; set; }

    public string? Msg { get; set; }

}

