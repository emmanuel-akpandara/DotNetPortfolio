﻿using Adventures.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Adventures.Infrastructure
{
	public class GenericRepository<T> : IRepository<T> 
		where T : class
	{
		private TravelContext _context;
		private DbSet<T> table = null;

		public GenericRepository(TravelContext context)
		{
			_context = context;
			table = context.Set<T>();
		}

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await table.ToListAsync();
        }


        public async Task<T> GetByIDAsync(int id)
        {
            return await table.FindAsync(id);
        }


        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>,
                                                    IOrderedQueryable<T>> orderBy = null,
                                                    params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = table;

            foreach (Expression<Func<T, object>> include in includes)
                query = query.Include(include);

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return await query.ToListAsync();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>,
                                                    IOrderedQueryable<T>> orderBy = null,
                                                    params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = table;

            foreach (Expression<Func<T, object>> include in includes)
                query = query.Include(include);

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query.ToList();
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
    }
}
