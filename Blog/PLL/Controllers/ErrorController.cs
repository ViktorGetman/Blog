using Microsoft.AspNetCore.Mvc;

namespace Blog.PLL.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            if (statusCode == 403)
            {
                return View("AccessDenied");
            }
            else if (statusCode == 404)
            {
                return View("NotFound");
            }

            return View("InternalServerError");


        }
    }
}
