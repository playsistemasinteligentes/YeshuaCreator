using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

// Shered.Logger — Logger.cs
namespace Shered.Logger
{
    public class Logger : ILogger
    {
        public void Info(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"[INFO] {DateTimeOffset.UtcNow:HH:mm:ss.fff} {message}");
            Console.ResetColor();
        }

        public void Command(string commandName, string traceId, string fase, long? durationMs = null)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            var duration = durationMs.HasValue ? $" ({durationMs}ms)" : string.Empty;
            Console.WriteLine($"[COMMAND] {DateTimeOffset.UtcNow:HH:mm:ss.fff} [{fase.ToUpper()}] {commandName} | trace: {traceId}{duration}");
            Console.ResetColor();
        }

        public void Error(string commandName, string traceId, Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERROR] {DateTimeOffset.UtcNow:HH:mm:ss.fff} {commandName} | trace: {traceId}");
            Console.WriteLine($"  {ex.GetType().Name}: {ex.Message}");
            Console.WriteLine($"  {ex.StackTrace}");
            Console.ResetColor();
        }
    }
}