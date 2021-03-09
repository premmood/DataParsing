using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataParser.Repository
{
   public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        //Gets all objects from database
        IEnumerable<TEntity> All();

        // Get the object by id, but it does not go all the way to db
        TEntity GetById(object id);

        // Find object by specified expression.
        TEntity Find(Expression<Func<TEntity, bool>> predicate);

        // Create a new object to database.
        int Create(TEntity tEntity);

        // Call proc returns void
        void ExecWithStoreProcedure(string query, params object[] parameters);

        // Call proc returns table
        IEnumerable<object> ExecStoreProcedureForResult(string query, params object[] parameters);

        // Truncate  table
        void Truncate();

        // Deletes an object acc. to Id
        void Delete(object id);

        // Delete an object passed
        void Delete(TEntity entityToDelete);

        // Updates an object passed
        void Update(TEntity entityToUpdate);

        // Gets the object(s) is exists in database by specified filter.
        bool Contains(Expression<Func<TEntity, bool>> predicate);

       


    }
}
