using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Employee.Core.Data;
using Employee.Data;
using Employee.Service;
using EmployeeCRUD.Models;

namespace Employee.API.Controllers
{
    public class EmpAPIController : ApiController
    {
        private IEmployeeService employeeService;

        public EmpAPIController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public IHttpActionResult Get()
        {
            IEnumerable<EmployeeModel> employees = employeeService.GetEmployees().Select(u => new EmployeeModel
            {
                EmpName = u.EmpName,
                EmpCode = u.EmpCode,
                Age = u.Age,
                Address1 = u.Address.Address1,
                Address2 = u.Address.Address2,
                Pincode = u.Address.Pincode,
                ID = u.ID
            });

            if (employees.Count() == 0)
            {
                return NotFound();
            }
            return Ok(employees);
        }

        public IHttpActionResult Get(int? id)
        {
            EmployeeModel model = new EmployeeModel();
            if (id.HasValue && id != 0)
            {
                Employeee empEntity = employeeService.GetEmployee(id.Value);
                model.EmpName = empEntity.EmpName;
                model.EmpCode = empEntity.EmpCode;
                model.Age = empEntity.Age;
                model.Address1 = empEntity.Address.Address1;
                model.Address2 = empEntity.Address.Address2;
                model.Pincode = empEntity.Address.Pincode;
            }
            return Ok(model);
        }

        public IHttpActionResult Post(EmployeeModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Data");

            if (model.ID == 0)
            {
                Employeee empEntity = new Employeee
                {
                    EmpName = model.EmpName,
                    EmpCode = model.EmpCode,
                    Age = model.Age,
                    AddedDate = DateTime.UtcNow,
                    ModifiedDate = DateTime.UtcNow,
                    Address = new Address
                    {
                        Address1 = model.Address1,
                        Address2 = model.Address2,
                        Pincode = model.Pincode,
                        AddedDate = DateTime.UtcNow,
                        ModifiedDate = DateTime.UtcNow
                    }
                };
                employeeService.InsertEmployee(empEntity);
            }
            return Ok();
        }

        public IHttpActionResult Put(EmployeeModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            Employeee empEntity = employeeService.GetEmployee(model.ID);
            empEntity.EmpName = model.EmpName;
            empEntity.EmpCode = model.EmpCode;
            empEntity.Age = model.Age;
            empEntity.ModifiedDate = DateTime.UtcNow;
            empEntity.Address.Address1 = model.Address1;
            empEntity.Address.Address2 = model.Address2;
            empEntity.Address.Pincode = model.Pincode;
            empEntity.Address.ModifiedDate = DateTime.UtcNow;
            employeeService.UpdateEmployee(empEntity);
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            if (id != 0)
            {
                Employeee empEntity = employeeService.GetEmployee(id);
                employeeService.DeleteEmployee(empEntity);
            }
            return Ok();
        }
    }
}
