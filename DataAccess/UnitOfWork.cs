using Infrastructure.Interfaces;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public IGenericRepostitory<Category> _Category;

        public IGenericRepostitory<Manufacturer> _Manufacturer;
        public IGenericRepostitory<Product> _Product;
        public IGenericRepostitory<ApplicationUser> _ApplicationUser;
        public IGenericRepostitory<ShoppingCart> _ShoppingCart;
        public IGenericRepostitory<Category> Category
        {
            get
            {
                if (_Category==null)
                {
                    _Category = new GenericRepository<Category>(_dbContext);

                }
                return _Category;
            }
        }

        public IGenericRepostitory<Manufacturer> Manufacturer
        {
            get
            {
                if (_Manufacturer == null)
                {
                    _Manufacturer = new GenericRepository<Manufacturer>(_dbContext);

                }
                return _Manufacturer;
            }
        }

        public IGenericRepostitory<Product> Product
        {
            get
            {
                if (_Product == null)
                {
                    _Product = new GenericRepository<Product>(_dbContext);

                }
                return _Product;
            }
        }

        public IGenericRepostitory<ApplicationUser> ApplicationUser
        {
            get
            {
                if (_ApplicationUser == null)
                {
                    _ApplicationUser = new GenericRepository<ApplicationUser>(_dbContext);

                }
                return _ApplicationUser;
            }
        }
        public IGenericRepostitory<ShoppingCart> ShoppingCart
        {
            get
            {
                if (_ShoppingCart == null)
                {
                    _ShoppingCart = new GenericRepository<ShoppingCart>(_dbContext);

                }
                return _ShoppingCart;
            }
        }


        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
