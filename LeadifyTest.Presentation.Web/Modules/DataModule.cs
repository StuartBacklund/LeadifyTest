using System.Data.Entity;
using System.Linq;
using System.Reflection;
using Autofac;
using LeadifyTest.Data;

namespace LeadifyTest.Modules
{
    public class DataModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("LeadifyTest.Data"))
                                            .Where(t => t.Name.EndsWith("Repository"))
                                            .AsImplementedInterfaces()
                                            .InstancePerLifetimeScope();
            builder.RegisterType(typeof(LeadifyTestDbContext)).As(typeof(DbContext)).InstancePerLifetimeScope();
        }
    }
}