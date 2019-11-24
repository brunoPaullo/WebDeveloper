using Cibertec.Repositories.Dapper.NorthWind;
using Cibertec.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Reflection;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Web.Mvc;
using log4net;
using log4net.Core;

namespace Cibertec.Mvc.App_Start
{
    public class DIConfig
    {
        public static void ConfigureInjector()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            container.Register<IUnitOfWork>(() => new NorthWindUnitOfWork(
                ConfigurationManager.ConnectionStrings["NorthwindConnection"].ToString()));

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            //Log4net
            container.RegisterConditional(typeof(ILog),
                c => typeof(Log4NetAdapter<>).MakeGenericType(c.Consumer.ImplementationType),
                Lifestyle.Singleton, c => true);

            container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

        }
    }

    public sealed class Log4NetAdapter<T>:LogImpl
    {
        public Log4NetAdapter():base(LogManager.GetLogger(typeof(T)).Logger){}
    }
}