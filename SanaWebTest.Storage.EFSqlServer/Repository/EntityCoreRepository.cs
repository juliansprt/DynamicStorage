using Microsoft.EntityFrameworkCore;
using SanaWebTest.Storage.Entities;
using SanaWebTest.Storage.Helper;
using SanaWebTest.Storage.Repository;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SanaWebTest.Storage.EFSqlServer.Repository
{
    /// <summary>
    /// Implementation of Repository using Entity Framework
    /// </summary>
    /// <typeparam name="tContext"></typeparam>
    /// <typeparam name="tEntity"></typeparam>
    /// <typeparam name="tPrimaryKey"></typeparam>
    public class EntityCoreRepository<tContext, tEntity, tPrimaryKey> : SanaRepositoryBase<tEntity, tPrimaryKey>, IRepositoryWithDbContext, IEFSqlServerRepository<tEntity, tPrimaryKey>
        where tEntity : class, IEntity<tPrimaryKey>
        where tContext : DbContext
    {

        private readonly IDbContextProvider<tContext> _dbContextProvider;


        private static readonly ConcurrentDictionary<Type, bool> EntityIsDbQuery =
            new ConcurrentDictionary<Type, bool>();

        public EntityCoreRepository(IDbContextProvider<tContext> dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }


        public virtual tContext GetContext()
        {
            return _dbContextProvider.GetDbContext();
        }

        public virtual async Task<tContext> GetContextAsync()
        {
            return await _dbContextProvider.GetDbContextAsync();
        }

        public override void Delete(tPrimaryKey id)
        {
            var entity = GetFromChangeTrackerOrNull(id);
            if(entity != null)
            {
                Delete(entity);
            }
            else
            {
                entity = FirstOrDefault(id);
                if(entity != null)
                {
                    Delete(entity);
                }
            }
        }

        public virtual void Delete(tEntity entity)
        {
            AttachIfNot(entity);
            GetTable().Remove(entity);
            GetContext().SaveChanges();
        }

        public override IQueryable<tEntity> GetAll()
        {
            return GetAllIncluding();
        }

        public override async Task<IQueryable<tEntity>> GetAllAsync()
        {
            return await GetAllIncludingAsync();
        }

        public DbContext GetDbContext()
        {
            return GetContext();
        }

        public async Task<DbContext> GetDbContextAsync()
        {
            return await GetContextAsync();
        }

        public override tEntity Insert(tEntity entity)
        {
            entity.CreateDate = DateTime.Now;
            var entityInsert = GetTable().Add(entity).Entity;
            GetContext().SaveChanges();
            return entityInsert;
        }

        public override tEntity Update(tEntity entity)
        {
            entity.UpdateDate = DateTime.Now;
            AttachIfNot(entity);
            GetContext().Entry(entity).State = EntityState.Modified;
            GetContext().SaveChanges();
            return entity;
        }


        public virtual DbSet<tEntity> GetTable()
        {
            var context = GetContext();
            return context.Set<tEntity>();
        }

        public virtual async Task<DbSet<tEntity>> GetTableAsync()
        {
            var context = await GetContextAsync();
            return context.Set<tEntity>();
        }

        private tEntity GetFromChangeTrackerOrNull(tPrimaryKey id)
        {
            var entry = GetContext().ChangeTracker.Entries()
                .FirstOrDefault(p =>
                    p.Entity is tEntity && EqualityComparer<tPrimaryKey>.Default.Equals(id, (p.Entity as tEntity).Id));
            return entry?.Entity as tEntity;
        }

        protected   virtual void AttachIfNot(tEntity entity)
        {
            var entry = GetContext().ChangeTracker.Entries().FirstOrDefault(p => p.Entity == entity);
            if (entry != null)
                return;
            GetTable().Attach(entity);
            
        }

        public virtual IQueryable<tEntity> GetAllIncluding(params Expression<Func<tEntity, object>>[] selectors)
        {
            var query = GetQueryable();

            if (selectors == null || (selectors?.Length ?? 0) <= 0)
            {
                return query;
            }

            foreach (var property in selectors)
            {
                query = query.Include(property);
            }

            return query;

        }

        public virtual async Task<IQueryable<tEntity>> GetAllIncludingAsync(params Expression<Func<tEntity, object>>[] selector)
        {
            var query = await GetQueryableAsync();
            if(selector == null || (selector?.Length ?? 0) <= 0)
            {
                return query;
            }
            foreach (var item in selector)
            {
                query = query.Include(item);
            }
            return query;
        }

        public virtual DbSet<tEntity> GetDbQueryTable()
        {
            return GetContext().Set<tEntity>();
        }

        protected virtual IQueryable<tEntity> GetQueryable()
        {
            if (EntityIsDbQuery.GetOrAdd(typeof(tEntity), key => GetContext().GetType().GetProperties().Any(property =>
                ReflectionHelper.IsAssignableToGenericType(property.PropertyType, typeof(DbSet<>)) &&
                ReflectionHelper.IsAssignableToGenericType(property.PropertyType.GenericTypeArguments[0],
                    typeof(IEntity<>)) &&
                property.PropertyType.GetGenericArguments().Any(x => x == typeof(tEntity)))))
            {
                return GetDbQueryTable().AsQueryable();
            }

            return GetTable().AsQueryable();
        }


        public virtual async Task<DbSet<tEntity>> GetDbQueryTableAsync()
        {
            return (await GetContextAsync()).Set<tEntity>();
        }
        protected virtual async Task<IQueryable<tEntity>> GetQueryableAsync()
        {
            if (EntityIsDbQuery.GetOrAdd(typeof(tEntity), key => GetContext().GetType().GetProperties().Any(property =>
                ReflectionHelper.IsAssignableToGenericType(property.PropertyType, typeof(DbSet<>)) &&
                ReflectionHelper.IsAssignableToGenericType(property.PropertyType.GenericTypeArguments[0],
                    typeof(IEntity<>)) &&
                property.PropertyType.GetGenericArguments().Any(x => x == typeof(tEntity)))))
            {
                return (await GetDbQueryTableAsync()).AsQueryable();
            }

            return (await GetTableAsync()).AsQueryable();
        }
    }
}
