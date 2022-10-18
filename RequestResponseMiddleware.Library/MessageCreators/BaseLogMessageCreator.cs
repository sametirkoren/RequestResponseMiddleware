using RequestResponseMiddleware.Library.Models;

namespace RequestResponseMiddleware.Library.MessageCreators;

public abstract  class BaseLogMessageCreator
{
    protected string? GetValueByField(RequestResponseContext context, LogFields field)
    {
        return field switch
        {
            LogFields.Request => context.RequestBody,
            LogFields.Response => context.ResponseBody,
            LogFields.QueryString => context.context?.Request.QueryString.Value,
            LogFields.Path => context.context?.Request.Path.Value,
            LogFields.HostName => context.context?.Request.Host.Value,
            LogFields.RequestLength => context.RequestLength.ToString(),
            LogFields.ResponseLength => context.ResponseLength.ToString(),
            LogFields.ResponseTiming => context.FormattedCreationTime,
            _ => string.Empty
        };
    }
}