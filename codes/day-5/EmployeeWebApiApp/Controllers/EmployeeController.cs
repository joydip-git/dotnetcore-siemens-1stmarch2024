using EmployeeWebApiApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly SiemensDbContext _context;

        public EmployeeController(SiemensDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("all")]
        public ActionResult GetEmoloyees()
        {
            OkObjectResult  okResult = Ok(_context.EmployeeInfos.ToList());
            return okResult;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetEmoloyee(int? id)
        {
            if (id.HasValue)
            {
                var found = _context.EmployeeInfos.Where(e => e.Id == id.Value).First();
                    if (found != null) {
                    OkObjectResult okResult = Ok(found);
                    return okResult;
                }
                else
                {
                    return NotFound($"employee with {id} not found");
                }
            }
            else
            {
                return BadRequest($"employee id was not sent properly");
            }
        }
    }
}
