using BlazorBuilds.Client.Services;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BlazorBuilds.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            var path = builder.HostEnvironment.BaseAddress;

            builder.Services.AddScoped<GrpcChannel>(services =>
            {
                var channel = GrpcChannel.ForAddress(path, new GrpcChannelOptions
                {
                    HttpHandler = new GrpcWebHandler(GrpcWebMode.GrpcWeb, new HttpClientHandler())

                });
                return channel;
            });

            builder.Services.AddTransient<CustomerService>();

            await builder.Build().RunAsync();
        }
    }
}
