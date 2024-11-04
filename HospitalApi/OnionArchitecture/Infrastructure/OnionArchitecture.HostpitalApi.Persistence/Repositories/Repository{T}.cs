using Microsoft.EntityFrameworkCore;
using OnionArchitecture.HospitalApi.Application.Dto;
using OnionArchitecture.HospitalApi.Application.Interfaces;
using OnionArchitecture.HospitalApi.Domain.Entities;
using OnionArchitecture.HostpitalApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnionArchitecture.HostpitalApi.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {

        private readonly HospitalDbContext _context;

        public Repository(HospitalDbContext context)
        {
            _context = context;
        }
        public async Task<T> CreateAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        /*
        public async Task<List<T>> GetAllAsyncSpecial()
        {

            var appointmentDetails = _context.Patients
                    .SelectMany(p => p.Appointments, (p, a) => new { Patient = p, Appointment = a })
                    .Join(_context.Doctors,
                          x => x.Appointment.DoctorId,
                          b => b.Id,
                          (x, b) => new { x.Patient, x.Appointment, Doctor = b })
                    .Join(_context.Services,
                          x => x.Appointment.ServiceId,
                          c => c.Id,
                          (x, c) => new
                          {
                              HASTADI = x.Patient.Name,
                              HASTASOYADI = x.Patient.Surname,
                              DOKTORADI = x.Doctor.Name,
                              DOKTORSOYADI = x.Doctor.Surname,
                              SERVISADI = c.Name
                          });


            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }*/

        public async Task<List<AppointmentDetailDTO>> GetAllAsyncDetail()
        {
            var appointmentDetails = await _context.Patients
                .SelectMany(p => p.Appointments, (p, a) => new { Patient = p, Appointment = a })
                .Join(_context.Doctors,
                      x => x.Appointment.DoctorId,
                      b => b.Id,
                      (x, b) => new { x.Patient, x.Appointment, Doctor = b })
                .Join(_context.Services,
                      x => x.Appointment.ServiceId,
                      c => c.Id,
                      (x, c) => new AppointmentDetailDTO
                      {
                          Id = x.Appointment.Id,
                          PatientName = x.Patient.Name,
                          PatientSurname = x.Patient.Surname,
                          PatientGender = x.Patient.Gender,
                          DoctorName = x.Doctor.Name,
                          DoctorSurname = x.Doctor.Surname,
                          ServiceName = c.Name,
                          AppointmentDate = Convert.ToDateTime( x.Appointment.AppointmentDate), // Include AppointmentDate
                          AppointmentStatus = x.Appointment.AppointmentStatus, // Include AppointmentStatus

                          DoctorId = x.Doctor.Id,
                          ServiceId = x.Doctor.ServiceId,
                          

                      })
                .ToListAsync();

            return appointmentDetails;
        }



        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
        }

        // update/remove islemleri icin find 
        public async Task<T> GetByIdAsync(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task Remove(T entity)
        {
            _context.Set<T>().Remove(entity); //entitynin statetini remove olarak isaretler
            await _context.SaveChangesAsync(); //state e bakarak ne yapacagına karar veriyor
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        /*
        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }*/

        public async Task UpdateAsync(T entity)
        {
            // Ensure that the entity is attached to the context
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _context.Set<T>().Attach(entity);
            }
            _context.Entry(entity).State = EntityState.Modified; // Explicitly mark it as modified
            await _context.SaveChangesAsync();
        }




        /////////////////////////////
        public async Task<Patient> GetByIdWithAppointmentsAsync(object id)
        {

            int patientId = Convert.ToInt32(id);

            return await _context.Patients
                .Include(p => p.Appointments) // Burada randevuları dahil et
                .SingleOrDefaultAsync(p => p.Id == patientId);
        }
        ////////////////////////////

    }
}
