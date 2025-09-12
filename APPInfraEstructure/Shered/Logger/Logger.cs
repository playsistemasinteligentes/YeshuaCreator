using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Shered.Logger
{
    public class Logger : ILogger
    {
        public void Info(string message)
        {
            Console.WriteLine(message);
        }
        public void DebugSql(string sql, object parameters)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("---- SQL DEBUG ----");
            Console.WriteLine(sql);

            if (parameters != null)
            {
                var dict = parameters as IDictionary<string, object>
                           ?? parameters.GetType()
                                        .GetProperties()
                                        .ToDictionary(p => p.Name, p => p.GetValue(parameters));

                foreach (var kvp in dict)
                {
                    string valueStr = kvp.Value switch
                    {
                        string s => $"'{s}'",
                        DateTime dt => $"'{dt:yyyy-MM-dd HH:mm:ss}'",
                        null => "NULL",
                        bool b => b ? "1" : "0",
                        _ => kvp.Value.ToString()
                    };
                    Console.WriteLine($"  @{kvp.Key} = {valueStr}");
                }
            }

            Console.WriteLine("-------------------");
            Console.ResetColor();
        }
    }
}
