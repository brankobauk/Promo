using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Promo.DataLayer;
using Promo.DataLayer.Repositories;
using Promo.Model.Models;

namespace Promo.BusinessLogic.Products
{
    
    public class ProductHandler
    {
        private ProductRepository _ProductRepository = new ProductRepository();
        public List<Product> GetAllProducts()
        {
            return _ProductRepository.GetAllProducts();
        }

        public Product GetProduct(int? ProductId)
        {
            return _ProductRepository.GetProduct(ProductId);
        }

        public void AddProduct(Product Product)
        {
            _ProductRepository.AddProduct(Product);
        }

        public void EditProduct(Product Product)
        {
            _ProductRepository.EditProduct(Product);
        }
    }
}
