using Serilog;
using LogitoErgoSum;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//clear pre-registered log providers.. but add console for manuel logs
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();
//builder.Logging.AddEventLog();//only for windows

//third parthy logger to log to file
// try
// {
//     var seriLogger = new LoggerConfiguration().WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/serilog2file.txt"), rollingInterval: RollingInterval.Day, retainedFileCountLimit: 90).CreateLogger();
//     builder.Logging.AddSerilog(seriLogger);
// }
// catch (Exception ex)
// {
//     throw new Exception("seriLogger cant do the job", ex);
// }

//use extension instead
builder.Logging.SeriLog2File();


builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
