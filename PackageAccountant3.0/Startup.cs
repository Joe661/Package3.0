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
            #region ���� ����������Դ 
            services.AddCors(options =>
            {
                options.AddPolicy("cors", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
            #endregion

            #region ���� ָ����Դ
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("cors", policy =>
            //    {
            //        //1.���������Դ�����������Դʹ��','�ָ�
            //        //2.���������Դʹ��string����
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
            //�������п���cors����ConfigureServices���������õĿ����������
            //ע�⣺UseCors�������UseRouting��UseEndpoints֮��
            app.UseCors("cors");
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //���������RequireCors������cors����ConfigureServices���������õĿ����������
                //endpoints.MapControllers().RequireCors("cors");
            });
        }
    }
}
