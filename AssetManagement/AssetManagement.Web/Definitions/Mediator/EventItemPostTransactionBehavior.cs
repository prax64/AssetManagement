using AssetManagement.Web.Definitions.Mediator.Base;
using AssetManagement.Web.Endpoints.EventItemsEndpoints.ViewModels;
using Calabonga.OperationResults;
using Calabonga.UnitOfWork;
using MediatR;

namespace AssetManagement.Web.Definitions.Mediator
{
    public class EventItemPostTransactionBehavior : TransactionBehavior<IRequest<OperationResult<EventItemViewModel>>, OperationResult<EventItemViewModel>>
    {
        public EventItemPostTransactionBehavior(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}