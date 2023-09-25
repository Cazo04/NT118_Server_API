using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NT118_Server_API.Models;

namespace NT118_Server_API.Controllers
{
    [ApiController]
    public class MainController : ControllerBase
    {
        [HttpGet]
        [Route("/NhanVien")]
        public async Task<IActionResult> TestGet()
        {
            return Ok(new NhanVien()
            {

            });
        }
    }
}
