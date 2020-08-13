using EmployeeManagmentService.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagmentService.Data.Repositories.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        EmployeePositions GetLastPosition(int id);
    }
}
