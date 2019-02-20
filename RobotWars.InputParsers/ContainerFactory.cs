using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;

namespace RobotWars.InputParsers
{
    public class ContainerFactory
    {
        public static IWindsorContainer Create()
        {
            var container = new WindsorContainer();
            var collectionResolver = new CollectionResolver(container.Kernel);
            container.Kernel
                     .Resolver
                     .AddSubResolver(collectionResolver);
            container.Register
                (Component.For<IArenaParser>()
                          .ImplementedBy<ArenaParser>(),
                 Component.For<IGridSizeParser>()
                          .ImplementedBy<GridSizeParser>(),
                 Component.For<IPositionParser>()
                          .ImplementedBy<PositionParser>(),
                 Component.For<IRobotParser>()
                          .ImplementedBy<RobotParser>(),
                 Component.For<IRouteParser>()
                          .ImplementedBy<RouteParser>(),
                 Classes.FromAssemblyContaining<IRouteStepResolver>()
                        .BasedOn<IRouteStepResolver>()
                        .WithServiceFirstInterface(),
                 Classes.FromAssemblyContaining<ICardinalCompassPointResolver>()
                        .BasedOn<ICardinalCompassPointResolver>()
                        .WithServiceFirstInterface());

            return container;
        }
    }
}