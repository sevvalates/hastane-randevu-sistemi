using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionArchitecture.HospitalApi.Application.Interfaces;
using OnionArchitecture.HostpitalApi.Persistence.Context;
using OnionArchitecture.HostpitalApi.Persistence.Repositories;


namespace OnionArchitecture.HostpitalApi.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {

            //connectionstring i program.cs ten göndercez bunu çağırdığımızda
            services.AddDbContext<HospitalDbContext>(opt =>
            {
                opt.UseMySql(configuration.GetConnectionString("Local"), ServerVersion.AutoDetect(configuration.GetConnectionString("Local")));
            });

            // persistence application ı görüyo ama application persistence i görmüyo
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
