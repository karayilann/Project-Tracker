using Autofac;
using ProjectTracker.Core.Interfaces.Repositories;
using ProjectTracker.Core.Interfaces.UnitOfWork;
using ProjectTracker.Repository.Repositories;
using ProjectTracker.Repository.UnitOfWork;

namespace ProjectTracker.API.DependencyResolvers
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
        }
    }
}
