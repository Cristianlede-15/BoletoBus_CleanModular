using BoletoBus_CleanModular.Infraestructure.Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletoBus_CleanModular.Infraestructure.Logger.Services
{
    public class LoggerService<TService> : ILoggerService
    {
        public void LogInformation(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Info: {message}");
            Console.ResetColor(); 
        }
        public void LogError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red; 
            Console.WriteLine($"Error: {message}");
            Console.ResetColor(); 
        }


    }
}
