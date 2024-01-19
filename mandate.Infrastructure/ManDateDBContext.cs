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
    #endregion

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SysClientPo>().HasKey(c => c.ClientId);

        modelBuilder.Entity<SysReportContentPo>().HasKey(c => c.ContentID);

        modelBuilder.Entity<SysReportPo>().HasKey(c => c.ReportID);

        modelBuilder.Entity<SysSubClientPo>().HasKey(c => c.SubNo);

        modelBuilder.Entity<SysReportColumnPo>().HasKey(c => c.ColumnId);

        #region GCP 資料導入
        modelBuilder.Entity<SysAdsDataAdGroupAdPo>().HasNoKey();
        modelBuilder.Entity<SysAdsDataCampaignPo>().HasNoKey();
        modelBuilder.Entity<SysAdsDataCampaignActionPo>().HasNoKey();
        modelBuilder.Entity<SysAdsDataAdGroupCriterionPo>().HasNoKey();
        modelBuilder.Entity<SysAdsDataCampaignConPo>().HasNoKey();
        #endregion


    }
}