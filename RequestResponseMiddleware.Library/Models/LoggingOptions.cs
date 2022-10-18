using Microsoft.Extensions.Logging;

namespace RequestResponseMiddleware.Library.Models;

public class LoggingOptions
{
    private List<LogFields> loggingFields;
    
    public LogLevel LogLevel { get; set; } = LogLevel.Information;

    public string LoggerCategoryName { get; set; } = "RequestResponseLoggerMiddleware";

    public List<LogFields> LoggingFields
    {
        get
        {
            return loggingFields ??= new List<LogFields>();
        }

        set => loggingFields = value;
    }
}

public enum LogFields
{
    Request,
    Response,
    HostName,
    Path,
    QueryString,
    ResponseTiming,
    RequestLength,
    ResponseLength
}