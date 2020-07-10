using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.OpenApi.Models;

namespace Common
{
    public static class ServiceCollectionRegister
    {
        /// <summary>
        /// 注入调用
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection Configure(this IServiceCollection services)
        {
            //MvcServiceCollectionExtensions.AddControllers(services);
            services.AddControllers();
            BatchInjection(services);
            SwaggerInjection(services);
            return services;
        }

        /// <summary>
        /// 批量注入
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection BatchInjection(this IServiceCollection services)
        {
            var serviceAssembly = Utls.GetSectionValue("ServiceAssembly");
            Assembly assembly = Assembly.Load(serviceAssembly);
            //获取程序集下所有类
            Type[] types = assembly.GetTypes();

            types.ToList().ForEach(t =>
            {
                //非接口，非抽象类
                if(!t.IsInterface && !t.IsAbstract)
                {
                    Type[] interfaces = t.GetInterfaces();
                    //注入
                    interfaces.ToList().ForEach(r =>
                    {
                        //ServiceCollectionServiceExtensions.AddTransient(services, r, t);
                        services.AddTransient(r, t);
                    });
                }
            });

            return services;
        }

        /// <summary>
        /// 注入swagger
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection SwaggerInjection(this IServiceCollection services)
        {
            //参数可读配置
            services.AddSwaggerGen(t =>
            {
                t.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1", Description = "仅作为实现插件注入功能" });
            });

            return services;
        }
    }
}
