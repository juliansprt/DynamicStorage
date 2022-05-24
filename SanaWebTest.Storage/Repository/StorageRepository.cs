using Microsoft.Extensions.DependencyInjection;
using SanaWebTest.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SanaWebTest.Storage.Repository
{

    /// <summary>
    /// This repository encapsulate all Storage types
    /// </summary>
    /// <typeparam name="tEntity"></typeparam>
    /// <typeparam name="tPrimaryKey"></typeparam>
    public class StorageRepository<tEntity, tPrimaryKey> : IRepository<tEntity, tPrimaryKey>
        where tEntity : class, IEntity<tPrimaryKey>
    {

        protected readonly IStorageContainer _container;

        protected readonly IRepository<tEntity, tPrimaryKey> _repository;

        public StorageRepository(IStorageContainer container, IServiceProvider serviceProvider)
        {
            _container = container;
            Type currentRepo = container.GetCurrent();
            if (currentRepo == null)
                throw new Exception("You must set a repository storage");

            
            //Get current repository to work
            _repository = (IRepository<tEntity, tPrimaryKey>)serviceProvider.GetService(currentRepo.MakeGenericType(typeof(tEntity)));

        }

        public virtual void Delete(tPrimaryKey entity)
        {
            _repository.Delete(entity);
        }

        public virtual Task DeleteAsync(tPrimaryKey entity)
        {
            return _repository.DeleteAsync(entity);
        }

        public virtual tEntity FirstOrDefault(tPrimaryKey id)
        {
            return _repository.FirstOrDefault(id);
        }

        public virtual tEntity FirstOrDefault(Expression<Func<tEntity, bool>> predicate)
        {
            return _repository.FirstOrDefault(predicate);
        }

        public virtual Task<tEntity> FirstOrDefaultAsync(tPrimaryKey id)
        {
            return _repository.FirstOrDefaultAsync(id);
        }

        public virtual Task<tEntity> FirstOrDefaultAsync(Expression<Func<tEntity, bool>> predicate)
        {
            return _repository.FirstOrDefaultAsync(predicate);
        }

        public virtual tEntity Get(tPrimaryKey id)
        {
            return _repository.Get(id);
        }

        public virtual IQueryable<tEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual Task<IQueryable<tEntity>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public virtual Task<tEntity> GetAsync(tPrimaryKey id)
        {
            return _repository.GetAsync(id);
        }

        public virtual tEntity Insert(tEntity entity)
        {
            return _repository.Insert(entity);
        }

        public virtual Task<tEntity> InsertAsync(tEntity entity)
        {
            return _repository.InsertAsync(entity);
        }

        public virtual T Query<T>(Func<IQueryable<tEntity>, T> query)
        {
            return _repository.Query<T>(query); 
        }

        public virtual tEntity Update(tEntity entity)
        {
            return _repository.Update(entity);  
        }

        public virtual Task<tEntity> UpdateAsync(tEntity entity)
        {
            return _repository.UpdateAsync(entity);
        }
    }
}
