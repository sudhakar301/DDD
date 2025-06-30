var builder = WebApplication.CreateBuilder(args);
{
    // Moved Dependecies to their respective projects
    builder.Services.AddApplication();
    builder.Services.AddInfraStructure();
    builder.Services.AddControllers();
}
var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
