﻿using Infrastructure.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        // Increment and Decrement Shopping Cart
        int IncrementCount(ShoppingCart shoppingCart, int count);
        int DecrementCount(ShoppingCart shoppingCart, int count);

        T GetById(int? id);

        T Get(Expression<Func<T, bool>> predicate, bool trackChanges = false, string? includes = null);

        Task<T> GetAsync(Expression<Func<T, bool>> predicate, bool trackChanges = false, string? includes = null);

        IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate = null, Expression<Func<T, int>>? orderBy = null, string? includes = null);

        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, int>>? orderBy = null, string? includes = null); 

        //Add instance
        void Add(T entity);

        //Remove instance
         void Delete(T entity);

        //Delete Remove a range of itence in an object
        void Delete(IEnumerable<T> entities);

        // UpdateChanges
        void Update(T entity);
       
    }
}
