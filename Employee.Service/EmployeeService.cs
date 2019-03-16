using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee.Core.Data;
using Employee.Data;

namespace Employee.Service
{
    public class EmployeeService : IEmployeeService
    {
        private IRepository<Employeee> empRepository;
        private IRepository<Address> addressRepository;

        public EmployeeService(IRepository<Employeee> empRepository, IRepository<Address> addressRepository)
        {
            this.empRepository = empRepository;
            this.addressRepository = addressRepository;
        }

        public IQueryable<Employeee> GetEmployees()
        {
            return empRepository.Table;
        }

        public Employeee GetEmployee(long id)
        {
            return empRepository.GetById(id);
        }

        public void InsertEmployee(Employeee emp)
        {
            empRepository.Insert(emp);
        }

        public void UpdateEmployee(Employeee emp)
        {
            empRepository.Update(emp);
        }

        public void DeleteEmployee(Employeee emp)
        {
            addressRepository.Delete(emp.Address);
            empRepository.Delete(emp);
        }
    }
}
