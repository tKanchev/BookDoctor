﻿namespace BookDoctor.Web.Areas.Admin.Controllers
{
    using BookDoctor.Services.Admin;
    using BookDoctor.Web.Areas.Admin.Models.MedicalCenter;
    using BookDoctor.Web.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class AdminMedicalCentersController : AdminBaseController
    {
        private readonly IAdminMedCenterService adminMedCenterService;

        public AdminMedicalCentersController(IAdminMedCenterService adminMedCenterService)
        {
            this.adminMedCenterService = adminMedCenterService;
        }

        public IActionResult Add()
            => View();

        [HttpPost]
        public async Task<IActionResult> Add(MedicalCenterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.adminMedCenterService
                .AddAsync(
                    model.Name,
                    model.Location);

            TempData.AddSuccessMessage($"Medical Center {model.Name}, {model.Location} added successfuly!");

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> All()
            => View(await this.adminMedCenterService.AllAsync());
    }
}
