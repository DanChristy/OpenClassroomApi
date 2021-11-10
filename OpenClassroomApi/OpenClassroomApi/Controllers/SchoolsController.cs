using Microsoft.AspNetCore.Mvc;
using OpenClassroomApi.Data;
using OpenClassroomApi.Data.Models;

namespace OpenClassroomApi.Controllers {
    [ApiController]
    [Route("[controller]/[action]")]
    public class SchoolsController : Controller {
        private readonly ApplicationDbContext applicationDbContext;
        public SchoolsController(ApplicationDbContext applicationDbContext) {
            this.applicationDbContext = applicationDbContext;
        }
        
        [HttpGet("{id}")]
        public ActionResult<School> Details(Guid id) {
            var school = applicationDbContext.Schools.FirstOrDefault(school => school.Id == id);

            if (school is null) {
                return new NotFoundObjectResult($"A school with an id of ({id}) was not found.");
            }

            return school;
        }
    }
}