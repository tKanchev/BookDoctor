namespace BookDoctor.Services.Booking
{
    using BookDoctor.Services.ServiceCommonModels;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBookingService
    {
        Task AddAsync(string info,
            DateTime date,
            TimeSpan startTime,
            TimeSpan endTime,
            string doctorId,
            string patientId);

        Task<bool> CheckAvailability(string doctorId, DateTime date, TimeSpan timeStart);

        Task<IEnumerable<AppointmentServiceModel>> PatientAppointmentsAsync(string patientId);

        Task<IEnumerable<AppointmentServiceModel>> DoctorAppointmentsByDateAsync(string doctorId, DateTime date);

    }
}
