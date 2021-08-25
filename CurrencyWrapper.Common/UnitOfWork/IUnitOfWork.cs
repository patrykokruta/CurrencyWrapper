using CurrencyWrapper.Common.UnitOfWork.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyWrapper.Common.UnitOfWork
{
    public interface IUnitOfWork<C> : IDisposable where C : DbContext
    {
        C DbContext { get; }
        IRepository<T> Repository<T>() where T : class;
        void SaveChanges();
    }
}
