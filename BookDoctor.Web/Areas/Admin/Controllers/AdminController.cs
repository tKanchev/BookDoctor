namespace BookDoctor.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class AdminController : AdminBaseController
    {
        public IActionResult Administration()
            => View();    
    }
}
