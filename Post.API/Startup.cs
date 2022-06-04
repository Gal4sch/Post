using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Post.Core.Repositories;
using Post.Infrastructure.Mappers;
using Post.Infrastructure.Repositories;
using Post.Infrastructure.Services;
using Post.Infrastructure.Settings;

namespace Post.API
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
            services.Configure<JwtSettings>(Configuration.GetSection("jwt"));
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
                (Configuration.GetSection("jwt:SecretKey").Value));

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = Configuration.GetSection("jwt:Issuer").Value,
                ValidateAudience = false,
                IssuerSigningKey = signingKey
            };

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.ClaimsIssuer = Configuration.GetSection("jwt:Issuer").Value;
                options.TokenValidationParameters = tokenValidationParameters;
                options.SaveToken = true;
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Post.API", Version = "v1" });
            });
            services.AddScoped<ICourierOrderRepository, CourierOrderRepository>();
            services.AddScoped<IShipmentsRepository, ShipmentsRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IShipmentsService, ShipmentsService>();
            services.AddScoped<ICourierOrderService, CourierOrderService>();
            services.AddScoped<IUserService, UserService>();
            services.AddSingleton(AutoMapperConfig.Initialize());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Post.API v1"));
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
