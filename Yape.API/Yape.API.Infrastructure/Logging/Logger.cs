namespace Yape.API.Infrastructure.Logging
{
    /// <summary>
    /// Provides logging functionality for the application.
    /// Supports logging of informational messages and error details.
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// Logs error details to the console.
        /// </summary>
        /// <param name="ex">The exception to be logged, containing error details.</param>
        public static void LogError(Exception ex)
        {
            Console.WriteLine($"[ERROR] {DateTime.Now}: {ex.Message}");
        }

        /// <summary>
        /// Logs informational messages to the console.
        /// </summary>
        /// <param name="message">The message to be logged, providing application insights or status updates.</param>
        public static void LogInfo(string message)
        {
            Console.WriteLine($"[INFO] {DateTime.Now}: {message}");
        }
    }
}
