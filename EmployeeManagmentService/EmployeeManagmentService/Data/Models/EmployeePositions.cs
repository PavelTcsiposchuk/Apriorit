using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagmentService.Data.Models
{
    public class EmployeePositions
    {
        public DateTime HireDate { get; set; }
        public DateTime? DateOfDissmisal { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public Position Position { get; set; }
        public int PositionId { get; set; }
    }
}
