namespace BookDoctor.Web.Areas.Patients.Controllers
{
    using BookDoctor.Data.Models;
    using BookDoctor.Services.Booking;
    using BookDoctor.Services.Doctor;
    using BookDoctor.Web.Areas.Patients.Models;
    using BookDoctor.Web.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PatientsController : PatientsBaseController
    {
        private readonly IDoctorService doctorService;
        private readonly IBookingService bookingService;
        private readonly UserManager<User> userManager;

        public PatientsController(IDoctorService doctorService,
            IBookingService bookingService,
            UserManager<User> userManager)
        {
            this.doctorService = doctorService;
            this.bookingService = bookingService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Appointments()
        {
            var currentUser = await this.userManager.GetUserAsync(HttpContext.User);

            var appointments = await this.bookingService.PatientAppointmentsAsync(currentUser.Id);
            var patientAppointmentsViewList = appointments.Select(a => new PatientAppointmentsListViewModel
            {
                Info = a.Info,
                Date = a.Date,
                TimeStart = a.TimeStart,
                TimeEnd = a.TimeEnd,
                DoctorName = $"Dr. {a.Doctor.LastName}"
            })
            .ToList();

            return View(patientAppointmentsViewList);
            
        }

        [HttpPost]
        public async Task<IActionResult> BookDoctor(PatientAppointmentFormViewModel model)
        {
            
            if (!ModelState.IsValid)
            {
                var doctorsListItems = await GetDoctorsListItemsAsync();
                model.Doctors = doctorsListItems;
               
                return View(model);
            }

            var isAvailable = await CheckAvailabilityAsync(
                    model.DoctorId,
                    model.Date,
                    model.TimeStart);  
                

            if (!isAvailable)
            {
                var doctorsListItems = await GetDoctorsListItemsAsync();
                model.Doctors = doctorsListItems;
                return View(model);
            }
            
            var currentUser = await this.userManager.GetUserAsync(HttpContext.User);

            await this.bookingService
                .AddAsync(model.Info,
                    model.Date.Date,
                    model.TimeStart,
                    model.TimeEnd,
                    model.DoctorId,
                    currentUser.Id);

            TempData.AddSuccessMessage("You just made a booking! Please do not forget your appointment!");

            return RedirectToAction(nameof(Appointments));
        }

        

        public async Task<IActionResult> BookDoctor()
        {
            var doctors = await this.doctorService.AllAsync();

            var doctorsListItems = doctors.Select(dr => new SelectListItem
            {
                Text = $"Dr. {dr.LastName}",
                Value = dr.Id
            })
            .ToList();

            return View(new PatientAppointmentFormViewModel
                {
                    Date = DateTime.Today,
                    Doctors = doctorsListItems
                });
        }

        private async Task<IEnumerable<SelectListItem>> GetDoctorsListItemsAsync()
        {
            var doctors = await this.doctorService.AllAsync();

            var doctorsListItems = doctors.Select(dr => new SelectListItem
            {
                Text = $"Dr. {dr.LastName}",
                Value = dr.Id
            })
            .ToList();

            return doctorsListItems;
        }

        private async Task<bool> CheckAvailabilityAsync(string doctorId, DateTime date, TimeSpan startTime)
        {
            TimeSpan workDayStart = TimeSpan.Parse("08:00");
            TimeSpan workDayEnd = TimeSpan.Parse("16:00");
            if (startTime < workDayStart || startTime > workDayEnd)
            {
                TempData.AddErrorMessage("Choose an hour between 8 AM and 4 PM");
                return false;
            }

            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                TempData.AddErrorMessage("Choose a date not during the weekend");
                return false;
            }

            if (DateTime.Now.Date == date && DateTime.Now.TimeOfDay > startTime)
            {
                TempData.AddErrorMessage("You cannot make an appointment in a past hour!");
                return false;
            }

            bool isDoctorAvailable = await this.bookingService.CheckAvailability(doctorId, date, startTime);
            if (!isDoctorAvailable)
            {
                TempData.AddErrorMessage("Doctor is already booked for this hour!");
            }
            return isDoctorAvailable;
        }
    }
}
