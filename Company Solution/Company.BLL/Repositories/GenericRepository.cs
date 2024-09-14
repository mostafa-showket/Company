﻿using Company.BLL.Interfaces;
using Company.DAL.Data.Contexts;
using Company.DAL.Models;

namespace Company.BLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        public AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll() => _context.Set<T>().ToList();


        public T Get(int id) => _context.Set<T>().Find(id);

        public int Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return _context.SaveChanges();
        }

        public int Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return _context.SaveChanges();
        }

        public int Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return _context.SaveChanges();
        }
    }
}