using CleanDinner.API.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication();
    builder.Services.AddInfraStructure(builder.Configuration);
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Version = "1.0", Description = "IM API" });
        c.OperationFilter<OperationFilter>();                                                                //add xsrftoken as a header in the swagger
    });
}
var app = builder.Build();
{
   // app.UseHttpsRedirection();
    app.UseSwagger(); 
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sample API");
        c.RoutePrefix = "api/swagger";
    });
    app.MapControllers();
    app.Run();
}
