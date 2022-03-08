using SIARH.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SIARH.Persistence.Services.Implements
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        protected IGenericRepository<T> genericRepository;

        public GenericService(IGenericRepository<T> _genericRepository)
        {
            genericRepository = _genericRepository;
        }
        public async Task<bool> Add(T entity)
        {
            return await genericRepository.Add(entity);
        }

        public async Task<IEnumerable<T>> All()
        {
            return await genericRepository.All();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Upsert(T entity)
        {
            return genericRepository.Upsert(entity);
        }
    }
}
