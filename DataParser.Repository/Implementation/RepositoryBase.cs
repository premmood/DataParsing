using DataParser.Repository.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace DataParser.Repository
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private ClaimContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;
        protected DbSet<TEntity> DbSet
        {
            get
            {
                return _dbContext.Set<TEntity>();
            }
        }

        public RepositoryBase()
        {
            this._dbContext = new ClaimContext();
            _dbSet = this._dbContext.Set<TEntity>();
        }

        public IEnumerable<TEntity> All()
        {
            return DbSet.AsEnumerable<TEntity>().ToList();
        }

        public bool Contains(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Count(predicate) > 0;
        }

        public int Create(TEntity tEntity)
        {
            var newEntry = DbSet.Add(tEntity);
            int id = this._dbContext.SaveChanges();
            return id;
        }

        public void Truncate()
        {
            _dbSet.RemoveRange(_dbSet);
            this._dbContext.SaveChanges();
        }

        public void Delete(object id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (this._dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }

        public void Dispose()
        {
            if (this._dbContext != null)
            {
                this._dbContext.Dispose();
            }
        }

        public TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public virtual TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }
    
        public virtual void Update(TEntity entityToUpdate)
        {
            this._dbContext.Entry(entityToUpdate).State = EntityState.Modified;
            this._dbContext.SaveChanges();
        }

        public void ExecWithStoreProcedure(string query, params object[] parameters)
        {
            this._dbContext.Database.SetCommandTimeout((int)TimeSpan.FromMinutes(20).TotalSeconds);
            if (parameters != null && parameters.Length > 0) 
            this._dbContext.Database.ExecuteSqlRaw(query, parameters);

            else
                this._dbContext.Database.ExecuteSqlRaw(query);
        }
       


        public  IEnumerable<object> ExecStoreProcedureForResult(string query, params object[] parameters)
        {
            IDbDataParameter[] dbDataParameters = (IDbDataParameter[])((SqlParameter[])parameters);
            List<response_file> response_Files  = new List<response_file>();
            {
                DbCommand cmd = _dbContext
                .LoadStoredProc(query)
                .WithSqlParams(dbDataParameters);
                response_Files =  cmd.ExecuteStoredProc<response_file>();
            }
            return response_Files;
        }

    

   
    }

}
