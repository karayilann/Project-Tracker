using Autofac;
using ProjectTracker.Core.Interfaces.Services;
using ProjectTracker.Service.Authorization.Abstract;
using ProjectTracker.Service.Authorization.Concrete;
using ProjectTracker.Service.Services;

namespace ProjectTracker.API.DependencyResolvers
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProjectService>().As<IProjectService>().InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<RoleService>().As<IRoleService>().InstancePerLifetimeScope();
            builder.RegisterType<WorkItemService>().As<IWorkItemService>().InstancePerLifetimeScope();

            builder.RegisterType<JwtAuthentication>().As<IJwtAuthentication>().InstancePerLifetimeScope();
        }
    }
}
