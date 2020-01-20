using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Valkyrie.Sample.Web2
{
    public class Program
    {
        public static void Main(string[] args)
        {
           
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
        //.UseSerilog();

        //webBuilder.UseValkyrie<Startup>();
        //webBuilder.UseRabbitMq();
        //webBuilder.UseStartup<Startup>();
        //webBuilder.UseSerilog();
    }
}
