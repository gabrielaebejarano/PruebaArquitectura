using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SIARH.Persistence.Models;
using SIARH.Persistence.Repositories;
using SIARH.Persistence.Repositories.Implements;

namespace SIARH.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly RRHH_V2Context _context;
        private RefAmbitoRepository? _refAmbitoRepository;
        private RefEscalafonRepository? _refEscalafonRepository;
        //private readonly ILogger _logger;
        //public IRefAmbitoRepository RefAmbito { get; private set; }
        //public IRefEscalafonRepository RefEscalafon { get; private set; }

        public IRefAmbitoRepository RefAmbito => _refAmbitoRepository = _refAmbitoRepository ?? new RefAmbitoRepository(_context);
        public IRefEscalafonRepository RefEscalafon => _refEscalafonRepository = _refEscalafonRepository ?? new RefEscalafonRepository(_context);

        public UnitOfWork(RRHH_V2Context context)//, ILoggerFactory loggerFactory)
        {
            _context = context;
            //_logger = loggerFactory.CreateLogger("logs");

            //RefAmbito = new RefAmbitoRepository(context);
            //RefEscalafon = new RefEscalafonRepository(context);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
