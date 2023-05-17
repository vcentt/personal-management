namespace Services.Interfaces {
    public interface IGenericServices<T> where T:class {
        Task<IEnumerable<T>> GetAll();
        Task<T?> Get(int id);
        Task<T?> Add(T student);
        Task<T?> Update(T student);
        Task<T?> Delete(int id);
    }
}