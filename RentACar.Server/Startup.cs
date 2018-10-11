using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Blazor.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RentACar.Server.DataAccess;
using RentACar.Server.Services;
using System.Linq;
using System.Net.Mime;
using System.Text;

namespace RentACar.Server
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<RentACarContext>();

            services.AddMvc();

            services.AddDbContext<RentACarContext>();

            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<RentACarContext>();

            services.AddResponseCompression(options =>
                    {
                        options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
                        {
                            MediaTypeNames.Application.Octet,
                            WasmMediaTypeNames.Application.Wasm,
                        });
                    });

            services.AddTransient<IJwtTokenService, JwtTokenService>();

            services.AddAuthentication(options => 
                    {
                        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    })
                    .AddJwtBearer(options => 
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        { 
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = Configuration["Jwt:Issuer"],
                            ValidAudience = Configuration["Jwt:Audience"],
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                        };
                    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<RentACarContext>();
                context.Database.EnsureCreated();
            }
            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseMvc(routes =>
                    {
                        routes.MapRoute(name: "default", template: "{controller}/{action}/{id?}");
                    });

            app.UseBlazor<Client.Program>();
        }
    }
}
