using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.DataLayer.Interfaces
{
    interface IDataAccess<T>
    {
        /// <summary>
        /// Add entity to the repository
        /// </summary>
        /// <param name="entity">the entity to add</param>
        void Insert(T entity);

        /// <summary>
        /// Mark entity to be deleted within the repository
        /// </summary>
        /// <param name="entity">The entity to delete</param>
        void Delete(T entity);

        /// <summary>
        /// Updates entity within the the repository
        /// </summary>
        /// <param name="entity">the entity to update</param>
        void Attach(T entity);
    }
}
