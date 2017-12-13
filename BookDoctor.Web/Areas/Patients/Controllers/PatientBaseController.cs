namespace BookDoctor.Web.Areas.Patients.Controllers
{
    using BookDoctor.Web.Infrastructure;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(WebConstants.PatientsArea)]
    [Authorize]
    public class PatientsBaseController : Controller
    {
    }
}
