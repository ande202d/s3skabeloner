using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

namespace Rest
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
            services.AddDbContext<StudentContext>(opt =>
                opt.UseInMemoryDatabase("Students"));
            services.AddControllers();

            // MiddleWare with policy
            //services.AddCors(options =>
            //{
            //    //HERE YOU DEFINE IT --------------------------------------------------------------------------------------
            //    options.AddPolicy("AllowAnyOrigin", builder => builder.AllowAnyOrigin()); //THIS ALLOWS EVERYTHING (POST,GET,GETALL ETC.) ---------------------------------
            //    options.AddPolicy("AllowMyLocalOrigin", builder => builder.WithOrigins("http://localhost:3000"));
            //    options.AddPolicy("AllowGetPost", builder => builder.AllowAnyOrigin().WithMethods("GET", "POST"));
            //});

            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            //services.AddMvc(option => option.EnableEndpointRouting = false);
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.UseCors("AllowAnyOrigin");
            //app.UseCors("AllowMyLocalOrigin");
            //app.UseCors("AllowGetPost");

            //app.UseMvc();
        }
    }
}
