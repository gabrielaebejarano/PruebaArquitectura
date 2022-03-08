﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using SIARH.Persistence.Repositories;

namespace SIARH.Persistence.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRefAmbitoRepository RefAmbito { get; }
        IRefEscalafonRepository RefEscalafon { get; }
        Task CompleteAsync();
        void Dispose();
    }
}
