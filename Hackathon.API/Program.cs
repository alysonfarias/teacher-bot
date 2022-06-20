using Hackathon.API.Config;
using Hackathon.API.Filters;
using Hackathon.Application.Mappers;
using Hackathon.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

//builder
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionString:AWS_SQLServerConnection"]);
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();
builder.Services.AddCors();
ConfigureServices(builder.Services, builder.Configuration);

//app
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
ConfigureMiddleware(app , app.Services);
app.MapControllers();
app.Run();

//Configure
void ConfigureServices(IServiceCollection services, ConfigurationManager configuration)
{
    services.AddHttpContextAccessor();
    services.AddDependencyInjection(); 
    services.AddControllers(opts =>
    {
        opts.Filters.Add(new ApplicationExceptionFilter());
    });  
    builder.Services.AddAutoMapper(typeof(DomainToResponseProfile), typeof(RequestToDomainProfile));
}

void ConfigureMiddleware(WebApplication app, IServiceProvider services)
{
    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
    app.UseAuthentication();
    app.UseAuthorization();
}