using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CaploittePayroll.BusinessObjects.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace JWT
{
    public class Startup
    {
        public static string EnvironmentName = "Missing";
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
            EnvironmentName = env.EnvironmentName;

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            LoadConfigurations(services);
            services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowOrigin",
                    builder =>
                    {
                        builder.WithOrigins(AppSettings.AllowedOrigin)
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });
            });
            var key = Encoding.ASCII.GetBytes(AppSettings.Secret);
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSettings.Secret)),
                    ValidIssuer = "caploitte",
                    ValidateIssuer = true,
                    ValidAudience = "caploitte-audience",
                    ValidateAudience = true,
                    NameClaimType = JwtRegisteredClaimNames.Sub,
                    RoleClaimType = ClaimTypes.Role,
                };
            });
        }
        private void LoadConfigurations(IServiceCollection services)
        {
            AppSettings.AllowedOrigin = Configuration.GetSection("Appsettings:AllowedOrigin").Value;
            AppSettings.ConnectionString = Configuration.GetSection("ConnectionStrings:CaploitteApps").Value;
            AppSettings.TokenTimout = Configuration.GetSection("Appsettings:TokenTimout").Value;
            AppSettings.Secret = Configuration.GetSection("Appsettings:Secret").Value;

            AppSettings.TcpipServer = Configuration.GetSection("MailServer:TcpipServer").Value;
            AppSettings.TcpipPort = Configuration.GetSection("MailServer:TcpipPort").Value;
            AppSettings.SenderUserName = Configuration.GetSection("MailServer:SenderUserName").Value;
            AppSettings.SenderPassword = Configuration.GetSection("MailServer:SenderPassword").Value;
            AppSettings.MailCC = Configuration.GetSection("MailServer:MailCC").Value;
            AppSettings.FromAddress = Configuration.GetSection("MailServer:FromAddress").Value;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("AllowOrigin");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
