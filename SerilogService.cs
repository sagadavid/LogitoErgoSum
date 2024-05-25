using Serilog;
namespace LogitoErgoSum;


public static class SeriLogExtension
{
  public static ILoggingBuilder SeriLog2File(this ILoggingBuilder builder, string logFileName = "seriLog2File.txt", int retainedFileCountLimit = 90)
  {
    var logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs", logFileName);

    var logger = new LoggerConfiguration()
        .WriteTo.File(logFilePath, rollingInterval: RollingInterval.Day, retainedFileCountLimit: retainedFileCountLimit)
        .CreateLogger();

    builder.AddSerilog(logger);

    return builder;
  }
}
