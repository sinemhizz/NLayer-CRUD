using Microsoft.EntityFrameworkCore;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{

    //business kodların yer alacağı class.
    //repository ile etkileşimde olup savechange (veritabanı) işlemleri yapılacak.
    public class Service<T> : IService<T> where T : class
    {

        private readonly IGenericRepository<T> _repository;
        private readonly IUnitOfWork _unitofwork;

        public Service(IGenericRepository<T> repository, IUnitOfWork unitofwork)
        {
            _repository = repository;
            _unitofwork = unitofwork;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            await _unitofwork.CommitAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitofwork.CommitAsync();
            return entities;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _repository.AnyAsync(expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            var hasProduct = await _repository.GetAllAsync(Id);
            if (hasProduct == null)
            {
                throw new NotFoundException($"{typeof(T).Name}({Id}) not found");
            }
            return hasProduct;  
        }

        public async Task RemoveAsync(T enttiy)
        {
            _repository.Remove(enttiy); 
            await _unitofwork.CommitAsync();    
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            _repository.RemoveRange(entities);
            await _unitofwork.CommitAsync();    
        }

        public async Task UpdateAsync(T entity)
        {
            _repository.Update(entity);
            await _unitofwork.CommitAsync();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _repository.Where(expression);
        }
    }
}
