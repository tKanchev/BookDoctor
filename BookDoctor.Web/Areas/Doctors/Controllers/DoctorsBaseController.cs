namespace BookDoctor.Web.Areas.Doctors.Controllers
{
    using BookDoctor.Web.Infrastructure;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(WebConstants.DoctorsArea)]
    [Authorize(Roles = WebConstants.DoctorRole)]
    public class DoctorsBaseController : Controller
    {
    }
}
