using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dm734.Core;
using ManyConsole;

namespace Asv.GoPro.Shell
{
    class Program
    {
        static int Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            typeof(Program).Assembly.PrintWelcomeToConsole();

            try
            {
                var commands = ConsoleCommandDispatcher.FindCommandsInAssembly(Assembly.GetExecutingAssembly());
                Console.WriteLine(commands.ToArray().Length);
                return ConsoleCommandDispatcher.DispatchCommand(commands, args, Console.Out);
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Unhandled exception: {0}", ex);
                return -1;
            }

        }
    }
}
