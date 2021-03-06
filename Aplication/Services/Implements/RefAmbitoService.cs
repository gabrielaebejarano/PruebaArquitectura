using SIARH.Aplication.DTOs;
using SIARH.Persistence.Models;
using SIARH.Persistence.Repositories;
using SIARH.Persistence.Repositories.Implements;
using SIARH.Persistence.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SIARH.Aplication.Services.Implements
{

    public class RefAmbitoService : IRefAmbitoService
    {

        private readonly IUnitOfWork _unitOfWork;
        public RefAmbitoService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<bool> Add(totalDTO totalDTO)
        {
            RefEscalafon refEscalafon = new RefEscalafon();
            refEscalafon.IdEscalafon = totalDTO.IdEscalafon;
            refEscalafon.EscalafonDesc = totalDTO.EscalafonDesc;
            refEscalafon.IdGrupoNivel = totalDTO.IdGrupoNivel;
            refEscalafon.Nomenclatura = totalDTO.Nomenclatura;

            RefAmbito refAmbito = new RefAmbito();
            refAmbito.IdAmbito = totalDTO.IdAmbito;
            refAmbito.AmbitoDesc = totalDTO.AmbitoDesc;

            await _unitOfWork.RefAmbito.Add(refAmbito);
           // await _unitOfWork.RefEscalafon.Add(refEscalafon);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<IEnumerable<RefAmbito>> All()
        {
            return await _unitOfWork.RefAmbito.All();
        }

        public async Task<bool> Delete(int id)
        {
            return await _unitOfWork.RefAmbito.Delete(id);
        }

        public Task<IEnumerable<RefAmbito>> Find(Expression<Func<RefAmbito, bool>> predicate)
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
