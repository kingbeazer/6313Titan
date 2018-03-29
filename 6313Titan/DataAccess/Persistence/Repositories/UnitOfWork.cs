using _6313Titan.DataAccess.Core.Repositories;
using _6313Titan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Titan.DataAccess.Core.Repositories;
using Titan.DataAccess.Persistence.Repositories;

namespace _6313Titan.DataAccess.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Contacts = new ContactRepository(_context);
        }

        public IContactRepository Contacts { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}