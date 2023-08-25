namespace AssetManagement.Web.Endpoints.CategoriesEndpoints.ViewModel
{
    public class CategoryCreateViewModel
    {
        /// <summary>
        /// Name of the catalog
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Description for current catalog
        /// </summary>
        public string? Description { get; set; }
    }
}