using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;


using Dal.Core.Interfaces;
using Dal.Core.Interfaces.Entity;

namespace Dal.Core
{
    /// <summary>
    /// Provides CRUD actions with <typeparamref name="TEntity"/>
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class EntityRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, IKeyable<TKey>
    {
        private IEntitiesDbContext m_DbContext;
        private bool m_IsDisposed;
        public event DisposeMe DisposeMe;

        public EntityRepository(IEntitiesDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        protected IDbSet<TEntity> DbEntitySet { get; private set; }

        public IEntitiesDbContext DbContext
        {
            get { return m_DbContext; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(DbContext));

                this.m_DbContext = value;
                this.DbEntitySet = value.TryGetSet<TEntity, TKey>();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!m_IsDisposed && disposing)
            {
                DisposeMe(typeof(TEntity).Name);
                // DbContext.Dispose();
            }
            m_IsDisposed = true;
        }

        public Task<bool> ContainsAsync(TEntity entity)
        {
            return Task.Run(() => DbEntitySet.FirstOrDefault(p => p.Id.Equals(entity.Id)) != null);
        }
        public TEntity Find(params Object[] keyValues)
        {
            return DbEntitySet.Find(keyValues);
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return DbEntitySet.ToListAsync();
        }
        public List<TEntity> GetAll()
        {
            return DbEntitySet.ToList();

        }

        public Task<List<TEntity>> GetWhereAsync(Func<TEntity, bool> predicate)
        {
            return Task.Run(() => DbEntitySet.Where(predicate).ToList());
        }
        public List<TEntity> GetWhere(string sql, params object[] parameters)
        {
            return DbContext.Database.SqlQuery<TEntity>(sql, parameters).ToList();
        }
        public List<TEntity> GetWhere(Func<TEntity, bool> predicate)
        {
            return DbEntitySet.Where(predicate).ToList();

        }

        public Task<TEntity> FindByIdAsync(TKey id)
        {
            return DbEntitySet.FirstOrDefaultAsync(p => p.Id.ToString().Equals(id.ToString()));
        }

        public async Task CreateAsync(TEntity entity)
        {
            DbContext.AddEntity<TEntity, TKey>(entity);
            await SaveChangesAsync();
        }

        public void Create(TEntity entity)
        {
            DbContext.AddEntity<TEntity, TKey>(entity);
            SaveChanges();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            DbContext.UpdateEntity<TEntity, TKey>(entity);
            await SaveChangesAsync();
        }
        public void Update(TEntity entity)
        {
            DbContext.UpdateEntity<TEntity, TKey>(entity);
            SaveChanges();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            DbContext.DeleteEntity<TEntity, TKey>(entity);
            await SaveChangesAsync();

        }
        public async Task DeleteAsync(TKey entityId)
        {
            TEntity entity = DbEntitySet.FirstOrDefault(p => p.Id.ToString().Equals(entityId.ToString()));
            await DeleteAsync(entity);
            await SaveChangesAsync();
        }
        public TEntity GetFirstOrDefault(Func<TEntity, bool> predicate)
        {
            return DbEntitySet.FirstOrDefault(predicate);
        }
        public int SaveChanges()
        {
            return DbContext.SaveChanges();
        }
        public Task<int> SaveChangesAsync()
        {
            return DbContext.SaveChangesAsync();
        }

        public TEntity GetSingleOrDefault(Func<TEntity, bool> predicate)
        {
            return DbEntitySet.SingleOrDefault(predicate);
        }
        public void RemoveRange(TKey[] ids)
        {
            if (ids == null) return;
            RemoveRange(GetWhere(x => ids.Contains(x.Id)));
        }
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            var ent = entities.ToArray();
            for (int i = 0; i < ent.Length; i++)
            {
                DbEntitySet.Remove(ent[i]);
            }
            SaveChanges();
        }
        public void Remove(TEntity entity)
        {
            DbEntitySet.Remove(entity);
            SaveChanges();
        }
        public IQueryable<TEntity> Include(string path)
        {
            return DbEntitySet.Include(path);
        }
        public TEntity GetFirst(Func<TEntity, bool> predicate)
        {
            return DbEntitySet.First(predicate);
        }

        public bool Any(Func<TEntity, bool> predicate)
        {
            return DbEntitySet.Any(predicate);
        }
    }
}