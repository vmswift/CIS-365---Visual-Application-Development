using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo
{
    class LinqDemoClass
    {
        static void Main(string[] args)
        {
            var employees = new List<Employee>
{
            new Employee( "Jason", "Red", 5000M ),
            new Employee( "Ashley", "Green", 7600M ),
                 new Employee( "Matthew", "Indigo", 3587.5M ),
                new Employee( "James", "Indigo", 4700.77M ),
             new Employee( "Luke", "Indigo", 6200M ),
         new Employee( "Jason", "Blue", 3200M ),
          new Employee( "Wendy", "Brown", 4236.4M )
            }; // end init list

            // display all employees
            Console.WriteLine("Original list:");
            foreach (var element in employees)
                Console.WriteLine(element);

            var between4k6k =
            from e in employees
            where e.MonthlySalary >= 4000M && e.MonthlySalary <= 6000M
            select e;
            Console.WriteLine(string.Format(
            "\nEmployees earning in the range {0:C}-{1:C} per month:",
            4000, 6000));

            foreach (var element in between4k6k)
                Console.WriteLine(element);

            // order the employees by last name, then first name with LINQ
            var nameSorted =
                from e in employees
                orderby e.LastName, e.FirstName
                select e;

            // header
            Console.WriteLine("\nFirst employee when sorted by name:");

            // attempt to display the first result of the above LINQ query
            if (nameSorted.Any())
                Console.WriteLine(nameSorted.First());
            else
                Console.WriteLine("not found");
        }
    }
}
