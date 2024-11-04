using MediatR;
using OnionArchitecture.HospitalApi.Application.Features.CQRS.AppointmentCQRS.Commands;
using OnionArchitecture.HospitalApi.Application.Interfaces;
using OnionArchitecture.HospitalApi.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.AppointmentCQRS.Handlers
{
    public class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommandRequest>
    {

        private readonly IRepository<Appointment> repository;

        public UpdateAppointmentCommandHandler(IRepository<Appointment> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(UpdateAppointmentCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedEntity = await repository.GetByIdAsync(request.Id);
            if (updatedEntity != null)
            {
                //updatedEntity.PatientId = request.PatientId;
                if (request.AppointmentDate != null)
                {
                    updatedEntity.AppointmentDate = request.AppointmentDate;
                    Console.WriteLine("date");
                }

                if (request.AppointmentStatus != null)
                {
                    updatedEntity.AppointmentStatus = request.AppointmentStatus;
                    Console.WriteLine("statu");
                }

                if (request.ServiceId != null || request.ServiceId != 0)
                {
                    updatedEntity.ServiceId = request.ServiceId;
                    Console.WriteLine("service");
                }

                if (request.DoctorId != null || request.DoctorId != 0)
                {
                    updatedEntity.DoctorId = request.DoctorId;
                    Console.WriteLine("doctor");
                }

                await repository.UpdateAsync(updatedEntity);
            }
            return Unit.Value;
        }
    }
}
