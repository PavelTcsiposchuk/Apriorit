using EmployeeManagmentService.Data.Contexts;
using EmployeeManagmentService.Data.Models;
using EmployeeManagmentService.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagmentService.Data.Repositories.Implementation
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {

        public EmployeeRepository(ApplicationContext context) : base(context)
        {

        }
        public EmployeePositions GetLastPosition(int id)
        {
            return _context.Set<Employee>()
                .Include(e => e.EmployeePositions.FirstOrDefault(p => p.DateOfDissmisal == null))
                .ThenInclude(e=>e.Position).FirstOrDefault(e=> e.Id == id).EmployeePositions.FirstOrDefault();
        }
    

    }
}
