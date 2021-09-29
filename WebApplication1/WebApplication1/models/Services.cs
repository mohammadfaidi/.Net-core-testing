using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Repo;

namespace WebApplication1.models
{
    public static class Services
    {
        public static void Addservices(this IServiceCollection service)
        {
            service.AddControllers();
            service.AddSwaggerGen();
            //object singltion  durning all one object post / delete / put -> one object all times  will work 
            service.AddScoped<IUserServ, UserServ>();
            service.AddScoped<IPostServ, PostServ>();
            service.AddAutoMapper(typeof(Startup));


            //one object each client will delete now work , l2nh ..... 
            // services.AddScoped<IUser, UserServices>();
            //  services.AddTransient<IUser, UserServices>();
            // services.AddAutoMapper(typeof(Startup));
        }
        public static void AddDbContext(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<AppDBContext>(optionsAction: options => options.UseSqlServer(configuration.GetConnectionString(name: "DefaultConnection")));
        }
    }
}
