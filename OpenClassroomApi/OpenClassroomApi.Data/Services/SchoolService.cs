using OpenClassroomApi.Data.Services.Interfaces;

namespace OpenClassroomApi.Data.Services {
    public class SchoolService : GenericService, ISchoolService {
        public SchoolService(ApplicationDbContext context) : base(context) { }

        public override T Retreive<T>() {
            return (T)(object)applicationDbContext.Schools;
        }
    }
}