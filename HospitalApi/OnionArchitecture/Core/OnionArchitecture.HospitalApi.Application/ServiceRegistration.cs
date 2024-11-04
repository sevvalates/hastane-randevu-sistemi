using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OnionArchitecture.HospitalApi.Application.Mappings;
using System.Reflection;


namespace OnionArchitecture.HospitalApi.Application
{
    public static class ServiceRegistration
    {

        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            /*services.AddAutoMapper(opt =>
            {
                opt.AddProfiles(new List<Profile>
                {         
                    new DoctorProfile()
                });
            });*/ //benim automapper version(v5 glb ) da list göndermek yok glb
            services.AddAutoMapper(typeof(DoctorProfile)); //ben
            services.AddAutoMapper(typeof(ServiceProfile));
            services.AddAutoMapper(typeof(CorporationProfile));
            services.AddAutoMapper(typeof(PatientProfile));
            services.AddAutoMapper(typeof(AppointmentProfile));

        }
    }
}
