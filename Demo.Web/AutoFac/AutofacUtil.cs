using Autofac;
using Autofac.Integration.WebApi;
using Demo.Repository.src.Interfaces;
using Demo.Repository.src.Services;
using Demo.Services.src.Interfaces;
using Demo.Services.src.Services;
using Demo.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace Demo.Web.AutoFac
{
    public class AutofacUtil
    {
        private static IContainer _container;

        public static void ConfigureContainer()
        {
            #region AutoFac IOC容器

            var builder = new ContainerBuilder();

            try
            {
                //builder.RegisterControllers(Assembly.GetCallingAssembly());  //注册mvc控制器  需要引用package Autofac.Mvc

                //builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();  //支持Api控制器属性注入
                builder.RegisterApiControllers(Assembly.GetCallingAssembly());  //注册所有api控制器  构造函数注入  需要引用package Autofac.WebApi

                //注册程序集
                #region Service
                var assemblysServices = Assembly.Load("Demo.Services");
                builder.RegisterAssemblyTypes(assemblysServices)
                .AsImplementedInterfaces()
                .InstancePerDependency();
                #endregion

                #region Repository
                var assemblysRepository = Assembly.Load("Demo.Repository");
                builder.RegisterAssemblyTypes(assemblysRepository)
                .AsImplementedInterfaces()
                .InstancePerDependency();
                #endregion

                _container = builder.Build();   //创建依赖注入


                //设置MVC依赖注入
                //DependencyResolver.SetResolver(new AutofacDependencyResolver(_container));

                //设置WebApi依赖注入
                GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(_container);
                System.Diagnostics.Debug.WriteLine("设置WebApi依赖注入");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "\n" + ex.InnerException);
            }
            #endregion
        }

        /// <summary>
        /// 从Autofac容器获取对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetFromFac<T>()
        {
            return _container.Resolve<T>();
        }

    }
}