using System.Collections.Generic;
using CRUD.DataLayer.Entities;

namespace CRUD.BusinessLayer.Interfaces
{
    public interface IEmployee
    {
        IEnumerable<EmployeeInfo> EmployeeGet();
        string EmployeeInsert(EmployeeInfo emp);
        string EmployeeUpdate(EmployeeInfo emp);
        string EmployeeDelete(int id);
    }
}
