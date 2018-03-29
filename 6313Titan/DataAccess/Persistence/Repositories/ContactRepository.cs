using _6313Titan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Titan.DataAccess.Core.Repositories;

namespace Titan.DataAccess.Persistence.Repositories
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {

        public ContactRepository(ApplicationDbContext datacontext)
            : base (datacontext)
        {
        }
        public IEnumerable<Contact> GetPeople(int Count)
        {
            throw new NotImplementedException();
        }

        public ApplicationDbContext dbContext
        {
            get { return dbContext as ApplicationDbContext; }
        }
    }
}