using System;
using Microsoft.EntityFrameworkCore;

namespace Courses.Infrastructure.Interfaces
{
    public interface IUnitOfWork<T> where T : DbContext, IDisposable
    {

        void Save();
    }
}