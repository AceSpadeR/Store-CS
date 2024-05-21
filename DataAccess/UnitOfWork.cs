﻿using Infrastructure.Interfaces;
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

        public IGenericRepostitory<Category> Category
        {
            get
            {
                if (_Category!=null)
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
                if (_Manufacturer != null)
                {
                    _Manufacturer = new GenericRepository<Manufacturer>(_dbContext);

                }
                return _Manufacturer;
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