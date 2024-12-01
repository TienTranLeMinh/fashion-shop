using FashionShop.Core.Entities;
using FashionShop.Core.Interface;
using FashionShop.Infrastructure.Data;

namespace FashionShop.Infrastructure.Repository;
public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext context) : base(context)
    {
    }
}
