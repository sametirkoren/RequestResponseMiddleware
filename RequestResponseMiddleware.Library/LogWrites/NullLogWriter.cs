using RequestResponseMiddleware.Library.Interfaces;
using RequestResponseMiddleware.Library.Models;

namespace RequestResponseMiddleware.Library.LogWrites;

public class NullLogWriter : ILogWriter
{
    public ILogMessageCreator MessageCreator { get; }
    public Task Write(RequestResponseContext context)
    {
        return Task.CompletedTask;
    }
}