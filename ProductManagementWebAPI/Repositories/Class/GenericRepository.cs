using ProductManagementWebAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository.Repositories.Class
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        readonly DataContext db;
        readonly DbSet<T> _entities;


        public GenericRepository(DataContext database)
        {
            db = database;
            _entities = db.Set<T>();
        }
        public async Task<bool> DeleteModel(int id)
        {

            var data = await _entities.FindAsync(id);
            if (data == null)
            {
                return false;
            }
            _entities.Remove(data);
            return true;
        }

        public async Task<T> FindByOptions(Expression<Func<T, bool>> predicate)
        {
            var data = await _entities.FirstOrDefaultAsync(predicate);

            return data;
        }

        public async Task<IEnumerable<T>> GetModel()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetModelById(int id)
        {
            var data = await _entities.FindAsync(id);
            if (data == null) { return null; }
            else
                return data;
        }

        public async Task InsertModel(T Model)
        {
            var data = await _entities.AddAsync(Model);


        }

        public async Task<bool> Save()
        {
            var check = await db.SaveChangesAsync();

            if (check > 0)
            {
                return true;
            }
            return false;
        }

        public void UpdateModel(T Model)
        {

            //db.Entry(Model).State = EntityState.Modified;
            _entities.Update(Model);


        }

        public async Task UpdateModelPatch(int id, JsonPatchDocument Model)
        {
            var data = await _entities.FindAsync(id);

            if (data != null)
            {
                Model.ApplyTo(data);
            }
        }
    }
}
