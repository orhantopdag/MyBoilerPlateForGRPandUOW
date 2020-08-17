﻿using GenericRepository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        DbSet<T> Table { get; set; }
        public Repository(MRPanelContext context)
        {
            Table = context.Set<T>();
        }
        public async Task Add(T entity) => await Table.AddAsync(entity);

        public async Task Add(IEnumerable<T> entities)
        {
            await Table.AddRangeAsync(entities);
        }

        public async Task<IList<T>> All()
        {
          return  await Table.AsNoTracking().ToListAsync();
        }

        public void Delete(T entity)
        {
            Table.Remove(entity);
        }

        public void Delete(IEnumerable<T> entities)
        {
            Table.RemoveRange(entities);
        }

        public async Task<T> GetById(Guid Id)
        {
            return await Table.SingleAsync(x => x.Id == Id);
        }

        public void Update(T entity)
        {
            Table.Update(entity);
        }

        public void Update(IEnumerable<T> entities)
        {
            Table.UpdateRange(entities);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
          return  Table.Where<T>(expression);
        }
    }
}
