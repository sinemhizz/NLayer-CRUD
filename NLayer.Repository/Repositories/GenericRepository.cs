using Microsoft.EntityFrameworkCore;
using NLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context; //bu contextin sadece miras alınan sınıflardan erişilmesini istediğimiz için protected tanımladık.
        private readonly DbSet<T> _dbset; //readonly sadece oluşturulduğu sırada değer atanır.

        public GenericRepository(AppDbContext context)
        {
            this._context = context;
            _dbset = _context.Set<T>(); //sadece ilgili ctor içerisinde değer atanır, readonly olduğu için.
        }

        public async Task AddAsync(T entity)
        {
            await _dbset.AddAsync(entity); //await geriye bir şey dönmediğimi zamanda kullanılır.

        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbset.AddRangeAsync(entities);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
           return await _dbset.AnyAsync(expression);
        }

        public IQueryable<T> GetAll()
        {
            return _dbset.AsNoTracking().AsQueryable();
            //AsNoTracking çekmiş olduğumuz dataları memorye almasın, performansı düşmesin diye kullanılır.
        }

        public async Task<T> GetAllAsync(int Id)
        {
            return await _dbset.FindAsync(Id);
        }

        public void Remove(T entity)
        {
            _dbset.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbset.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _dbset.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbset.Where(expression);
        }
    }
}
