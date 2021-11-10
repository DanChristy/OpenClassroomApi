using Microsoft.AspNetCore.Mvc;
using OpenClassroomApi.BusinessManagers.Interfaces;
using OpenClassroomApi.Data.Models;
using OpenClassroomApi.Data.Services.Interfaces;

namespace OpenClassroomApi.BusinessManagers {
    public class SchoolBusinessManager : ISchoolBusinessManager {
        private readonly ISchoolService schoolService;

        public SchoolBusinessManager(ISchoolService schoolService) {
            this.schoolService = schoolService;
        }

        public ActionResult<IEnumerable<School>> GetAll() {
            return new OkObjectResult(schoolService.Retreive<IEnumerable<School>>());
        }

        public async Task<ActionResult<School>> GetSchoolByIdAsync(Guid id) {
            var school = await schoolService.Retrieve<School>(id);

            if (school is null)
                return new NotFoundObjectResult($"A school with an id of ({id}) was not found.");

            return school;
        }

        public async Task<ActionResult<Guid>> CreateSchoolAsync(School school) {
            await schoolService.Create(school);
            return school.Id;
        }

        public async Task<ActionResult<School>> UpdateSchoolAsync(Guid id, School school) {
            if (id != school.Id)
                return new BadRequestObjectResult("The provided ids must match.");

            var updateSchool = await schoolService.Retrieve<School>(id);

            if (updateSchool is null)
                return new NotFoundObjectResult($"A school with an id of ({id}) was not found.");

            updateSchool.Name = school.Name;
            updateSchool.Description = school.Description;
            updateSchool.State = school.State;
            updateSchool.City = school.City;
            updateSchool.ZipCode = school.ZipCode;
            updateSchool.Address = school.Address;

            return await schoolService.Update(updateSchool);
        }

        public async Task<ActionResult> DeleteSchoolAsync(Guid id) {
            var school = await schoolService.Retrieve<School>(id);

            if (school is null)
                return new NotFoundObjectResult($"A school with an id of ({id}) was not found.");

            await schoolService.Delete(school);

            return new NoContentResult();
        }
    }
}