using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        /// <summary>
        /// Save all changes to database
        /// </summary>
        /// <returns>Count of modified things</returns>
        Task<int> CompleteAsync();
    }
}
