using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.IO;
using RequestResponseMiddleware.Library.Interfaces;
using RequestResponseMiddleware.Library.Models;

namespace RequestResponseMiddleware.Library.Middlewares;

public class RequestResponseLoggingMiddleware: BaseRequestResponseMiddleware
{
    
    public RequestResponseLoggingMiddleware(RequestDelegate next, ILogWriter logWriter):base(next,logWriter)
    {
    }
    
    public async Task Invoke(HttpContext context)
    { 
        await BaseMiddlewareInvoke(context);
    }
    
    
    
    
}