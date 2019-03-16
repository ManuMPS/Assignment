using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee.Core.Data;

namespace Employee.Service
{
    public interface IEmployeeService
    {
        IQueryable<Employeee> GetEmployees();
        Employeee GetEmployee(long id);
        void InsertEmployee(Employeee emp);
        void UpdateEmployee(Employeee emp);
        void DeleteEmployee(Employeee emp);
    }
}
