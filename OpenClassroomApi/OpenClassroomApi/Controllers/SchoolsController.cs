using Microsoft.AspNetCore.Mvc;
using OpenClassroomApi.BusinessManagers.Interfaces;
using OpenClassroomApi.Data.Models;

namespace OpenClassroomApi.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class SchoolsController : Controller {
        private readonly ISchoolBusinessManager schoolBusinessManager;
        public SchoolsController(ISchoolBusinessManager schoolBusinessManager) {
            this.schoolBusinessManager = schoolBusinessManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<School>> Retrieve() {
            return schoolBusinessManager.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<School>> Retrieve(Guid id) {
            return await schoolBusinessManager.GetSchoolByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(School school) {
            return await schoolBusinessManager.CreateSchoolAsync(school);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id) {
            return await schoolBusinessManager.DeleteSchoolAsync(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<School>> Update(Guid id, School school) {
            return await schoolBusinessManager.UpdateSchoolAsync(id, school);
        }
    }
}