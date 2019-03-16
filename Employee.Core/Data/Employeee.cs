using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.Data
{
    public class Employeee : BaseEntity
    {
        public string EmpName { get; set; }
        public string EmpCode { get; set; }
        public int Age { get; set; }
        public virtual Address Address { get; set; }
    }
}
