using mandate.api.DiExtension;
using mandate.Helper.Mapper;
using mandate.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen();
builder.Services.AddApCommands();
builder.Services.AddDbContext<ManDateDBContext>();
builder.Services.AddAutoMapping();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(1); // Set session timeout
});
WebApplication app = builder.Build();
app.UseSession();
app.MapControllers();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();
app.Run();
