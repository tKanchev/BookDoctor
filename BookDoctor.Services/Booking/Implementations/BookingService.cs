namespace BookDoctor.Services.Booking.Implementations
{
    using AutoMapper.QueryableExtensions;
    using BookDoctor.Data;
    using BookDoctor.Data.Models;
    using BookDoctor.Services.ServiceCommonModels;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class BookingService : IBookingService
    {
        private readonly BookDoctorDbContext db;

        public BookingService(BookDoctorDbContext db)
        {
            this.db = db;
        }

        public async Task AddAsync(string info, 
            DateTime date, 
            TimeSpan startTime, 
            TimeSpan endTime, 
            string doctorId, 
            string patientId)
        {
            var appointment = new Appointment
            {
                Info = info,
                Date = date,
                TimeStart = startTime,
                TimeEnd = startTime.Add(TimeSpan.FromHours(1)),
                DoctorId = doctorId,
                PatientId = patientId
            };

            await this.db.Appointments.AddAsync(appointment);
            await this.db.SaveChangesAsync();
        }

        public async Task<bool> CheckAvailability(string doctorId, DateTime date, TimeSpan timeStart)
            => !await this.db
                    .Appointments
                    .AnyAsync(a => a.DoctorId == doctorId
                        && a.Date.Date == date.Date
                        && a.TimeStart == timeStart);

        public async Task<IEnumerable<AppointmentServiceModel>> DoctorAppointmentsByDateAsync(string doctorId, DateTime date)
            => await this.db
            .Appointments
            .Where(a => a.DoctorId == doctorId && a.Date == date)
            .ProjectTo<AppointmentServiceModel>()
            .ToListAsync();

        public async Task<IEnumerable<AppointmentServiceModel>> PatientAppointmentsAsync(string patientId)
            => await this.db
            .Appointments
            .Where(a => a.PatientId == patientId)
            .OrderByDescending(a => a.Date)
            .ThenByDescending(a => a.TimeStart)
            .ProjectTo<AppointmentServiceModel>()
            .ToListAsync();
    }
}
