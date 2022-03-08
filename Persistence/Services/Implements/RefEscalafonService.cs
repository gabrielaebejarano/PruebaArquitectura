using SIARH.Persistence.Models;
using SIARH.Persistence.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SIARH.Persistence.Services.Implements
{
    public class IRefEscalafonService
    {
        private readonly IUnitOfWork _unitOfWork;
        public IRefEscalafonService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<bool> Add(RefEscalafon entity)
        {
            await _unitOfWork.RefEscalafon.Add(entity);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<IEnumerable<RefEscalafon>> All()
        {
            return await _unitOfWork.RefEscalafon.All();
        }

        public async Task<bool> Delete(int id)
        {
            return await _unitOfWork.RefAmbito.Delete(id);
        }

        public Task<IEnumerable<RefEscalafon>> Find(Expression<Func<RefEscalafon, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<RefAmbito> GetById(int id)
        {
            return await _unitOfWork.RefAmbito.GetById(id);
        }

        public async Task<bool> Upsert(RefAmbito entity)
        {
            return await _unitOfWork.RefAmbito.Upsert(entity);
        }
    }
}
