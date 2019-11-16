using Application.Visits.Commands;
using Autofac;
using Domain.Core.Command;
using Domain.Core.Events;
using Domain.Core.Query;
using MediatR;
using System.Reflection;
using Module = Autofac.Module;


namespace Bootstrap
{
    public class AppModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CommandBus>().As<ICommandBus>();
            builder.RegisterType<QueryBus>().As<IQueryBus>();
            builder.RegisterType<EventBus>().As<IEventBus>();

            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly);

            builder.RegisterAssemblyTypes(typeof(AddNewVisitCommandHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));
        }
    }
}
