using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using eBlocks.Core;
using eBlocks.Core.Interfaces;
using eBlocks.Assessment.WebAPI.Extensions;
using Microsoft.OpenApi.Models;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Logging;

namespace eBlocks.Assessment.WebAPI
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
           

            services.Configure<DatabaseSettings>
               (options => Configuration.GetSection("DatabaseSettings").Bind(options));
           

           services.AddSingleton<IDatabaseSettings>(sp =>
            sp.GetRequiredService<IOptions<DatabaseSettings>>().Value
           );

            // Authentication Setup 
            services.AddSingleton<IAuthorizationHandler, EblocksAuthHandler>();

           services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
               // South African Schema and Audience
               .AddJwtBearer("SchemeZA", options =>
               {
                   options.Audience = "SecuredZaApiResource";
                  
                   options.Authority = "https://localhost:44345";
               })
               // Reset of the world Screen and Audience
               .AddJwtBearer("SchemeRow", options =>
               {
                   options.Audience = "SecuredRowApiResource";
                   options.Authority = "https://localhost:44336";
               });

           services.AddAuthorization(options =>
           {
               options.DefaultPolicy = new AuthorizationPolicyBuilder()
                   .RequireAuthenticatedUser()
                   .AddAuthenticationSchemes("SchemeZA", "SchemeRow")
                   .Build();

               options.AddPolicy("EblocksPolicy", policy =>
               {
                   policy.AddRequirements(new EblocksApiRequirement());
               });
           });

           services.AddControllers();

           // Register Repository Services
           services.AddRepoServices();

            //swagger setup 

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            Path.Combine(AppContext.BaseDirectory, xmlFile);

            services.AddSwaggerGen(c =>
            {
                var securityScheme = new OpenApiSecurityScheme
                    {
                        Name = "JWT Authentication",
                        Description = "Enter JWT Bearer token **_only_**",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.Http,
                        Scheme = "bearer",
                        BearerFormat = "JWT",
                        Reference = new OpenApiReference
                        {
                            Id = JwtBearerDefaults.AuthenticationScheme,
                            Type = ReferenceType.SecurityScheme
                        }
                    };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securityScheme, new string[] { }}
                });

                c.SwaggerDoc(name: "v1", new OpenApiInfo
                {
                    Title = "E-Blocks Assessment ",
                    Description = "E-Blocks Assessment Service API -  Provides Mongodb services .",
                    Version = "v1",
                });
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            IdentityModelEventSource.ShowPII = true;
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                
                c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "E-blocks Assessment API v1");
                //c.RoutePrefix = string.Empty;
            });   
            app.UseHttpsRedirection();
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
