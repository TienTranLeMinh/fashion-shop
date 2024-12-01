﻿namespace FashionShop.Core.Entities;
public class Category
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public virtual ICollection<Product> Products { get; set; }
}
