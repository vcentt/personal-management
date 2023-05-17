using CRUD.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

public class GenericRepository<T>: IGenericRepository<T> where T:class {
    private readonly StudentsContext _context;

    public GenericRepository(StudentsContext context){
        _context = context;
    }

    public async Task<IEnumerable<T>> GetAll() {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T?> Get(int id) {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<T?> Add(T entity) {
        _context.Set<T>().Add(entity);
        
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<T?> Update(T entity){
        _context.Entry(entity).State = EntityState.Modified;

        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<T?> Delete(int id){
        var entity = await _context.Set<T>().FindAsync(id);

        if(entity is null) return entity!;

        _context.Set<T>().Remove(entity);

        await _context.SaveChangesAsync();
        return entity;
    }
}