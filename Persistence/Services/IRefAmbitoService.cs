using SIARH.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SIARH.Persistence.Services
{
    public interface IRefAmbitoService
    {
        Task<IEnumerable<RefAmbito>> All();
        Task<RefAmbito> GetById(int id);
        Task<bool> Add(RefAmbito entity);
        Task<bool> Delete(int id);
        Task<bool> Upsert(RefAmbito entity);
        Task<IEnumerable<RefAmbito>> Find(Expression<Func<RefAmbito, bool>> predicate);
    }
}
