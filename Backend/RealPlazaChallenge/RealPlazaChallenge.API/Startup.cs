using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RealPlazaChallenge.Application.Services.Product;
using RealPlazaChallenge.Application.Services.Security;
using RealPlazaChallenge.Application.Services.User;
using RealPlazaChallenge.Core.Entities;
using RealPlazaChallenge.Core.Interfaces;
using RealPlazaChallenge.Infrastructure.Data;
using RealPlazaChallenge.Infrastructure.Repository;

namespace RealPlazaChallenge.API
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RealPlazaChallenge.API", Version = "v1" });
            });

            services.Configure<PasswordOptions>(options => Configuration.GetSection("PasswordOptions").Bind(options));

            #region Configure database
            services.AddDbContext<ChallengeContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DevConnection"));
            }); 
            #endregion

            #region Add Service Injection
            //necesary fot injection
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<ISecurityService, SecurityService>();
            #endregion

            services.AddCors(options =>
            {
                options.AddPolicy("permit",
                    builder =>
                    {
                        builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RealPlazaChallenge.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("permit");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
