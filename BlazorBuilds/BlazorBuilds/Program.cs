using BlazorBuilds.Components;
using BlazorBuilds.GrpcServices;
using ProtoBuf.Grpc.Server;

namespace BlazorBuilds
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveWebAssemblyComponents();

            builder.Services.AddCodeFirstGrpc(config =>
            {
                config.ResponseCompressionLevel = System.IO.Compression.CompressionLevel.Optimal;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();


            /*
                * IMPORTANT for web clients such as blazor. From Grpc.AspNetCore.Web nuget package 
                *  
                * gRPC-Web is a protocol that allows gRPC services to be consumed by web browsers, which don’t support the HTTP/2 protocol 
                * that standard gRPC requires. gRPC-Web acts as a compatibility layer that allows gRPC services to work over HTTP/1.1. 
                * 
                * If using app.routing and app.endpoints, app.UseGrpcWeb is placed between them.
                * 
             */
            app.UseGrpcWeb(new GrpcWebOptions() { DefaultEnabled = true });
            
            app.MapGrpcService<GrpcCustomerService>();



            app.MapRazorComponents<App>()
                .AddInteractiveWebAssemblyRenderMode()
                .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);
           
            
            app.Run();
        }
    }
}
