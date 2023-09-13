using AssetManagement.Domain;
using AssetManagement.Domain.Base;
using AssetManagement.Web.Endpoints.CategoriesEndpoints.ViewModel;
using AssetManagement.Web.Exceptions;
using Calabonga.OperationResults;
using Calabonga.PredicatesBuilder;
using Calabonga.UnitOfWork;
using MediatR;

namespace AssetManagement.Web.Endpoints.CategoriesEndpoints.Queries
{
    public record  CategoryGetByIdRequest(Guid CategoryId, System.Security.Claims.ClaimsPrincipal User) 
        : IRequest<OperationResult<CategoryViewModel>>;
    public record CategoryGetByIdRequestHandler
        : IRequestHandler<CategoryGetByIdRequest, OperationResult<CategoryViewModel>>
    {
        private readonly IUnitOfWork unitOfWork;

        public CategoryGetByIdRequestHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<OperationResult<CategoryViewModel>> Handle(CategoryGetByIdRequest request, CancellationToken cancellationToken)
        {
            var operation = OperationResult.CreateResult<CategoryViewModel>();
            var predicate = PredicateBuilder.True<Category>();
            predicate = predicate.And(x => x.Id == request.CategoryId);

            if (!request.User.IsInRole(AppData.SystemAdministratorRoleName))
            {
                predicate = predicate.And(x => x.Visible);
            }

            var item = await this.unitOfWork.GetRepository<Category>()
                .GetFirstOrDefaultAsync(
                selector: CategoryExpressions.Default,
                predicate: predicate);

            if(item != null)
            {
                operation.Result = item;
                return operation;
            }

            operation.AddError(new CatalogNotFoundException($"Item {request.CategoryId} not found"));
            return operation;
        }
    }


}
