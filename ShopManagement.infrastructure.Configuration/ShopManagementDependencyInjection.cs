﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application;
using ShopManagement.Contracts.Product;
using ShopManagement.Contracts.ProductCategory;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Infrastructure.EfCore;
using ShopManagement.Infrastructure.EfCore.Repository;

namespace ShopManagement.infrastructure.Configuration;

public class ShopManagementDependencyInjection
{
    public static void Configuration(IServiceCollection services, string connectionString)
    {
        services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
        services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();

        services.AddTransient<IProductApplication, ProductApplication>();
        services.AddTransient<IProductRepository, ProductRepository>();

        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

    }
}