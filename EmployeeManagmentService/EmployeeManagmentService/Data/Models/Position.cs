using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagmentService.Data.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string PositionName { get; set; }
        public IList<EmployeePositions> EmployeePositions { get; set; }
    }
}
