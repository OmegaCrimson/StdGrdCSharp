using System;

namespace Services
{
    public static class LoggerService
    {
        public static void LogError(string context, Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[Error - {context}] {ex.Message}");
            Console.ResetColor();
        }

        public static void LogInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"[Info] {message}");
            Console.ResetColor();
        }

        public static void LogSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[Success] {message}");
            Console.ResetColor();
        }

        public static void LogWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[Warning] {message}");
            Console.ResetColor();
        }
    }
}
