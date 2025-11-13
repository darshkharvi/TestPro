using DataCore;
using DataServices.DesignationServices.commands;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddDbContext<TestProContext>(options =>
    options.UseSqlServer(configuration["ConnectionStrings:TestProDB"], d => d.MigrationsAssembly("DataCore")));

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(AddDesignationHandler).Assembly));

builder.Services.AddScoped<ITestProUnitOfWork, TestProUnitOfWork>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowAll",
      policy => policy.AllowAnyOrigin()
                      .AllowAnyHeader()
                      .AllowAnyMethod());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger(c =>
  {
    c.OpenApiVersion = Microsoft.OpenApi.OpenApiSpecVersion.OpenApi2_0;
  });
  app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
