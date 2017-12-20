namespace BookDoctor.Web.Areas.Patients.Controllers
{
    using BookDoctor.Web.Infrastructure;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(WebConstants.PatientsArea)]
    [Authorize]
    [Authorize(Roles = null)]
    public class PatientsBaseController : Controller
    {
    }
}
