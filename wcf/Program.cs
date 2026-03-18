using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace chat_wcf
{
    public class Program
    {
	public const int HTTP_PORT = 8088;
        public const int HTTPS_PORT = 8443;
	
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
	    .UseKestrel(options =>
            {
                options.ListenLocalhost(HTTP_PORT);
                options.ListenLocalhost(HTTPS_PORT, listenOptions =>
                {
                    listenOptions.UseHttps();
                });
            })
            .UseStartup<Startup>();
    }
}
