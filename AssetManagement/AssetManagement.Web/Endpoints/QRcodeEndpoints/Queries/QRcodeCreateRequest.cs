using AssetManagement.Domain;
using AssetManagement.Web.Endpoints.CategoriesEndpoints.ViewModel;
using AssetManagement.Web.Endpoints.QRcodeEndpoints.ViewModel;
using AssetManagement.Web.Exceptions;
using Calabonga.OperationResults;
using Calabonga.UnitOfWork;
using MediatR;
using QRCoder;
using static System.Net.Mime.MediaTypeNames;

namespace AssetManagement.Web.Endpoints.QRcodeEndpoints.Queries
{


    public record QRcodeCreateRequest(QRcodeCreateViewModel Model)
    : IRequest<OperationResult<QRcodeViewModel>>;

    public class QRcodeCreateRequestHandler
        : IRequestHandler<QRcodeCreateRequest, OperationResult<QRcodeViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public QRcodeCreateRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<QRcodeViewModel>> Handle
        (
            QRcodeCreateRequest request,
            CancellationToken cancellationToken)
        {
            var operation = OperationResult.CreateResult<QRcodeViewModel>();
            var repository = _unitOfWork.GetRepository<QRcode>();



            var qRcodeByte = new QRcode
            {
                QRCode = request.Model.QRcode,
            };
            byte[] QRCodeByte = GenerateQRCode(qRcodeByte.QRCode);
            string QRCodeImageBase64 = $"data:image/png;base64,{Convert.ToBase64String(QRCodeByte)}";

            await repository.InsertAsync(qRcodeByte, cancellationToken);
            await _unitOfWork.SaveChangesAsync();

            if (!_unitOfWork.LastSaveChangesResult.IsOk)
            {
                operation.AddError(_unitOfWork.LastSaveChangesResult.Exception ?? new CatalogDatabaseSaveException("Saving data error"));
                return operation;
            }
            operation.Result = new QRcodeViewModel
            {
                QRcodeImageUrl = QRCodeImageBase64
            };

            return operation;
        }
        public byte[] GenerateQRCode(string text)
        {
            byte[] QRcode = new byte[0];
            if (!string.IsNullOrEmpty(text))
            {
                QRCodeGenerator qrCodeGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrCodeGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);

                BitmapByteQRCode bitmap = new BitmapByteQRCode(qrCodeData);
                QRcode = bitmap.GetGraphic(20);
            }
            return QRcode;
        }

    }

}
