using Microsoft.AspNetCore.Mvc;
using SampleWebApiApp.Repository;

namespace SampleWebApiApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly SiemensDbContext _context;

        public HomeController(SiemensDbContext context)
        {
            _context = context;
        }

        [Route("myapi/welcome")]
        [HttpGet]
        public string Index()
        {
            return "Hello world";
        }

        [HttpGet]
        [Route("employees/{id}")]
        public ActionResult<EmployeeInfo> Get(int id)
        {

            var found = _context.EmployeeInfos.Where(e => e.Id == id).First();
            if (found != null)
            {
                return this.Ok(found);
            }
            else
            {
                return this.NotFound();
            }

        }
    }
}
