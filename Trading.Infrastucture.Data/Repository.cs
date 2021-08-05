﻿namespace Trading.Infrastucture.Data
{
	using Microsoft.EntityFrameworkCore;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using Trading.Domain.Interfaces;

	public abstract class Repository<TEntity, TContext> : IRepository<TEntity>
		where TEntity : class, IEntity
		where TContext : DbContext
	{
		private readonly TContext _context;

		public Repository(TContext context)
		{
			_context = context;
		}

		public async Task<List<TEntity>> GetAllAsync()
		{
			return await _context.Set<TEntity>().ToListAsync();
		}

		public async Task<TEntity> GetIdAsync(int id)
		{
			return await _context.Set<TEntity>().FindAsync(id);
		}

		public async Task<TEntity> AddAsync(TEntity entity)
		{
			_context.Set<TEntity>().Add(entity);
			await _context.SaveChangesAsync();

			return entity;
		}

		public async Task<TEntity> UpdateAsync(TEntity entity)
		{
			_context.Entry(entity).State = EntityState.Modified;
			await _context.SaveChangesAsync();

			return entity;
		}

		public async Task<bool> DeleteAsync(int id)
		{
			bool status;

			try
			{
				TEntity entity = await _context.Set<TEntity>().FindAsync(id);

				if (entity != null)
				{
					_context.Set<TEntity>().Remove(entity);
					await _context.SaveChangesAsync();
				}

				status = true;
			}
			catch (Exception)
			{
				status = false;
			}

			return status;
		}
	}
}
