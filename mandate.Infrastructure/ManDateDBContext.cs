using mandate.Domain.Po;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace mandate.Infrastructure;

/// <summary>
/// DB Context
/// </summary>
public class ManDateDBContext : DbContext
{
    protected readonly IConfiguration _configuration;
    public ManDateDBContext(DbContextOptions<ManDateDBContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    /// <summary>
    ///Ads數據表(SysAdsData)
    /// </summary>
    public DbSet<SysAdsDataPo> SysAdsData { get; set; }

    /// <summary>
    ///客戶基本資料表(SysClient)
    /// </summary>
    public DbSet<SysClientPo> SysClient { get; set; }

    /// <summary>
    ///報表內容表(SysReportContent)
    /// </summary>
    public DbSet<SysReportContentPo> SysReportContent { get; set; }

    /// <summary>
    ///報表(SysReportContent)
    /// </summary>
    public DbSet<SysReportPo> SysReport { get; set; }

    /// <summary>
    ///子客戶資料表(SysSubClient)
    /// </summary>
    public DbSet<SysSubClientPo> SysSubClient { get; set; }

    /// <summary>
    ///報表(SysReportColumn)
    /// </summary>
    public DbSet<SysReportColumnPo> SysReportColumn { get; set; }

    /// <summary>
    /// 權限設定
    /// </summary>
    public DbSet<SysUserPo> SysUser { get; set; }

    #region GCP 資料導入
    /// <summary>
    ///報表(SysAdsDataAdGroupAd)
    /// </summary>
    public DbSet<SysAdsDataAdGroupAdPo> SysAdsDataAdGroupAd { get; set; }

    /// <summary>
    ///報表(SysAdsDataCampaign)
    /// </summary>
    public DbSet<SysAdsDataCampaignPo> SysAdsDataCampaign { get; set; }

    /// <summary>
    ///報表(SysAdsDataCampaignConversion)
    /// </summary>
    public DbSet<SysAdsDataCampaignConversionPo> SysAdsDataCampaignConversion { get; set; }

    /// <summary>
    ///報表(SysAdsDataCampaignAction)
    /// </summary>
    public DbSet<SysAdsDataCampaignActionPo> SysAdsDataCampaignAction { get; set; }

    /// <summary>
    ///報表(SysAdsDataAdGroupCriterion)
    /// </summary>
    public DbSet<SysAdsDataAdGroupCriterionPo> SysAdsDataAdGroupCriterion { get; set; }

    /// <summary>
    ///報表(SysAdsDataCriterionCon)
    /// </summary>
    public DbSet<SysAdsDataCampaignConPo> SysAdsDataCampaignCon { get; set; }

    /// <summary>
    ///報表(SysAdsDataCriterionLocation)
    /// </summary>
    public DbSet<SysAdsDataCampaignLocationPo> SysAdsDataCampaignLocation { get; set; }

    /// <summary>
    ///報表(SysAdsDataAgeView)
    /// </summary>
    public DbSet<SysAdsDataAgeViewPo> SysAdsDataAgeView { get; set; }

    /// <summary>
    ///報表(SysAdsDataGenderView)
    /// </summary>
    public DbSet<SysAdsDataGenderViewPo> SysAdsDataGenderView { get; set; }

    /// <summary>
    ///報表(SysAdsDataKeywordView)
    /// </summary>
    public DbSet<SysAdsDataKeywordViewPo> SysAdsDataKeywordView { get; set; }

    /// <summary>
    ///報表(SysAdsDataLocationView)
    /// </summary>
    public DbSet<SysAdsDataLocationViewPo> SysAdsDataLocationView { get; set; }
    #endregion

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SysAdsDataPo>().HasNoKey();

        modelBuilder.Entity<SysClientPo>().HasKey(c => c.ClientId);

        modelBuilder.Entity<SysReportContentPo>().HasKey(c => c.ContentID);

        modelBuilder.Entity<SysReportPo>().HasKey(c => c.ReportNo);

        modelBuilder.Entity<SysSubClientPo>().HasKey(c => c.SubNo);

        modelBuilder.Entity<SysReportColumnPo>().HasKey(c => c.ReportNo);

        modelBuilder.Entity<SysUserPo>().HasKey(c => c.UserNo);

        #region GCP 資料導入
        modelBuilder.Entity<SysAdsDataAdGroupAdPo>().HasKey(c => new { c.ColDate, c.CampaignID });
        modelBuilder.Entity<SysAdsDataCampaignPo>().HasKey(c => new { c.ColDate, c.CampaignID });
        modelBuilder.Entity<SysAdsDataCampaignConversionPo>().HasKey(c => new { c.CustomerID, c.CampaignID });
        modelBuilder.Entity<SysAdsDataCampaignActionPo>().HasKey(c => new { c.ColDate, c.ActionID });
        modelBuilder.Entity<SysAdsDataAdGroupCriterionPo>().HasKey(c => new { c.CustomerID, c.CampaignID });
        modelBuilder.Entity<SysAdsDataCampaignConPo>().HasKey(c => new { c.CustomerID, c.CampaignID });
        modelBuilder.Entity<SysAdsDataCampaignLocationPo>().HasKey(c => new { c.ColDate, c.CampaignID });

        modelBuilder.Entity<SysAdsDataAgeViewPo>().HasKey(c => new { c.SerialID, c.CampaignID });
        modelBuilder.Entity<SysAdsDataGenderViewPo>().HasKey(c => new { c.SerialID, c.CampaignID });
        modelBuilder.Entity<SysAdsDataKeywordViewPo>().HasKey(c => new { c.SerialID, c.CampaignID });
        modelBuilder.Entity<SysAdsDataLocationViewPo>().HasKey(c => new { c.SerialID, c.CampaignID });
        #endregion


    }
}