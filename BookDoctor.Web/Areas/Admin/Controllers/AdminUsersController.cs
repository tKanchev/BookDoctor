namespace BookDoctor.Web.Areas.Admin.Controllers
{
    using BookDoctor.Services.Admin;
    using BookDoctor.Web.Areas.Admin.Models.User;
    using BookDoctor.Web.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Linq;
    using System.Threading.Tasks;

    public class AdminUsersController : AdminBaseController
    {
        private readonly IAdminUserService users;
        private readonly IAdminSpecialtyService specialties;
        private readonly IAdminMedCenterService medCenters;

        public AdminUsersController(IAdminUserService users,
            IAdminSpecialtyService specialties,
            IAdminMedCenterService medCenters)
        {
            this.users = users;
            this.specialties = specialties;
            this.medCenters = medCenters;
        }

        public async Task<IActionResult> All()
            => View(await this.users.AllAsync());

        public async Task<IActionResult> Edit(string userId)
        {
            var user = await this.users.GetByIdAsync(userId);

            if (user == null)
            {
                TempData.AddErrorMessage("User does not exist!");

                return RedirectToAction(nameof(All));
            }

            var allMedCenters = await medCenters.AllAsync();
            var allSpecialties = await specialties.AllAsync();

            var model = new UserFormViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsDoctor = user.IsDoctor,
                SpecialtyId = user.SpecialtyId,
                MedicalCenterId = user.MedicalCenterId
            };

            if (user.IsDoctor)
            {
                model.MedicalCenters = allMedCenters
                    .Select(c => new SelectListItem
                    {
                        Text = $"{c.Name}, {c.Location}",
                        Value = c.Id.ToString()
                    })
                    .ToList();

                model.Specialties = allSpecialties
                    .Select(s => new SelectListItem
                    {
                        Text = s.Name,
                        Value = s.Id.ToString()
                        
                    })
                    .ToList();
                if (user.MedicalCenterId != null )
                {
                    model.MedicalCenters.First(x => x.Value == user.MedicalCenterId.ToString()).Selected = true;
                    model.MedicalCenters.First(x => x.Value == user.MedicalCenterId.ToString()).Disabled = true;
                }
                if (user.SpecialtyId != null)
                {
                    model.Specialties.First(x => x.Value == user.SpecialtyId.ToString()).Selected = true;
                    model.Specialties.First(x => x.Value == user.SpecialtyId.ToString()).Disabled = true;
                }                
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.users.EditAsync(
                model.Id,
                model.FirstName,
                model.LastName,
                model.MedicalCenterId,
                model.SpecialtyId);

            TempData.AddSuccessMessage("User edited successfully!");

            return RedirectToAction(nameof(All));
        }
    }
}
