using CRUD.BusinessLayer.Interfaces;
using System.Collections.Generic;
using System.Linq;
using CRUD.DataLayer.Entities;
using CRUD.DataLayer.Implementation;


namespace CRUD.BusinessLayer.Implementation
{
    public class Employee : IEmployee
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        private List<EmployeeInfo> lstEmp = new List<EmployeeInfo>();
        private EmployeeInfo objEmp = new EmployeeInfo();
        public IEnumerable<EmployeeInfo> EmployeeGet()
        {
            lstEmp = unitOfWork.GetEmployeeRepository.Get().ToList();

            return lstEmp;
        }

        public string EmployeeUpdate(EmployeeInfo emp)
        {

            objEmp = unitOfWork.GetEmployeeRepository.GetByID(emp.EmployeeNo);

            if(objEmp !=null)
            {
                objEmp.FirstName = emp.FirstName;
                objEmp.LastName = emp.LastName;
                objEmp.Address = emp.Address;
                objEmp.MobileNo = emp.MobileNo;
                objEmp.PostelCode = emp.PostelCode;
                objEmp.EmailId = emp.EmailId;
            }
            this.unitOfWork.GetEmployeeRepository.Attach(objEmp);
            int result = this.unitOfWork.Save();

            if(result > 0)
            {
                return "Sucessfully updated of employee records";
            }
            else
            {
                return "Updation faild";
            }
        }

        public string EmployeeDelete(int id)
        {
            var objEmp = this.unitOfWork.GetEmployeeRepository.GetByID(id);
            this.unitOfWork.GetEmployeeRepository.Delete(objEmp);
            int deleteData = this.unitOfWork.Save();
            if(deleteData > 0)
            {
                return "Successfully deleted of employee records";
            }
            else
            {
                return "Deletion faild";
            }
        }

        public string EmployeeInsert(EmployeeInfo emp)
        {
         this.unitOfWork.GetEmployeeRepository.Insert(emp);
            int inserData =this.unitOfWork.Save();

            if(inserData > 0)
            {
                return "Successfully Inserted of employee records";
            }
            else
            {
                return "Insertion faild";
            }
        }
    }
}
