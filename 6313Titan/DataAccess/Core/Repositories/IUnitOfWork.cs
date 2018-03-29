using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.DataAccess.Core.Repositories;

namespace _6313Titan.DataAccess.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IContactRepository Contacts { get; }
        int Complete();
    }
}
