using mandate.api.DiExtension;
using mandate.Infrastructure;
using System.Reflection;
using mandate.Helper.Mapper;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen();
builder.Services.AddApCommands();
builder.Services.AddDbContext<ManDateDBContext>();
builder.Services.AddAutoMapping();
WebApplication app = builder.Build();
app.MapControllers();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();
app.Run();
