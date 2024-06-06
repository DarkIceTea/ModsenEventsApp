
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers
{
    public class AuthController : Controller
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {

        }
    }
}
