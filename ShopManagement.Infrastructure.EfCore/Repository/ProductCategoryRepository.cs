﻿using Framework.Infrastructure;
using ShopManagement.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Infrastructure.EfCore.Repository;

public class ProductCategoryRepository : RepositoryBase<long, ProductCategory>,IProductCategoryRepository
{
    private readonly ApplicationDbContext _context;

    public ProductCategoryRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }


    public EditProductCategory GetDetails(long id)
    {
        return _context.ProductCategories.Select(x => new EditProductCategory()
        {
            Id = x.Id,
            Description = x.Description,
            Name = x.Name,
            Slug = x.Slug,
            Keyword = x.Keyword,
            MetaDescription = x.MetaDescription,
            Picture = x.Picture,
            PictureAlt = x.PictureAlt,
            PictureTitle = x.PictureTitle
        }).FirstOrDefault(x => x.Id == id);
    }

    public List<ProductCategoryViewModel> Search(ProductCategorySearchModel command)
    {
        var query = _context.ProductCategories.Select(x => new ProductCategoryViewModel
        {
            Id = x.Id,
            CreationDate = x.CreationDate.ToString(),
            Name = x.Name,
            Picture = x.Picture
        });

        if (!string.IsNullOrWhiteSpace(command.Name))
            query = query.Where(x => x.Name.Contains(command.Name));

        return query.OrderByDescending(x => x.Id).ToList();
    }
 }