using SanaWebTest.Storage.Entities;
using SanaWebTest.Storage.InMemory.Helper;
using SanaWebTest.Storage.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanaWebTest.Storage.InMemory.Repository
{

    /// <summary>
    /// Implementation of repository to use a In Memory Storage
    /// </summary>
    /// <typeparam name="tEntity"></typeparam>
    /// <typeparam name="tPrimaryKey"></typeparam>
    public class MemoryRepository<tEntity, tPrimaryKey> : SanaRepositoryBase<tEntity, tPrimaryKey>, IMemoryRepository<tEntity, tPrimaryKey>
        where tEntity : class, IEntity<tPrimaryKey>
    {

        public virtual MemoryDatabase Database { get => _memoryDatabaseProvider.Database; }

        public virtual List<tEntity> Table { get => Database.Set<tEntity>(); }

        private readonly IMemoryDatabaseProvider _memoryDatabaseProvider;
        private readonly PrimaryKeyGenerator<tPrimaryKey> _primaryKeyGenerator;

        
        

        public MemoryRepository(IMemoryDatabaseProvider databaseProvider)
        {
            _memoryDatabaseProvider = databaseProvider;
            _primaryKeyGenerator = new PrimaryKeyGenerator<tPrimaryKey>();
        }

        public override void Delete(tPrimaryKey entity)
        {
            var index = Table.FindIndex(p => EqualityComparer<tPrimaryKey>.Default.Equals(p.Id, entity));
            if (index >= 0)
                Table.RemoveAt(index);
        }

        public override IQueryable<tEntity> GetAll()
        {
            return Table.AsQueryable();
        }

        public override Task<IQueryable<tEntity>> GetAllAsync()
        {
            return Task.FromResult(Table.AsQueryable());
        }

        public override tEntity Insert(tEntity entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.Id = _primaryKeyGenerator.GetNext();
            Table.Add(entity);
            return entity;
        }

        public override tEntity Update(tEntity entity)
        {
            entity.UpdateDate = DateTime.Now;
            var index = Table.FindIndex(p => EqualityComparer<tPrimaryKey>.Default.Equals(p.Id, entity.Id));
            if (index >= 0)
                Table[index] = entity;
            return entity;
        }
    }
}
