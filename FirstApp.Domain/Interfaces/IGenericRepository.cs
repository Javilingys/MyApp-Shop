﻿using FirstApp.Domain.Entities;
using FirstApp.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp.Domain.Interfaces
{
    public interface IGenericRepository<T> where T: BaseEntity
    {
        // Read Entity
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);

        // Updating синхронные, потому что не взаимодействуют на прямую с бд.
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
