using _247Pro.API.Infrastructor.Helper;
using _247Pro.Common.WorkContext;
using _247Pro.Model.Context;
using _247Pro.Service.Repository.AccountRolePermission;
using _247Pro.Service.Repository.Estimate;
using _247Pro.Service.Repository.RoleGroup;
using _247Pro.Service.Repository.RoleGroupPermissionDetail;
using _247Pro.Service.Repository.RolePermission;
using _247Pro.Service.Repository.UserAccount;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Text;

namespace _247Pro.API
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                              .SetBasePath(env.ContentRootPath)
                              .AddJsonFile("appsettings.json", reloadOnChange: true, optional: true)
                              .AddJsonFile($"appsettings.{env.EnvironmentName}.json", reloadOnChange: true, optional: true)
                              .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConfiguration>(Configuration);

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });

            services.AddDbContext<DataContext>(options =>
            {
                options.UseNpgsql(Configuration["ConnectionStrings:Conn"]);
            });

            services.AddTransient<IWorkContext, ApiWorkContext>();
            services.AddHttpContextAccessor();
            services.AddTransient<IUserAccountRepository, UserAccountRepository>();
            services.AddTransient<IEstimateRepository, EstimateRepository>();
            services.AddTransient<IRoleGroupRepository, RoleGroupRepository>();
            services.AddTransient<IRolePermissionRepository, RolePermissionRepository>();
            services.AddTransient<IRoleGroupPermissionDetailRepository, RoleGroupPermissionDetailRepository>();
            services.AddTransient<AccountRolePermissionRepository, AccountRolePermissionRepository>();

            //AutoMapper
            services.AddAutoMapper(typeof(Startup));

            //JWT Auth
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    //Microsoft.IdentityModel.Tokens.
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = Configuration["Tokens:Issuer"],
                        ValidAudience = Configuration["Tokens:Audience"],
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"]))
                    };
                });

            //Swagger
            //Swashbuckle.AspNetCore.Swagger
            //Swashbuckle.AspNetCore.SwaggerGen
            //Swashbuckle.AspNetCore.SwaggerUI
            services.AddSwaggerGen(c =>
            {
                //using Microsoft.OpenApi.Models
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Swagger on ASP.Net Core",
                    Version = "1.0.0.",
                    Description = "247Pro Backend Servis Project(ASP.NET Core 3.1)",
                    TermsOfService = new System.Uri("http://swagger.io/terms")
                });

                c.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        Description = "247Pro Core API Project using JWT Authorization header (Bearer) Example: \"Authorization: Bearer {token} \"",
                        Type = SecuritySchemeType.Http,
                        Scheme = "bearer"
                    });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        }, new List<string>()
                    }
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("../swagger/v1/swagger.json", "MY API V1");
                    c.RoutePrefix = "swagger";
                });
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
               endpoints.MapControllers();
            });
        }
    }
}
