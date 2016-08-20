using System;
using Test.API;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                const string wrongNumber = "m";
                var total = int.Parse(wrongNumber);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Ups! Ocurrió un error en la ejecución del código:");
                Console.WriteLine("Desea guardar el log en un archivo? Y o N, Default(Y) -> ");
                var logToFile = GetBool(Console.ReadLine());
                Console.WriteLine("Desea mostrar el log en consola? Y o N, Default(Y) -> ");
                var logToConsole = GetBool(Console.ReadLine());
                Console.WriteLine("Desea guardar el log en la base de datos? Y o N, Default(Y) -> ");
                var logToDb = GetBool(Console.ReadLine());
                Console.WriteLine("Desea guardar el log como ERROR? Y o N, Default(Y) -> ");
                var isError = GetBool(Console.ReadLine());
                Console.WriteLine("Desea guardar el log como MESSAGE? Y o N, Default(Y) -> ");
                var isMessage = GetBool(Console.ReadLine());
                Console.WriteLine("Desea guardar el log en un WARNING? Y o N, Default(Y) -> ");
                var isWarning = GetBool(Console.ReadLine());
                //JobLoggerApi.MakeLog(exception.Message, logToFile:, logToConsole:, logToDatabase:, logMessage:, logWarning:, logError:);
                //JobLoggerApi.MakeLog(exception.Message, true, true, true, true, true, true);
                JobLoggerApi.MakeLog(exception.Message, logToFile, logToConsole, logToDb, isMessage, isWarning, isError);
            }
            Console.ReadLine();
        }

        private static bool GetBool(string s)
        {
            if (string.IsNullOrEmpty(s))
                return true;
            return s.ToUpper() == "Y";
        }
    }
}
