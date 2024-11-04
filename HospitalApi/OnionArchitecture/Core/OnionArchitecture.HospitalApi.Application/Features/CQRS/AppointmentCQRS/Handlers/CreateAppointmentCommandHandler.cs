using AutoMapper;
using MediatR;
using OnionArchitecture.HospitalApi.Application.Dto;
using OnionArchitecture.HospitalApi.Application.Features.CQRS.AppointmentCQRS.Commands;
using OnionArchitecture.HospitalApi.Application.Interfaces;
using OnionArchitecture.HospitalApi.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OnionArchitecture.HospitalApi.Application.Features.CQRS.AppointmentCQRS.Handlers
{
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommandRequest, CreatedAppointmentDto>
    {

        private readonly IRepository<Appointment> repository;
        private readonly IMapper mapper;

        private readonly IRepository<Patient> patient_repository;

        public CreateAppointmentCommandHandler(IRepository<Appointment> repository, IMapper mapper, IRepository<Patient> patient_repository)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.patient_repository = patient_repository;
        }

        public async Task<CreatedAppointmentDto> Handle(CreateAppointmentCommandRequest request, CancellationToken cancellationToken)
        {
            // patientId ile hastayı çek 
            // hastanın randevularını çek
            // 1 - hastanın aynı servisten randevusu varsa randevu verme
            // 2 - hastanın min 45 dakika önce ya da 45 dakika sonraki aralıkta randevusu varsa randevu vermme
            var give_appointment = true;
            string errorMessage = null;

            var patient = await patient_repository.GetByIdWithAppointmentsAsync(request.PatientId);
            var appointmentList = patient.Appointments;

            if (patient != null)
            {

                if (patient.Appointments.Count > 2)
                {
                    give_appointment = false;
                    errorMessage = "Hasta alabileceği randevu kapasitesine(2) ulaşmıştır.";
                }
                else if (patient.Appointments.Count != 0)
                {
                    foreach (Appointment a in appointmentList)
                    {
                        if (a.ServiceId == request.ServiceId)
                        {
                            give_appointment = false;
                            errorMessage = "Hastanın aynı serviste başka bir randevu kaydı bulunmaktadır.";
                            break;
                        }
                        else if (a.AppointmentDate == request.AppointmentDate)
                        {
                            give_appointment = false;
                            errorMessage = "Hastanın aynı tarihte başka bir randevu kaydı bulunmaktadır.";
                            break;
                        }
                        else if (a.AppointmentDate.Date == request.AppointmentDate.Date)
                        {

                            // request edilenin saatinden önceki ve sonraki 45 dk başka randevu varsa 
                            TimeSpan time_a = a.AppointmentDate.TimeOfDay;
                            TimeSpan time_req = request.AppointmentDate.TimeOfDay;

                            //16.30 ise 15.45 ve 17.15 arası randevu var mı bakıcaz 
                            TimeSpan fortyFiveMinutesAgo = time_a.Add(new TimeSpan(0, -45, 0));
                            TimeSpan fortyFiveMinutesLater = time_a.Add(new TimeSpan(0, 45, 0));

                            if (time_req.CompareTo(fortyFiveMinutesAgo) >= 0 && time_req.CompareTo(fortyFiveMinutesLater) <= 0)
                            {
                                give_appointment = false;
                                errorMessage = "Hastanın randevu saatleri arasında min 45 dakika bulunmalıdır.";
                                break;
                            }
                        }
                    }
                }
            }

            if (give_appointment)
            {

                var existingAppointment = await repository.GetByFilterAsync(x => x.DoctorId == request.DoctorId && x.AppointmentDate == request.AppointmentDate);
                if (existingAppointment == null)
                {
                    var appointment = new Appointment
                    {
                        DoctorId = request.DoctorId,
                        PatientId = request.PatientId,
                        ServiceId = request.ServiceId,
                        AppointmentDate = request.AppointmentDate,
                        AppointmentStatus = request.AppointmentStatus
                    };

                    await repository.CreateAsync(appointment);

                    patient.Appointments.Add(appointment);
                    await patient_repository.UpdateAsync(patient);

                    return mapper.Map<CreatedAppointmentDto>(appointment);
                }
                else
                {
                    return new CreatedAppointmentDto { ErrorMessage = "Aynı servisten mevcut bir randevu var." };
                }
            }
            else
            {
                return new CreatedAppointmentDto { ErrorMessage = errorMessage };
            }

        }
    }
}
