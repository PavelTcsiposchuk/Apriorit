using EmployeeManagmentService.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagmentService.Data.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<EmployeePositions> EmployeePositions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            
            modelBuilder.Entity<EmployeePositions>().HasKey(ep => new { ep.EmployeeId, ep.PositionId });

            modelBuilder.Entity<EmployeePositions>()
           .HasOne(e => e.Employee)
           .WithMany(ep => ep.EmployeePositions)
           .HasForeignKey(sc => sc.EmployeeId);

            modelBuilder.Entity<EmployeePositions>()
                .HasOne(p => p.Position)
                .WithMany(ep => ep.EmployeePositions)
                .HasForeignKey(p => p.PositionId);

            #region SeedPosition
            modelBuilder.Entity<Position>().HasData(
                new Position()
                {
                    Id = 1,
                    PositionName = "Middle dev"
                },
                new Position()
                {
                    Id = 2,
                    PositionName = "Junior dev"
                },
                new Position()
                {
                    Id = 3,
                    PositionName = "Junior QA"
                },
                new Position()
                {
                    Id = 4,
                    PositionName = "Middle QA"
                },
                new Position()
                {
                    Id = 5,
                    PositionName = "Team lead"
                },
                new Position()
                {
                    Id = 6,
                    PositionName = "PM"
                }
                );
            #endregion
            #region EmployeeSeed
            modelBuilder.Entity<Employee>().HasData(
                new Employee()
                { 
                    Id = 1,
                    Name = "Alex",
                    Surname = "Papirnyk",
                    Salary = 500
                },
                new Employee()
                {
                    Id = 2,
                    Name = "Vitaliy",
                    Surname = "Tsal",
                    Salary = 1000
                },
                new Employee()
                {
                    Id = 3,
                    Name = "Bohdan",
                    Surname = "Chornobrovkin",
                    Salary = 1500
                },
                new Employee()
                {
                    Id = 4,
                    Name = "Dmitry",
                    Surname = "Pikalo",
                    Salary = 300
                },
                new Employee()
                {
                    Id = 5,
                    Name = "Ann",
                    Surname = "Ageeva",
                    Salary = 500
                }
                );
            #endregion EmployeeSeed

            #region EmployeePositionsSeed
            modelBuilder.Entity<EmployeePositions>().HasData(
                new EmployeePositions() 
                { 
                    HireDate = new DateTime(2019,10,1),
                    DateOfDissmisal = new DateTime(2020,3,27),
                    EmployeeId = 1,
                    PositionId = 2
                },
                new EmployeePositions()
                {
                    HireDate = new DateTime(2020, 8, 12),
                    DateOfDissmisal = null,
                    EmployeeId = 1,
                    PositionId = 1
                },
                new EmployeePositions()
                {
                    HireDate = new DateTime(2019, 10, 1),
                    DateOfDissmisal = new DateTime(2020, 3, 27),
                    EmployeeId = 2,
                    PositionId = 1
                },
                new EmployeePositions()
                {
                    HireDate = new DateTime(2020, 8, 12),
                    DateOfDissmisal = null,
                    EmployeeId = 2,
                    PositionId = 3
                },
                new EmployeePositions()
                {
                    HireDate = new DateTime(2019, 10, 1),
                    DateOfDissmisal = new DateTime(2020, 3, 27),
                    EmployeeId = 3,
                    PositionId = 5
                },
                new EmployeePositions()
                {
                    HireDate = new DateTime(2020, 8, 11),
                    DateOfDissmisal = new DateTime(2020, 8, 12),
                    EmployeeId = 3,
                    PositionId = 6
                }, 
                new EmployeePositions()
                {
                    HireDate = new DateTime(2020, 3, 11),
                    DateOfDissmisal = new DateTime(2020, 5, 12),
                    EmployeeId = 4,
                    PositionId = 4
                }, 
                new EmployeePositions()
                {
                    HireDate = new DateTime(2020, 2, 11),
                    DateOfDissmisal = new DateTime(2020, 3, 10),
                    EmployeeId = 5,
                    PositionId = 3
                },
                new EmployeePositions()
                {
                    HireDate = new DateTime(2020, 3, 11),
                    DateOfDissmisal = null,
                    EmployeeId = 5,
                    PositionId = 4
                }
                );
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
