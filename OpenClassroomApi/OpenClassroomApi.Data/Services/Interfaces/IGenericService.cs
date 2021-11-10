namespace OpenClassroomApi.Data.Services.Interfaces {
    public interface IGenericService {
        Task<T> Create<T>(T item);
        T Retreive<T>();
        Task<T> Retrieve<T>(Guid id);
        Task<T> Update<T>(T item);
        Task Delete<T>(T item);
    }
}