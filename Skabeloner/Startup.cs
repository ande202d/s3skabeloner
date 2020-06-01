using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Items API", Version = "v1.0" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Items API v1.0"));
            app.UseSwaggerUI(c => c.RoutePrefix = "api/help");

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
