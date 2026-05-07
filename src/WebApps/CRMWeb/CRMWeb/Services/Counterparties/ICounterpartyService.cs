using CRMWeb.Models.Counterparties;
using Refit;

namespace CRMWeb.Services.Counterparties;

public interface ICounterpartyService
{
    [Get("/counterparties?pageIndex={pageIndex}&pageSize={pageSize}")]
    Task<IApiResponse<GetCounterpartiesResponse>> GetCounterparties(int? pageIndex = 0, int? pageSize = 10);

    [Get("/counterparties/{id}")]
    Task<IApiResponse<GetCounterpartyByIdResponse>> GetCounterparty(Guid id);

    [Post("/counterparties")]
    Task<IApiResponse<CreateCounterpartyResponse>> CreateCounterparty(CreateCounterpartyRequest request);

    [Put("/counterparties")]
    Task<IApiResponse<UpdateCounterpartyResponse>> UpdateCounterparty(UpdateCounterpartyRequest request);

    [Delete("/counterparties/{id}")]
    Task<IApiResponse<DeleteCounterpartyResponse>> DeleteCounterparty(Guid id);
}