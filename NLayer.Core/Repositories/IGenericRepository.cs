using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAllAsync(int Id);

        //productRepository.where(x=>x.id>5).OrderBy.ToList.Async(); ---- Çağırtılan sorguları order by ile sıralıyor.

        IQueryable<T> GetAll();

        //productRepository.GetAll(x=>x.id>5).ToList(); ------ Veri tabanına sorgu atar. 

        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);

        Task AddRangeAsync(IEnumerable<T> entities);

        Task AddAsync(T entity);

        void Update(T entity); //Update ve Remove için async yok, çünkü kayıt eklemek kadar uğraştırıcı değil.
        void Remove(T entities);

        void RemoveRange(IEnumerable<T> entities);

    }
}
