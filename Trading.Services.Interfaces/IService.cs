namespace Trading.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Trading.Domain.Interfaces;

    public interface IService<T> where T : class, IEntity
    {
        Task<IList<T>> GetAllAsync();

        Task<T> GetIdAsync(int id);

        Task<T> AddAsync(T item);

        Task<T> UpdateAsync(T id);
    }
}
