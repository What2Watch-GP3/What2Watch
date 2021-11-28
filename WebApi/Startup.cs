using Microsoft.AspNetCore.Authentication.JwtBearer;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace WebApi
{
    public class Startup
    {

        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //TODO: compare with transient
            services.AddScoped((dataAccess) => DataAccessFactory.GetDataAccess<IBookingDataAccess>(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped((dataAccess) => DataAccessFactory.GetDataAccess<IMovieDataAccess>(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped((dataAccess) => DataAccessFactory.GetDataAccess<ICinemaDataAccess>(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped((dataAccess) => DataAccessFactory.GetDataAccess<IShowDataAccess>(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped((dataAccess) => DataAccessFactory.GetDataAccess<IUserDataAccess>(Configuration.GetConnectionString("DefaultConnection")));
            //services.AddScoped<IConfiguration>((config) => Configuration);
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
            });
            //JWT Usage
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {

                //options.Authority = Configuration["Jwt:Issuer"];
                options.Audience = Configuration["Jwt:Audience"];
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]));
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    IssuerSigningKey = securityKey
                };
            });
            //services.ConfigureJwtAuthentication();
            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme).RequireAuthenticatedUser().Build();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
            }

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

    public static class TokenBuilder
    {
        private const string keyString = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed";
        public static readonly byte[] symmetricKeyBytes = Encoding.ASCII.GetBytes(keyString);
        public static readonly SymmetricSecurityKey symmetricKey = new SymmetricSecurityKey(symmetricKeyBytes);
        public static readonly SigningCredentials signingCredentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256);
        internal static TokenValidationParameters tokenValidationParams;
        //Construct our JWT authentication paramaters then inject the parameters into the current TokenBuilder instance
        // If injecting an RSA key for signing use this method
        // Be weary of common jwt trips: https://trustfoundry.net/jwt-hacking-101/
        //public static void ConfigureJwtAuthentication(this IServiceCollection services, RSAParameters rsaParams)
        public static void ConfigureJwtAuthentication(this IServiceCollection services)
        {
            tokenValidationParams = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                ValidIssuer = "http://issuer.com",
                ValidateLifetime = true,
                ValidAudience = "http://audience.com",
                ValidateAudience = true,
                RequireSignedTokens = true,
                // Use our signing credentials key here
                // optionally we can inject an RSA key as
                //IssuerSigningKey = new RsaSecurityKey(rsaParams),
                IssuerSigningKey = signingCredentials.Key,
                ClockSkew = TimeSpan.FromMinutes(0)
            };
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = tokenValidationParams;
#if PROD || UAT
                options.IncludeErrorDetails = false;
#elif DEBUG
                options.RequireHttpsMetadata = false;
#endif
            });
        }
        public static string CreateJsonWebToken(
               string username,
               IEnumerable<string> roles,
               string audienceUri,
               string issuerUri,
               Guid applicationId,
               DateTime expires,
               string deviceId = null,
               bool isReAuthToken = false)
        {
            var claims = new List<Claim>();
            if (roles != null)
            {
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
            }
            var head = new JwtHeader();
            var payload = new JwtPayload(claims.ToArray());
            var jwt = new JwtSecurityToken(issuerUri, audienceUri, claims, DateTime.UtcNow, expires, signingCredentials);
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
