using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using Demo.DataAccess.src;
using Demo.Web.AutoFac;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Demo.Web.Startup))]

namespace Demo.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            WebApiConfig.Register(config);
            
            //AutofacUtil.ConfigureContainer();

            SetBuilder(app, config);

        }

        private void SetBuilder(IAppBuilder app, HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetCallingAssembly());  //注册所有api控制器  构造函数注入  需要引用package Autofac.WebApi

            //注册程序集 Service
            var assemblysServices = Assembly.Load("Demo.Services");
            builder.RegisterAssemblyTypes(assemblysServices)
            .AsImplementedInterfaces()
            .InstancePerDependency();

            //注册程序集 Repository
            var assemblysRepository = Assembly.Load("Demo.Repository");
            builder.RegisterAssemblyTypes(assemblysRepository)
            .AsImplementedInterfaces()
            .InstancePerDependency();


            var container = builder.Build();

            var apiResolver = new AutofacWebApiDependencyResolver(container);
            config.DependencyResolver = apiResolver;

            GlobalConfiguration.Configuration.DependencyResolver = apiResolver;

            app.UseAutofacMiddleware(container);// 注册autofac组件，需要依赖注入功能的组件在此后注册
            app.UseAutofacWebApi(config);//注册AutofacWebApi组件后再注册WebApi组件
            app.UseWebApi(config);
        }

        public void RegisterWebTypes(ContainerBuilder builder)
        {
            builder.Register(c => new HttpContextWrapper(HttpContext.Current))
                .As<HttpContextBase>()
                .InstancePerRequest();

            // HttpContext properties
            builder.Register(c => c.Resolve<HttpContextBase>().Request)
                .As<HttpRequestBase>()
                .InstancePerRequest();

            builder.Register(c => c.Resolve<HttpContextBase>().Response)
                .As<HttpResponseBase>()
                .InstancePerRequest();

            builder.Register(c => c.Resolve<HttpContextBase>().Server)
                .As<HttpServerUtilityBase>()
                .InstancePerRequest();

            builder.Register(c => c.Resolve<HttpContextBase>().Session)
                .As<HttpSessionStateBase>()
                .InstancePerRequest();

            builder.Register(c => c.Resolve<HttpContextBase>().Application)
                .As<HttpApplicationStateBase>()
                .InstancePerRequest();

            // HttpRequest properties
            builder.Register(c => c.Resolve<HttpRequestBase>().Browser)
                .As<HttpBrowserCapabilitiesBase>()
                .InstancePerRequest();

            builder.Register(c => c.Resolve<HttpRequestBase>().Files)
                .As<HttpFileCollectionBase>()
                .InstancePerRequest();

            builder.Register(c => c.Resolve<HttpRequestBase>().RequestContext)
                .As<RequestContext>()
                .InstancePerRequest();

            // HttpResponse properties
            builder.Register(c => c.Resolve<HttpResponseBase>().Cache)
                .As<HttpCachePolicyBase>()
                .InstancePerRequest();

            // HostingEnvironment properties
            builder.Register(c => HostingEnvironment.VirtualPathProvider)
                .As<VirtualPathProvider>()
                .InstancePerRequest();

            // MVC types
            //builder.Register(c => new UrlHelper(c.Resolve<RequestContext>()))
            //    .As<UrlHelper>()
            //    .InstancePerRequest();
        }

    }
}
