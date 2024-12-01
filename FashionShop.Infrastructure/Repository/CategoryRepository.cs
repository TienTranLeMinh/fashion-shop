using FashionShop.Core.Entities;
using FashionShop.Core.Interface;
using FashionShop.Infrastructure.Data;

namespace FashionShop.Infrastructure.Repository;
public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext context) : base(context)
    {
    }
}

