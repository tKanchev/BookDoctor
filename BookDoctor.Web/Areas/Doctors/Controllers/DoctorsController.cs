namespace BookDoctor.Web.Areas.Doctors.Controllers
{
    using BookDoctor.Data.Models;
    using BookDoctor.Services.Booking;
    using BookDoctor.Web.Areas.Doctors.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    public class DoctorsController : DoctorsBaseController
    {
        private readonly IBookingService bookingService;
        private readonly UserManager<User> userManager;

        public DoctorsController(IBookingService bookingService,
            UserManager<User> userManager)
        {
            this.bookingService = bookingService;
            this.userManager = userManager;
        }
        public async Task<IActionResult> Schedule()
        {
            var currentUser = await this.userManager.GetUserAsync(HttpContext.User);

            var appointments = await this.bookingService.DoctorAppointmentsByDateAsync(currentUser.Id, DateTime.Now.Date);

            var model = new DoctorScheduleViewModel
            {
                Date = DateTime.Today,
                Appointments = appointments
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Schedule(DoctorScheduleViewModel model)
            => RedirectToAction(nameof(DailySchedule), model.Date);

        public async Task<IActionResult> DailySchedule(DateTime date)
        {
            var currentUser = await this.userManager.GetUserAsync(HttpContext.User);

            var appointments = await this.bookingService.DoctorAppointmentsByDateAsync(currentUser.Id, date);

            var model = new DoctorScheduleViewModel
            {
                Date = date,
                Appointments = appointments
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult DailySchedule(DoctorScheduleViewModel model)
            => RedirectToAction(nameof(DailySchedule), model.Date);

    }
}
