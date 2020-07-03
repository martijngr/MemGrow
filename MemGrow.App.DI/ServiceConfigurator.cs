using Common.Cqs;
using MemGrow.App.Domain.Seeding;
using MemGrow.App.Domain.Seeding.AddSeed;
using MemGrow.App.Domain.Seeding.AddSeedCategories;
using MemGrow.App.Domain.Seeding.DeleteSeed;
using MemGrow.App.Domain.Seeding.EditSeed;
using MemGrow.App.Domain.Seeding.GetSeedById;
using MemGrow.App.Domain.Seeding.GetSeedCategories;
using MemGrow.App.Domain.Seeding.GetSeeds;
using MemGrow.App.Infrastructure;
using MemGrow.App.Infrastructure.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MemGrow.App.DI
{
    public static class ServiceConfigurator
    {
        public static void RegisterServices(IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
            serviceCollection.AddTransient<AppDbReadContext>();

            serviceCollection.AddTransient<ITypeResolver, EfCoreTypeResolver>();
            serviceCollection.AddTransient<CommandProcessor>();
            serviceCollection.AddTransient<QueryProcessor>();
            serviceCollection.AddCommandQueryHandlers(typeof(ICommandHandler<>));
            serviceCollection.AddCommandQueryHandlers(typeof(IQueryHandler<,>));

            serviceCollection.AddTransient<ISeedCategorySaver, EfSeedCategorySaver>();
            serviceCollection.AddTransient<ISeedSaver, EfSeedSaver>();
            serviceCollection.AddTransient<IGetSeedCategories, EfGetSeedCategories>();
            serviceCollection.AddTransient<IRetreiveAllSeeds, EFRetreiveAllSeeds>();
            serviceCollection.AddTransient<IDeleteSeed, EfDeleteSeed>();
            serviceCollection.AddTransient<IGetSeedById, EfGetSeedById>();
            serviceCollection.AddTransient<IEditSeed, EfEditSeed>();
        }

        private static void AddCommandQueryHandlers(this IServiceCollection services, Type handlerInterface)
        {
            var handlers = typeof(Seed).Assembly.GetTypes()
                .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == handlerInterface)
            );

            foreach (var handler in handlers)
            {
                services.AddScoped(handler.GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == handlerInterface), handler);
            }
        }
    }
}
