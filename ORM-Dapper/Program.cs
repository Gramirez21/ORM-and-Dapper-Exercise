using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);


            var departmentRepository = new DapperDepartmentRepository(conn);

            var departments = departmentRepository.GetDepartments();

            foreach (var department in departments)
            {
                Console.WriteLine(department.Name);
                Console.WriteLine(department.DepartmentID);
                Console.WriteLine();
            }

            var productRepository = new DapperProductRepositorycs(conn);



            var products = productRepository.GetAllProducts();

            foreach (var product in products)
            {
                Console.WriteLine(product.Name);
                Console.WriteLine(product.ProductID);
                Console.WriteLine(product.Price);
                Console.WriteLine(product.CategoryID);
                Console.WriteLine(product.StockLevel);
                Console.WriteLine(product.OnSale);
                Console.WriteLine();

            }

        }
    }
}
