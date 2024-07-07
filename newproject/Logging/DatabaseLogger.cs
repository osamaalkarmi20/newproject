using newproject.data;
using newproject.Models;
namespace newproject.Logging
{
    public class DatabaseLogger : ILogger
    {
        private readonly IServiceProvider _serviceProvider;

        public DatabaseLogger(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IDisposable BeginScope<TState>(TState state) => null;

        public bool IsEnabled(LogLevel logLevel) => true;

        public async void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            var message = formatter(state, exception);

            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            var logEntry = new LogEntry
            {
                LogLevel = logLevel,
                Message = message,
                CreatedTime = DateTime.UtcNow
            };

            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<Maindbcontext>();
                    context.LogEntriesww.Add(logEntry);
                   await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Log the exception details to the console or another logging mechanism
                Console.WriteLine($"An error occurred while saving the log entry: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
                }
            }
        }

    }
}
