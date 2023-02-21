using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetModel();

        Task<T> GetModelById(int id);

        Task InsertModel(T Model);

        void UpdateModel(T Model);

        Task<bool> DeleteModel(int id);

        Task<T> FindByOptions(Expression<Func<T, bool>> predicate);

        Task UpdateModelPatch(int id, JsonPatchDocument Model);

        Task<bool> Save();

    }
}
