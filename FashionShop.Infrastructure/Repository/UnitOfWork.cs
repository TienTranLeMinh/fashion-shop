using FashionShop.Core.Interface;
using FashionShop.Infrastructure.Data;

namespace FashionShop.Infrastructure.Repository;
public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public IProductRepository ProductRepository { get; }
    public ICategoryRepository CategoryRepository { get; }

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        ProductRepository = new ProductRepository(context);
        CategoryRepository = new CategoryRepository(context);
    }
}
