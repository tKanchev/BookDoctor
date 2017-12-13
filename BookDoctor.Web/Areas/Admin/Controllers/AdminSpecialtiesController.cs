namespace BookDoctor.Web.Areas.Admin.Controllers
{
    using BookDoctor.Services.Admin;
    using BookDoctor.Web.Areas.Admin.Models.Specialty;
    using BookDoctor.Web.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class AdminSpecialtiesController : AdminBaseController
    {
        private readonly IAdminSpecialtyService specialties;

        public AdminSpecialtiesController(IAdminSpecialtyService specialties)
        {
            this.specialties = specialties;
        }
        public IActionResult Add()
            => View();

        [HttpPost]
        public async Task<IActionResult> Add(SpecialtyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this
                .specialties
                .AddAsync(model.Name);

            TempData.AddSuccessMessage($"Specialty {model.Name} was added successfuly!");

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> All()
            => View(await this.specialties.AllAsync());
    }
}
