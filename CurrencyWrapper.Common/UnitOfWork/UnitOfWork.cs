using CurrencyWrapper.Common.Logger;
using CurrencyWrapper.Common.UnitOfWork.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyWrapper.Common.UnitOfWork
{
    public class UnitOfWork<C> : IUnitOfWork<C> where C : DbContext
    {
        private bool _disposed = false;
        private Dictionary<Type, object> _repositories = new Dictionary<Type, object>();
        private readonly ILoggerService _loggerService;

        public C DbContext { get; }

        public UnitOfWork(C dbContext, ILoggerService loggerService)
        {
            DbContext = dbContext;
            _loggerService = loggerService;
        }

        public IRepository<T> Repository<T>() where T : class
        {
            if (_repositories.ContainsKey(typeof(T)))
                return _repositories[typeof(T)] as IRepository<T>;

            IRepository<T> repository = new Repository<T>(DbContext);
            _repositories.Add(typeof(T), repository);
            return repository;
        }

        public void SaveChanges()
        {
            try
            {
                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _loggerService.Log(ex.Message, LogLevel.Error);
                throw;
            }

        }

        public void Dispose()
        {
            DbContext.Dispose();
            _repositories = null;
        }
    }
}
