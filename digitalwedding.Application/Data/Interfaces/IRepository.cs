using System;
namespace digitalwedding.Application.Data.Interfaces
{
	public interface IRepository<T> where T: class
	{
        IQueryable<T> Entity { get; }

        IQueryable<T> GetAll();

        Task<T> GetByIdAsync(string id);

        Task<T> AddAsync(T entity);

        void AddRange(IEnumerable<T> consents);

        T Update(T entity);

        void Delete(T entity);
    }
}

