using AssetManagement.Domain;
using AssetManagement.Web.Endpoints.CategoriesEndpoints.ViewModel;
using System.Linq.Expressions;

namespace AssetManagement.Web.Endpoints.CategoriesEndpoints
{
    public static class CategoryExpressions
    {
        public static Expression<Func<Category, CategoryViewModel>> Default => s => new CategoryViewModel
        {
            Id = s.Id,
            Name = s.Name,
            Description = s.Description,
            ProductCount = s.Products!.Count
        };
    }
}
