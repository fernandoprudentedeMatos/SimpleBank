using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SimpleBank.API.Filters;
using SimpleBank.API.Infrastructure;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace SimpleBank.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var secretkey = this.Configuration["tokenSecretKey"];
            var connectionString = this.Configuration["connectionStrings:simpleBank"];

            services.AddDbContext<BankDbContext>(o => o.UseSqlServer(connectionString));
            services.RegisterServices();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "indra.com.br",
                        ValidAudience = "indra.com.br",
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(secretkey))
                    };
                });

            services.AddMvc(config => {
                config.Filters.Add(new ApiExceptionFilterAttribute());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, BankDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            context.EnsureSeedDataForContext();

            app.UseAuthentication();

            app.UseMvc(config => {
                config.MapRoute(
                    name: "Default",
                    template: "",
                    defaults: new {Controller= "Home", action= "Index"}
                    );
            });
        }
    }
}
