using RequestResponseMiddleware.Library.Interfaces;
using RequestResponseMiddleware.Library.Models;

namespace RequestResponseMiddleware.Library.MessageCreators;

public class LoggerFactoryMessageCreator : BaseLogMessageCreator, ILogMessageCreator
{
    private readonly LoggingOptions loggingOptions;
    public LoggerFactoryMessageCreator(LoggingOptions loggingOptions)
    {
        this.loggingOptions = loggingOptions;
    }
    public string Create(RequestResponseContext context)
    {
        
        var sb = new StringBuilder();

        foreach (var field in loggingOptions.LoggingFields)
        {
            var value = GetValueByField(context,field);

            sb.AppendFormat("{0}: {1}\n", field, value);
        }
        
        return sb.ToString();
    }
}