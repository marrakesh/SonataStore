using System.Collections.Generic;
using SonataStore.Domain.Entities;

namespace SonataStore.Domain.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        void SaveProduct(Product product);
        Product DeleteProduct(int productId);
    }
}
