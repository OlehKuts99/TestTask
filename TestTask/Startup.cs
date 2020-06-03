using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TestTask.BLL.DTO;
using TestTask.BLL.Helpers.Mappers.Classes;
using TestTask.BLL.Helpers.Mappers.Interfaces;
using TestTask.BLL.Services.Classes;
using TestTask.BLL.Services.Interfaces;
using TestTask.DAL.Context;
using TestTask.DAL.Models;
using TestTask.DAL.UnitOfWork.Classes;
using TestTask.DAL.UnitOfWork.Interfaces;

namespace TestTask
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
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            services.AddScoped(typeof(IObjectMapper<Book, BookDTO>), typeof(BookMapper<Book, BookDTO>));
            services.AddScoped(typeof(IObjectMapper<Author, AuthorDTO>), typeof(AuthorMapper<Author, AuthorDTO>));

            services.AddScoped(typeof(IEntityService<BookDTO>), typeof(BookService<BookDTO>));
            services.AddScoped(typeof(IEntityService<AuthorDTO>), typeof(AuthorService<AuthorDTO>));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite("Filename=TestDatabase.db"));

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext context)
        {
            if (env.IsDevelopment())
            {
                context.Database.EnsureCreated();
                app.UseDeveloperExceptionPage();
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
