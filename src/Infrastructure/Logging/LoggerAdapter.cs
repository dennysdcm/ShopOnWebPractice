using Microsoft.Extensions.Logging;
using ShopOnWeb.ApplicationCore.Interfaces;

namespace Infrastructure.Logging
{
    public class LoggerAdapter<T> : IAppLogger<T>
    {
        private readonly ILogger<T> logger;

        public LoggerAdapter(ILoggerFactory loggerFactory)
        {
            this.logger = loggerFactory.CreateLogger<T>();
        }

        public void LogInformation(string message, params object[] args)
        {
            this.logger.LogInformation(message, args);
        }

        public void LogWarning(string message, params object[] args)
        {
            this.logger.LogWarning(message, args);
        }
    }
}
