var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


app.MapGet("/", () => "Hello World!");

app.Run();