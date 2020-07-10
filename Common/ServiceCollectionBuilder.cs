using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public static class ServiceCollectionBuilder
    {
        /// <summary>
        /// 注入调用
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IApplicationBuilder Configure(this IApplicationBuilder app, IHostApplicationLifetime lifetime)
        {
            //app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            RegisterSwagger(app);
            return app;
        }

        /// <summary>
        /// swagger中间件注册
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder RegisterSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "测试注入");
                //c.RoutePrefix = string.Empty; 设置这个将不显示swaggerui
                c.RoutePrefix = "swagger";
            });

            return app;
        }

        /// <summary>
        /// consul中间件注册
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder RegisterConsul(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
