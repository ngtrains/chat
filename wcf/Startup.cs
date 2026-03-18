using CoreWCF;
using CoreWCF.Channels;
using CoreWCF.Configuration;
using CoreWCF.Description;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace chat_wcf
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddServiceModelServices();
            services.AddServiceModelMetadata();
            services.AddSingleton<IServiceBehavior, UseRequestHeadersForMetadataAddressBehavior>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
	    var wsHttpBindingWithCredential = new WSHttpBinding(SecurityMode.TransportWithMessageCredential);
            wsHttpBindingWithCredential.Security.Message.ClientCredentialType = MessageCredentialType.UserName;
	    
            app.UseServiceModel(serviceBuilder =>
            {
                serviceBuilder.AddService<Service>(serviceOptions =>
                {
                    // Set a base address for all bindings to the service, and WSDL discovery
                    serviceOptions.BaseAddresses.Add(new Uri($"http://localhost:{Program.HTTP_PORT}/Service"));
                    serviceOptions.BaseAddresses.Add(new Uri($"https://localhost:{Program.HTTPS_PORT}/Service"));
                })
		// Add WSHttpBinding endpoints
                .AddServiceEndpoint<Service, IService>(new WSHttpBinding(SecurityMode.None), "/wsHttp")
                .AddServiceEndpoint<Service, IService>(new WSHttpBinding(SecurityMode.Transport), "/wsHttp")
                .AddServiceEndpoint<Service, IService>(wsHttpBindingWithCredential, "/wsHttpUserPassword", ep => { ep.Name = "AuthenticatedEP"; });
            });
        }
    }
}
