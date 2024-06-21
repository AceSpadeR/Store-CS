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
        public IGenericRepository<Category> Category { get; }
        public IGenericRepository<Manufacturer> Manufacturer { get; }
        public IGenericRepository<Product> Product { get; }
        

        public IGenericRepository<ApplicationUser> ApplicationUser { get; }

        public IGenericRepository<ShoppingCart> ShoppingCart { get; }

        public IGenericRepository<OrderDetails> OrderDetails { get; }

        public IOrderHeaderRepository<OrderHeader> OrderHeader { get; }


        // Add other models tables here are you create them
        // so UnitOfWork has access to them

        // save changes to the data source
        int Commit();

        Task<int> CommitAsync();


    }
}
