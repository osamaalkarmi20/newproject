﻿namespace newproject.Logging
{
    public class DatabaseLoggerProvider : ILoggerProvider
    {
        private readonly IServiceProvider _serviceProvider;

        public DatabaseLoggerProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new DatabaseLogger(_serviceProvider);
        }

        public void Dispose()
        {
        }
    }
}


