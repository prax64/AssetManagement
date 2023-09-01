using AssetManagement.Web.Application;
using AssetManagement.Web.Definitions.OpenIddict;
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

           // app.MapGet("/api/qrcode/print", PrintQRcode);
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

        //[ProducesResponseType(200)]
        //[ProducesResponseType(401)]
        //[FeatureGroupName("QRcode")]
        //[Authorize(AuthenticationSchemes = AuthData.AuthSchemes)]
        //private FileResult PrintQRcode(
        //[FromServices] IMediator mediator,
        //[FromBody] QRcodeCreateViewModel createViewModel,
        //HttpContext context)
        //{
        //    var qRcodeByte = new QRcode
        //    {
        //        QRCode = createViewModel.QRcode,
        //    };
        //    byte[] QRCodeByte = GenerateQRCode(qRcodeByte.QRCode);
        //    string QRCodeImageBase64 = $"data:image/png;base64,{Convert.ToBase64String(QRCodeByte)}";

        //    //HttpContext.Response.ContentType = "image/png";
        //    FileContentResult result = new FileContentResult(System.IO.File.ReadAllBytes("YOUR PATH TO PDF"), "application/pdf")
        //    {
        //        FileDownloadName = "test.png"
        //    };

        //    return QRCodeImageBase64;
        //}
        //public byte[] GenerateQRCode(string text)
        //{
        //    byte[] QRcode = new byte[0];
        //    if (!string.IsNullOrEmpty(text))
        //    {
        //        QRCodeGenerator qrCodeGenerator = new QRCodeGenerator();
        //        QRCodeData qrCodeData = qrCodeGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);

        //        BitmapByteQRCode bitmap = new BitmapByteQRCode(qrCodeData);
        //        QRcode = bitmap.GetGraphic(20);
        //    }
        //    return QRcode;
        //}
    }

}
