using OpenClassroomApi.Data.Services.Interfaces;

namespace OpenClassroomApi.Data.Services {
    public class GenericService : IGenericService {
        internal readonly ApplicationDbContext applicationDbContext;

        public GenericService(ApplicationDbContext applicationDbContext) {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<T> Create<T>(T item) {
            await applicationDbContext.AddAsync(item);
            await applicationDbContext.SaveChangesAsync();
            return item;
        }

        public virtual T Retreive<T>() {
            throw new NotImplementedException();
        }

        public async Task<T> Retrieve<T>(Guid id) {
            return (T)await applicationDbContext.FindAsync(typeof(T), id);
        }

        public async Task<T> Update<T>(T item) {
            await applicationDbContext.SaveChangesAsync();
            return item;
        }

        public async Task Delete<T>(T item) {
            applicationDbContext.Remove(item);
            await applicationDbContext.SaveChangesAsync();
        }
    }
}