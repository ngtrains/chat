using System;
using System.Threading.Tasks;
using CoreWCF;
using CoreWCF.Configuration;
using CoreWCF.Description;
using CoreWCF.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;


namespace chat_wcf
{
    public class Program
    {
	public const int HTTP_PORT = 8088;
        public const int HTTPS_PORT = 8443;
        
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services
                .AddServiceModelServices()
                .AddServiceModelMetadata()
                .AddSingleton<IServiceBehavior, UseRequestHeadersForMetadataAddressBehavior>();

            var app = builder.Build();

            app.UseServiceModel(serviceBuilder =>
            {
                serviceBuilder
                    .AddService<EchoService>()
                    .AddServiceEndpoint<EchoService, IEchoService>(new BasicHttpBinding(), "/EchoService.svc");

                    var serviceMetadataBehavior = app.Services.GetRequiredService<ServiceMetadataBehavior>();
                    serviceMetadataBehavior.HttpGetEnabled = true;
            });

            app.MapGet("/", () => "Hello! Please post a SOAP message to me!");

            app.Run();
       }

    }
}
