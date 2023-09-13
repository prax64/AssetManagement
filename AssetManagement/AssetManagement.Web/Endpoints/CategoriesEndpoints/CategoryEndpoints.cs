using AssetManagement.Web.Application;
using AssetManagement.Web.Definitions.OpenIddict;
using AssetManagement.Web.Endpoints.CategoriesEndpoints.Queries;
using AssetManagement.Web.Endpoints.CategoriesEndpoints.ViewModel;
using Calabonga.AspNetCore.AppDefinitions;
using Calabonga.OperationResults;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Web.Endpoints.CategoriesEndpoints
{
    public class CategoryEndpoints : AppDefinition
    {
        public override void ConfigureApplication(WebApplication app)
        {
            app.MapGet("/api/categories/get-all", GetAllCategories);
            app.MapGet("/api/categories/{id:guid}", GetByIdCategories);
            app.MapPost("/api/categories/create", CreateCategory);


        }

        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [FeatureGroupName("Catigories")]
        private Task<OperationResult<List<CategoryViewModel>>> GetAllCategories([FromServices] IMediator mediator, HttpContext context)
        {
            return mediator.Send(new CategoryGetAllRequest(context.User), context.RequestAborted);
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [FeatureGroupName("Catigories")]
        [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
        private Task<OperationResult<CategoryViewModel>> CreateCategory(
            [FromServices] IMediator mediator, 
            [FromBody] CategoryCreateViewModel createViewModel, 
            HttpContext context)
        {
            return mediator.Send(new CategoryCreateRequest(createViewModel), context.RequestAborted);
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [FeatureGroupName("Catigories")]
        [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
        private Task<OperationResult<CategoryViewModel>> GetByIdCategories(
            Guid id,
            [FromServices] IMediator mediator,
            HttpContext context)
        {
            return mediator.Send(new CategoryGetByIdRequest(id, context.User), context.RequestAborted);
        }
    }
}
