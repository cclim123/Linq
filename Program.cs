using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace ConsoleApp1
{
    internal class Program
    {
        

        enum Category
        {
            HR ,
            IT,            
            Payroll
        }

        static bool GetEmployeeIdLessThanFour(Employee emp)
        {
            return emp.ID >= 1 && emp.ID < 4;
        }
        
        public static async void ConsumeWebAPI()
        {
            using (var client = new HttpClient())
            {            
                client.BaseAddress = new Uri("https://mocki.io/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method
                HttpResponseMessage response = await client.GetAsync("v1/ab120bf0-ebbf-43b3-971f-f8ae692c31df");
                if (response.IsSuccessStatusCode)
                {
                    var department = await response.Content.ReadFromJsonAsync<List<GitHubRelease>>();
                    
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }
        }


        static void Main(string[] args)
        {
#if !DEBUG
#region Join table
                            var JoinMultipleDSUsingQS =
                                (
                                //Data Source1 i.e. Employee
                                from emp in Employee.GetAllEmployees()
                                join adrs in Address.GetAllAddresses()
                                on emp.AddressId equals adrs.ID

                                //Joining with Department Data Source (Data Source3)
                                join dept in Department.GetAllDepartments()
                                on emp.DepartmentId equals dept.ID

                                //Projecting the Result to an Annonymous Type
                                select new
                                {
                                    ID = emp.ID,
                                    EmployeeName = emp.Name,
                                    DepartmentName = dept.Name,
                                    AddressLine = adrs.AddressLine
                                });

                            //Accessing the Result using a Foreach Loop
                            foreach (var employee in JoinMultipleDSUsingQS.AsEnumerable())
                            {
                                Console.WriteLine($"ID = {employee.ID}, Name = {employee.EmployeeName}, Department = {employee.DepartmentName}, Addres = {employee.AddressLine}");
                            }

#endregion

#region check record exists

                            var checkQuery = from emp in Employee.GetAllEmployees()
                                             where emp.ID >= 1
                                             select emp;

                            Console.WriteLine($"{checkQuery.Any()}");

#endregion

#region OR and Operator
                            var orLinq =
                                (
                                //Data Source1 i.e. Employee
                                from emp in Employee.GetAllEmployees()
                                from adrs in Address.GetAllAddresses()
                                where ((emp.AddressId == adrs.ID && emp.Name != null) || (adrs.AddressLine != null))
                                select new
                                {
                                    ID = emp.ID,
                                    EmployeeName = emp.Name,
                                    AddressLine = adrs.AddressLine
                                }).ToList();

                            foreach (var employee in orLinq)
                            {
                                Console.WriteLine($"ID = {employee.ID}, Name = {employee.EmployeeName}, Address = {employee.AddressLine}");
                            }
#endregion

#region multiple where
                            var multiplewhereLinq  = from emp in Employee.GetAllEmployees()
                                             where emp.ID >= 1
                                             where emp.ID < 4
                                             select emp;

                            foreach (var employee in multiplewhereLinq)
                            {
                                Console.WriteLine($"ID = {employee.ID}, Name = {employee.Name}, Address = {employee.AddressId}");
                            }
#endregion
            
#region multiple where clause method
                        var whereClauseLinq = from emp in Employee.GetAllEmployees()
                                            where GetEmployeeIdLessThanFour(emp)
                                            select emp;

                        foreach (var employee in whereClauseLinq)
                        {
                            Console.WriteLine($"ID = {employee.ID}, Name = {employee.Name}, Address = {employee.AddressId}");
                        }
#endregion

#region get top 3 highest pay
            var highestPayLinq = Employee.GetAllEmployees().OrderByDescending(i => i.Salary).ThenBy(i => i.Name).Take(3).ToList();
            foreach (var employee in highestPayLinq)
            {
                Console.WriteLine($"ID = {employee.ID}, Name = {employee.Name}, Salary = {employee.Salary}");
            }
#endregion

#region custom order 
            var customSortLinq = Department.GetAllDepartments()
                .OrderBy(x => x.Name == Category.HR.ToString())
                .OrderBy(x => x.Name == Category.IT.ToString())
                .OrderBy(x => x.Name == Category.Payroll.ToString())
                .ToList();

            string categoryName = customSortLinq.FirstOrDefault().Name;

            if (categoryName != null)
            { 
                Console.WriteLine(categoryName);
            }
#endregion

#region Show 6 First and show the rest in order
            int[] i = new int[] { 2,1,3,5,6,8,7,10 };

            var sorting = i.OrderByDescending(x => x == 6).ThenBy(x => x).ToList();

#endregion

#region Average
            i = new int[] { 2, 1, 3, 5, 6, 8, 7, 10 };

            //method linq
            var avg = i.Where(x => x > 5).Average(x => x);

            //query linq
            avg = (from x in i
                   where x > 5
                   select x).Average(x => x);

#endregion
#endif


#if DEBUG

            ConsumeWebAPI();
#endif
            Console.ReadLine();


        }
    }
}
