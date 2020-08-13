using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagmentService.DTO
{
    public class EmployeeDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal Salary { get; set; }
        public string PositionName { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? DateOfDissmisal { get; set; }
    }
}
