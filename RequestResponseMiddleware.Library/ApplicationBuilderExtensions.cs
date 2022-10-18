namespace RequestResponseMiddleware.Library;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder AddRequestResponseMiddleware(this IApplicationBuilder appBuilder, Action<RequestResponseOptions> optionAction)
    {
        var opt = new RequestResponseOptions();
        optionAction(opt);

        if (opt.ReqResHandler is null && opt.LoggerFactory is null)
            throw new ArgumentNullException($"{nameof(opt.ReqResHandler)} and {nameof(opt.LoggerFactory)}");
        
        ILogWriter logWriter = opt.LoggerFactory is null ? new NullLogWriter() : new LoggerFactoryLogWriter(opt.LoggerFactory, opt.LoggingOptions);
        
        if (opt.ReqResHandler is not null)
            appBuilder.UseMiddleware<HandlerRequestResponseLoggingMiddleware>(opt.ReqResHandler, logWriter);
        else
            appBuilder.UseMiddleware<RequestResponseLoggingMiddleware>(logWriter);


        return appBuilder;
    }
}