using Services.Interfaces;
using Repository.Interfaces;

class GenericServices<T>: IGenericServices<T> where T: class {
    private readonly IGenericRepository<T> _genericServices;

    public GenericServices(IGenericRepository<T> genericServices){
        _genericServices = genericServices;
    }

    public async Task<IEnumerable<T>> GetAll() {
        return await _genericServices.GetAll();
    }

    public async Task<T?> Get(int id) {
        return await _genericServices.Get(id);
    }

    public async Task<T?> Add(T student) {
        return await _genericServices.Add(student);
    }

    public async Task<T?> Update(T student) {
        return await _genericServices.Update(student);
    }

    public async Task<T?> Delete(int id){
        return await _genericServices.Delete(id);
    }
}