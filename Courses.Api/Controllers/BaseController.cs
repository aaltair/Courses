using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Courses.Api.Controllers
{
    [Authorize]
    public class BaseController : ControllerBase
    {

        [NonAction]
        protected string CurrentUserId()
        {
            return HttpContext.User.FindFirstValue("Id");
        }
    }
}