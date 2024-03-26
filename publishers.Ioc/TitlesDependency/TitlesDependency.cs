using Microsoft.Extensions.DependencyInjection;
using publishers.Application.Contract;
using publishers.Application.Service;
using publishers.Infrastructure.Interfaces;
using publishers.Infrastructure.Repositories;

namespace publishers.Ioc.TitlesDependency
{
    public static class TitlesDependency
    {
        public static void AddTitlesDependency(this IServiceCollection services)
        {
            //Repositories
            services.AddScoped<ITitlesRepository, TitlesRepository>();

            //App Services
            services.AddTransient<ITitlesServices, TitlesServices>();

        }
    }
}
