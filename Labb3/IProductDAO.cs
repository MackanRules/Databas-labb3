using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Labb3
{
    internal interface IProductDAO
    {
        public List<ProductODM> GetAllProducts();
        public void CreateProduct(ProductODM product);
        public void UpdateProduct(string name, int amount);
        public void DeleteProduct(string name);

    }
}
