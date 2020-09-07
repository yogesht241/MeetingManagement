using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD.DataLayer.Entities;

namespace CRUD.DataLayer.Implementation
{

    /// <summary>
    /// The UnitOfWork class designed for binding classes to generic class DataAccess. This class is the conversion or binding class
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class UnitOfWork : IDisposable
    {
        /// <summary>
        /// Stores the string error message
        /// </summary>
        private string errorMessage = string.Empty;

        /// <summary>
        /// Defines condition for disposing object
        /// </summary>
        private bool disposed = false;

        private DataAccess<EmployeeInfo> employeeInfoRepository;

        /// <summary>
        /// Initializes a new instance of the MyModel class
        /// </summary>
        private MyModel objMyModel = new MyModel();


        /// <summary>
        /// Gets the get employee repository.
        /// </summary>
        /// <value>
        /// The get employee repository.
        /// </value>
        public DataAccess<EmployeeInfo> GetEmployeeRepository
        {
            get
            {
                if (this.employeeInfoRepository == null)
                {
                    this.employeeInfoRepository = new DataAccess<EmployeeInfo>(this.objMyModel);
                }

                return this.employeeInfoRepository;
            }
        }


        /// <summary>
        /// This Method will commit the changes to database for the permanent save
        /// </summary>
        /// <returns>
        /// affected rows
        /// </returns>
        public int Save()
        {
            return this.objMyModel.SaveChanges();
        }
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }


        /// <summary>
        /// This method will dispose the context class object after the uses of that object
        /// </summary>
        /// <param name="disposing">parameter true or false for disposing database object</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.objMyModel.Dispose();
                }
            }

            this.disposed = true;
        }
    }
}
