using Blazor.Extensions.Storage;
using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;
using RentACar.Client.Services;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace RentACar.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddStorage();
            services.AddLoadingBar();
            services.AddSingleton<GlobalStateChange>();
        }

        public void Configure(IBlazorApplicationBuilder app)
        {
            app.UseLoadingBar();
            app.AddComponent<App>("app");
        }
    }
}
