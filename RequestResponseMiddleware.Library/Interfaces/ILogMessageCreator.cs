using RequestResponseMiddleware.Library.Models;

namespace RequestResponseMiddleware.Library.Interfaces;

public interface ILogMessageCreator
{
    string Create(RequestResponseContext context);
}