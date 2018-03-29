using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _6313Titan;
using _6313Titan.Models;

namespace Titan.DataAccess.Core.Repositories
{
    public interface IContactRepository : IRepository<Contact>
    {
        IEnumerable<Contact> GetPeople(int Count);
    }
}