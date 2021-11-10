using Microsoft.AspNetCore.Mvc;
using OpenClassroomApi.Data.Models;

namespace OpenClassroomApi.BusinessManagers.Interfaces {
    public interface ISchoolBusinessManager {
        ActionResult<IEnumerable<School>> GetAll();
        Task<ActionResult<School>> GetSchoolByIdAsync(Guid id);
        Task<ActionResult<Guid>> CreateSchoolAsync(School school);
        Task<ActionResult<School>> UpdateSchoolAsync(Guid id, School school);
        Task<ActionResult> DeleteSchoolAsync(Guid id);
    }
}