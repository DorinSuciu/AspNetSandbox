using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandLine;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AspNetSandbox
{
    public class Program
    {
        public class Options
        {
            [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
            public bool Verbose { get; set; }

            [Option('c', "connection", Required = false, HelpText = "Choose connection string --c [connectionStringValue].")]
            public bool ConnectionString { get; set; }

            [Value(0, MetaName = "connectionValue", Required = false, HelpText = "Place value for the connection string.")]
            public string ConnectionStringValue { get; set; }
        }

        public static int Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                  .WithParsed<Options>(o =>
                  {
                      if (o.Verbose)
                      {
                          Console.WriteLine($"Verbose output enabled. Current Arguments: -v {o.Verbose}");
                          Console.WriteLine("Quick Start Example! App is in Verbose mode!");
                      }
                      else
                      {
                          Console.WriteLine($"Current Arguments: -v {o.Verbose}");
                          Console.WriteLine("Quick Start Example!");
                      }

                      if (o.ConnectionString && o.ConnectionStringValue == null)
                      {
                          Console.WriteLine("Insert value for connection string!");
                      }
                  });
            if (args.Length > 0)
            {
                Console.WriteLine($"There are {args.Length} arguments!");
            }
            else
            {
                Console.WriteLine("There are no arguments!");
            }

            CreateHostBuilder(args).Build().Run();
            return 0;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
