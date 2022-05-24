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
    /// A contract of a repository functions, with dynamic primary key
    /// </summary>
    /// <typeparam name="tEntity"></typeparam>
    /// <typeparam name="tPrimaryKey"></typeparam>
    public interface IRepository<tEntity, tPrimaryKey> : IRepository
        where tEntity : class, IEntity<tPrimaryKey>
    {

        IQueryable<tEntity> GetAll();

        Task<IQueryable<tEntity>> GetAllAsync();

        T Query<T>(Func<IQueryable<tEntity>, T> query);


        tEntity Get(tPrimaryKey id);


        Task<tEntity> GetAsync(tPrimaryKey id);


        tEntity Insert(tEntity entity);

        Task<tEntity> InsertAsync(tEntity entity);


        tEntity Update(tEntity entity);

        Task<tEntity> UpdateAsync(tEntity entity);


        void Delete(tPrimaryKey entity);

        Task DeleteAsync(tPrimaryKey entity);


        tEntity FirstOrDefault(tPrimaryKey id);

        Task<tEntity> FirstOrDefaultAsync(tPrimaryKey id);


        tEntity FirstOrDefault(Expression<Func<tEntity, bool>> predicate);

        Task<tEntity> FirstOrDefaultAsync(Expression<Func<tEntity, bool>> predicate);



    }
}
