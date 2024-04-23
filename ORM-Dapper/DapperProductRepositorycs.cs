using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    public class DapperProductRepositorycs : IProductRepsotory
    {
        private readonly IDbConnection _conn;

        public DapperProductRepositorycs(IDbConnection conn)
        {
            _conn = conn;
        }

        public void CreateProduct(string name, double price, int categoryID)
        {
            _conn.Execute("INSERT INTO products (name) VALUES (@name) (Price) VALUES (@price) (CategoryId) VALUES (@categoryId",
                new { name = name, price = price, categoryId = categoryID});
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM Products;");
        }

        
    }
}
