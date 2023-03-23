using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int AddressId { get; set; }
        public int DepartmentId { get; set; }
        public int Salary { get; set; }
        public static List<Employee> GetAllEmployees()
        {
            return new List<Employee>()
            {
                new Employee { ID = 1, Name = "Preety", AddressId = 1, DepartmentId = 10, Salary = 10000    },
                new Employee { ID = 2, Name = "Priyanka", AddressId = 2, DepartmentId =20, Salary = 9000   },
                new Employee { ID = 3, Name = "Anurag", AddressId = 3, DepartmentId = 30, Salary = 8000    },
                new Employee { ID = 4, Name = "Pranaya", AddressId = 4, DepartmentId = 0, Salary = 7000    },
                new Employee { ID = 5, Name = "Hina", AddressId = 5, DepartmentId = 0, Salary = 7000       },
                new Employee { ID = 6, Name = "Sambit", AddressId = 6, DepartmentId = 0, Salary = 8000     },
                new Employee { ID = 7, Name = "Happy", AddressId = 7, DepartmentId = 0, Salary = 16000      },
                new Employee { ID = 8, Name = "Tarun", AddressId = 8, DepartmentId = 0, Salary = 9000      },
                new Employee { ID = 9, Name = "Santosh", AddressId = 9, DepartmentId = 10, Salary = 15000   },
                new Employee { ID = 10, Name = "Raja", AddressId = 10, DepartmentId = 20, Salary = 7000    },
                new Employee { ID = 11, Name = "Ramesh", AddressId = 11, DepartmentId = 30, Salary = 11000  }
            };
        }
    }
}
