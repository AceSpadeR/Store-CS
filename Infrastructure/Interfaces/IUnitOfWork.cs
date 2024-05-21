using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        public IGenericRepostitory<Category> Category { get; }
        public IGenericRepostitory<Manufacturer> Manufacturer { get; }

        // Add other models tables here are you create them
        // so UnitOfWork has access to them

        // save changes to the data source
        int Commit();

        Task<int> CommitAsync();


    }
}
