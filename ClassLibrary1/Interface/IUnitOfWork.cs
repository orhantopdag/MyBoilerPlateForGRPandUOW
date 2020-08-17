using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Interface
{
   public interface IUnitOfWork<T>:IDisposable where T:class,IEntity
    {
        IRepository<T> Repository { get; }
        Task Commit();

    }
}
