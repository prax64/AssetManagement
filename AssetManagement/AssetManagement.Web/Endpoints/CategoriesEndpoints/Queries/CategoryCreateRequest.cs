﻿using AssetManagement.Domain;
using AssetManagement.Web.Endpoints.CategoriesEndpoints.ViewModel;
using AssetManagement.Web.Exceptions;
using Calabonga.OperationResults;
using Calabonga.UnitOfWork;
using MediatR;

namespace AssetManagement.Web.Endpoints.CategoriesEndpoints.Queries
{
    public record CategoryCreateRequest(CategoryCreateViewModel Model)
    : IRequest<OperationResult<CategoryViewModel>>;

    public class CategoryCreateRequestHandler
        : IRequestHandler<CategoryCreateRequest, OperationResult<CategoryViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryCreateRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<CategoryViewModel>> Handle
        (
            CategoryCreateRequest request,
            CancellationToken cancellationToken)
        {
            var operation = OperationResult.CreateResult<CategoryViewModel>();
            var repository = _unitOfWork.GetRepository<Category>();

            var category = new Category
            {
                Name = request.Model.Name,
                Description = request.Model.Description
            };

            await repository.InsertAsync(category, cancellationToken);
            await _unitOfWork.SaveChangesAsync();

            if (!_unitOfWork.LastSaveChangesResult.IsOk)
            {
                operation.AddError(_unitOfWork.LastSaveChangesResult.Exception ?? new CatalogDatabaseSaveException("Saving data error"));
                return operation;
            }

            operation.Result = new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                ProductCount = 0
            };

            return operation;
        }

    }

}


