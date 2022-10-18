using RequestResponseMiddleware.Library;
using RequestResponseMiddleware.Library.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging(conf =>
{
    conf.AddConsole();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AddRequestResponseMiddleware(opt =>
{
    opt.UseHandler(async context =>
    {
        Console.WriteLine($"RequestBody: {context.RequestBody}");    
        Console.WriteLine($"ResponseBody: {context.ResponseBody}");    
        Console.WriteLine($"Timing: {context.FormattedCreationTime}");    
        Console.WriteLine($"Url: {context.Url}");    
    });
    opt.UseLogger(app.Services.GetRequiredService<ILoggerFactory>(), opt =>
    {
        opt.LogLevel = LogLevel.Error;
        opt.LoggerCategoryName = "MyCustomCategoryName";
        
        opt.LoggingFields.Add(RequestResponseMiddleware.Library.Models.LogFields.Request);
        opt.LoggingFields.Add(RequestResponseMiddleware.Library.Models.LogFields.Response);
        opt.LoggingFields.Add(RequestResponseMiddleware.Library.Models.LogFields.ResponseTiming);
        opt.LoggingFields.Add(RequestResponseMiddleware.Library.Models.LogFields.Path);
        opt.LoggingFields.Add(RequestResponseMiddleware.Library.Models.LogFields.QueryString);
    });
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();