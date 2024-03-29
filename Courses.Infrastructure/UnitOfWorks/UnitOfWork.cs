﻿using System;
using Courses.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Courses.Infrastructure.UnitOfWorks
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext
    {
        #region Fields

        private bool _disposed;
        protected TContext _context;
        #endregion




        public void Save()
        {
            _context.SaveChanges();

        }

        #region Disposable
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing) _context.Dispose();
            }
            _disposed = true;
        }



        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}