using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather_Station.Api.Authenticate;
using Weather_Station.Api.AutoMapper;
using Weather_Station.Application;
using Weather_Station.Application.Interface;
using Weather_Station.Domain.Interfaces.Interfaces;
using Weather_Station.Domain.Interfaces.Services;
using Weather_Station.Domain.Services;
using Weather_Station.Infra.Context;
using Weather_Station.Infra.Repositories;

namespace Weater_Station.Api
{
    public class Startup
    {
        private Container container = new Container();
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var tokenConfiguration = new TokenConfiguration();
            new ConfigureFromConfigurationOptions<TokenConfiguration>(Configuration.GetSection("TokenConfiguration")).Configure(tokenConfiguration);
            services.AddSingleton(tokenConfiguration);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                var parametros = x.TokenValidationParameters;
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfiguration.Key));
                parametros.IssuerSigningKey = securityKey;
                parametros.ValidAudience = tokenConfiguration.Audience;
                parametros.ValidIssuer = tokenConfiguration.Issuer;
                parametros.ValidateLifetime = true;
                parametros.ClockSkew = TimeSpan.Zero;2
            });


            services.AddAutoMapper(typeof(ModelToDomain));
            services.AddAutoMapper(typeof(DomainToModel));


            services.AddDbContext<ContextDb>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Weater_Station.Api", Version = "v1" });
            });

           
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Weater_Station.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void InitializeContainer(IServiceCollection services)
        {
            services.AddScoped(typeof(IAppServiceBase<>), typeof(AppServiceBase<>));
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        }
    }
}
