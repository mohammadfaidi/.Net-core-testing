using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.models;
using WebApplication1.Repo;
using AutoMapper;
using WebApplication1.Configration;
using Microsoft.AspNetCore.Http;
using WebApplication1.MiddleWare;

namespace WebApplication1
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
            /*
            services.AddControllers();


            services.AddSwaggerGen();
            //object singltion  durning all one object post / delete / put -> one object all times  will work 
          services.AddScoped<IUserServ, UserServ>();
            
            //one object each client will delete now work , l2nh ..... 
            // services.AddScoped<IUser, UserServices>();
            //  services.AddTransient<IUser, UserServices>();
            // services.AddAutoMapper(typeof(Startup));
            */
            /*
            services.AddDbContext<AppDBContext>(options =>
    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //   services.AddAutoMapper(typeof(MappingProfile));
            */
            Services.Addservices(services);
            Services.AddDbContext(services, Configuration);
           // services.AddAutoMapper(typeof(Startup));

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

            app.UseAuthorization();
            //handling exception build in 
            //app.ConfigureBuildInExceptionHandler();

            //handling exception with custom middelware
            app.ConfigureCustomExceptionHandler();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            }); 
            /*
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello from the middleware component.");
            });
            */
            //Excetoion Handling
            
            //app.UseMiddleware(typeof(ExceptionHandlingMiddleware));
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
