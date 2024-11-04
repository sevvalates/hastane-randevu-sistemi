using OnionArchitecture.HospitalApi.Application.Dto;
using OnionArchitecture.HospitalApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnionArchitecture.HospitalApi.Application.Interfaces
{
    public interface IRepository<T> where T : class, new()
    {
        Task<List<T>> GetAllAsync();

        Task<List<AppointmentDetailDTO>> GetAllAsyncDetail();

        Task<T> GetByIdAsync(object id);

        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter);

        Task<T> CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task Remove(T entity); //niye async değil

        Task<int> SaveChangesAsync(); //adlandırılması "Commit" normalde,

        Task<Patient> GetByIdWithAppointmentsAsync(object id);
    }
}
