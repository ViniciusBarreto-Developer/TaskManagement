using Microsoft.Extensions.DependencyInjection;
using TaskManagement.AplicationService.Services.NotificationService;
using TaskManagement.AplicationService.Services.TarefaService;
using TaskManagement.Domain.Contracts.Queries;
using TaskManagement.Domain.Contracts.Repositories;
using TaskManagement.Repository;
using TaskManagement.Repository.Queries;
using TaskManagement.Repository.Repositories;

namespace TaskManagement.IOC
{
    public static class IocConfig
    {
        public static IServiceCollection IocResolveDependencies(this IServiceCollection services)
        {
            #region INFRA

            services.AddSingleton<MongoDbContext>();

            #endregion

            #region SERVICES

            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<ITarefaService, TarefaService>();

            #endregion

            #region REPOSITORYS

            services.AddScoped<ITarefaRepository, TarefaRepository>();

            #endregion

            #region QUERIES

            services.AddScoped<ITarefaQueries, TarefaQueries>();

            #endregion

            return services;
        }
    }
}
