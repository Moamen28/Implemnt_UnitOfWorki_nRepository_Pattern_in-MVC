using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Lab_Data;
using Lab_Reposterys;

namespace Lab_PL.App_Start
{
    public class IOCconfigration
    {
        public static void IOCconfigure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterGeneric(typeof(ModelRepositery<>)).As(typeof(IModelRepository<>));
            builder.RegisterType<ContextFactory>().As<IContextFactory>().SingleInstance();

            IContainer container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}