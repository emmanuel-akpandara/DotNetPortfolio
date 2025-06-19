using System.Linq.Expressions;

namespace Adventures.Infrastructure
{
	public interface IRepository<T>
	{

        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIDAsync(int id);
        void Insert(T obj);
        void Delete(int id);
        void Update(T obj);
    }
}
