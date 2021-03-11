using FirstApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Количество изменений</returns>
        Task<int> CompleteAsync();
    }
}
