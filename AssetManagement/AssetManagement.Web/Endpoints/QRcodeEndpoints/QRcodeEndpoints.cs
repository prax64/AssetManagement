using AssetManagement.Web.Application;
using AssetManagement.Web.Definitions.OpenIddict;
using AssetManagement.Web.Endpoints.CategoriesEndpoints.Queries;
using AssetManagement.Web.Endpoints.CategoriesEndpoints.ViewModel;
using AssetManagement.Web.Endpoints.QRcodeEndpoints.Queries;
using AssetManagement.Web.Endpoints.QRcodeEndpoints.ViewModel;
using Calabonga.AspNetCore.AppDefinitions;
using Calabonga.OperationResults;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Web.Endpoints.QRcodeEndpoints
{
    public class QRcodeEndpoints : AppDefinition
    {
        public override void ConfigureApplication(WebApplication app)
        {
            app.MapPost("/api/qrcode/create", CreateQRcode);

        }


        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [FeatureGroupName("QRcode")]
        [Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
        private Task<OperationResult<QRcodeViewModel>> CreateQRcode(
            [FromServices] IMediator mediator,
            [FromBody] QRcodeCreateViewModel createViewModel,
            HttpContext context)
        {
            return mediator.Send(new QRcodeCreateRequest(createViewModel), context.RequestAborted);
        }
    }
}
