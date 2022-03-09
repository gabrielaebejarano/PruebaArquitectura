using SIARH.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SIARH.Aplication.Services
{
    public interface IRefEscalafonService
    {
        Task<IEnumerable<RefEscalafon>> All();
        Task<RefEscalafon> GetById(int id);
        Task<bool> Add(RefEscalafon entity);
        Task<bool> Delete(int id);
        Task<bool> Upsert(RefEscalafon entity);
        Task<IEnumerable<RefEscalafon>> Find(Expression<Func<RefEscalafon, bool>> predicate);
    }
}
