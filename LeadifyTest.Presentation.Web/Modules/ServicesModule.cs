using System.Linq;
using System.Reflection;
using Autofac;

namespace LeadifyTest.Modules
{
    public class ServicesModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("LeadifyTest.Services"))
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces()
                  .InstancePerLifetimeScope();
        }
    }
}