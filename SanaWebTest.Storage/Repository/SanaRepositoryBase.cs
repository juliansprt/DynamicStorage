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
    /// Abstract implementation of a repository
    /// </summary>
    /// <typeparam name="tEntity"></typeparam>
    /// <typeparam name="tPrimaryKey"></typeparam>
    public abstract class SanaRepositoryBase<tEntity, tPrimaryKey> : IRepository<tEntity, tPrimaryKey>
        where tEntity : class, IEntity<tPrimaryKey>
    {

        public abstract void Delete(tPrimaryKey entity);

        public virtual Task DeleteAsync(tPrimaryKey entity)
        {
            Delete(entity);
            return Task.CompletedTask;
        }

        public virtual tEntity FirstOrDefault(tPrimaryKey id)
        {
            return GetAll().FirstOrDefault(CreateEqualityExpressionForId(id));
        }

        public virtual tEntity FirstOrDefault(Expression<Func<tEntity, bool>> predicate)
        {
            return GetAll().FirstOrDefault(predicate);
        }

        public virtual Task<tEntity> FirstOrDefaultAsync(tPrimaryKey id)
        {
            return Task.FromResult(FirstOrDefault(id));
        }

        public virtual Task<tEntity> FirstOrDefaultAsync(Expression<Func<tEntity, bool>> predicate)
        {
            return Task.FromResult(FirstOrDefault(predicate));
        }

        public virtual tEntity Get(tPrimaryKey id)
        {
            var entity = FirstOrDefault(id);
            if (entity == null)
                throw new Exception($"Entity not found: {typeof(tEntity).Name}");
            return entity;
        }



        public virtual async Task<tEntity> GetAsync(tPrimaryKey id)
        {
            var entity = await FirstOrDefaultAsync(id);
            if (entity == null)
                throw new Exception($"Entity not found: {typeof(tEntity).Name}");
            return entity;
        }

        public abstract IQueryable<tEntity> GetAll();

        public abstract Task<IQueryable<tEntity>> GetAllAsync();


        public abstract tEntity Insert(tEntity entity);

        public virtual Task<tEntity> InsertAsync(tEntity entity)
        {
            return Task.FromResult(Insert(entity));
        }

        public virtual T Query<T>(Func<IQueryable<tEntity>, T> query)
        {
            return query(GetAll());
        }

        public abstract tEntity Update(tEntity entity);

        public virtual Task<tEntity> UpdateAsync(tEntity entity)
        {
            return Task.FromResult(Update(entity));
        }



        /// <summary>
        /// Equality comparer via primary key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected virtual Expression<Func<tEntity, bool>> CreateEqualityExpressionForId(tPrimaryKey id)
        {
            var lambdaParam = Expression.Parameter(typeof(tEntity));

            var leftExpression = Expression.PropertyOrField(lambdaParam, "Id");

            var idValue = Convert.ChangeType(id, typeof(tPrimaryKey));

            Expression<Func<object>> closure = () => idValue;
            var rightExpression = Expression.Convert(closure.Body, leftExpression.Type);

            var lambdaBody = Expression.Equal(leftExpression, rightExpression);

            return Expression.Lambda<Func<tEntity, bool>>(lambdaBody, lambdaParam);


        }

    }
}
