using AssetManagement.Domain;
using AssetManagement.Domain.Base;
using AssetManagement.Web.Endpoints.CategoriesEndpoints.ViewModel;
using Calabonga.OperationResults;
using Calabonga.PredicatesBuilder;
using Calabonga.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AssetManagement.Web.Endpoints.CategoriesEndpoints.Queries
{
    public record CategoryGetAllRequest(ClaimsPrincipal User) : IRequest<OperationResult<List<CategoryViewModel>>>;

    public class CategoryGetAllRequestHendler : IRequestHandler<CategoryGetAllRequest, OperationResult<List<CategoryViewModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryGetAllRequestHendler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<OperationResult<List<CategoryViewModel>>> Handle(
            CategoryGetAllRequest request, 
            CancellationToken cancellationToken)
        {
            var predicate = PredicateBuilder.True<Category>();

            if(!request.User.IsInRole(AppData.SystemAdministratorRoleName)) 
            {
                predicate = predicate.And(x => x.Visible);
            }

            var items = await _unitOfWork.GetRepository<Category>()
                .GetAllAsync(
                    selector: s=> new CategoryViewModel
                    {
                        Id = s.Id, 
                        Name = s.Name, 
                        Description= s.Description, 
                        ProductCount = s.Products!.Count
                    },
                    predicate: predicate,
                    include: i=>i.Include(x=>x.Products!)
                );
            return OperationResult.CreateResult(items.ToList());
        }
    }


}
