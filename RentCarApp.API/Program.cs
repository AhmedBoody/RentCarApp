using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;

namespace RentCarApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                CreateWebHostBuilder(args).Build().Run();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
     WebHost.CreateDefaultBuilder(args)
         .UseStartup<Startup>();
    }
}
