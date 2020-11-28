using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PackageAccountant3._0.Data;
using PackageAccountant3._0.Helper;
using PackageAccountant3._0.Service;

namespace PackageAccountant3._0
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
            #region 跨域 允许所有来源 
            services.AddCors(options =>
            {
                options.AddPolicy("cors", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
            #endregion

            #region 跨域 指定来源
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("cors", policy =>
            //    {
            //        //1.允许跨域来源，多个跨域来源使用','分割
            //        //2.多个跨域来源使用string数组
            //        var strOrgin = Configuration.GetSection("OrginList").GetValue<string>("Url").ToString();
            //        policy.WithOrigins(strOrgin.Split(',')).AllowAnyHeader().AllowAnyMethod();
            //    });
            //});
            #endregion

            services.AddControllers(setup=> {
                setup.ReturnHttpNotAcceptable = true;
                setup.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
            });
            
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //services.AddDbContext<EFPackageDbContext>(option =>
            //{
            //    option.UseSqlite("Data Source=PackageDB.db");
            //});
            var connection = Configuration.GetConnectionString("PackageDatabase");
            services.AddDbContext<EFPackageDbContext>(options => options.UseSqlServer(connection));

            services.AddTransient<IUserInfoBll, UserInfoBll>();
            services.AddTransient<IMenuBll, MenuBll>();
            services.AddTransient<IAccountItermDetailsBll, AccountItermDetailsBll>();
            services.AddTransient<IAccountTypeDetailsBll, AccountTypeDetailsBll>();
            services.AddTransient<IPropertyMappingService, PropertyMappingService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run
                    (async context => {
                        context.Response.StatusCode = 500;
                        //should add log
                        await context.Response.WriteAsync("Unexpected Error!");
                    });
                });
            }
            app.UseRouting();
            //允许所有跨域，cors是在ConfigureServices方法中配置的跨域策略名称
            //注意：UseCors必须放在UseRouting和UseEndpoints之间
            app.UseCors("cors");
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //跨域需添加RequireCors方法，cors是在ConfigureServices方法中配置的跨域策略名称
                //endpoints.MapControllers().RequireCors("cors");
            });
        }
    }
}
