using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Api
{
    /// <summary>
    /// 将身份验证服务(IdentityServer4.AccessTokenValidation)添加到DI和身份验证中间件到管道。这些将：
    /// 1.验证传入令牌以确保它来自受信任的颁发者
    /// 2.验证令牌是否有效用于此api（aka范围）
    /// </summary>
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddAuthentication("Bearer")                    //将身份验证服务添加到DI并配置"Bearer"为默认方案。
                .AddIdentityServerAuthentication(options =>         //将IdentityServer访问令牌验证处理程序添加到DI中以供身份验证服务使用。Assembly => IdentityServer4.AccessTokenValidation
                {
                    options.Authority = "http://localhost:5000";
                    options.RequireHttpsMetadata = false;
                    options.ApiName = "api1";
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();//将身份验证中间件添加到管道中，以便在每次调用主机时自动执行身份验证。

            app.UseMvc();
        }
    }
}
