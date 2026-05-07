using CRMWeb.Models.Phones;
using Refit;

namespace CRMWeb.Services.Phones;

public interface IPhoneService
{
    [Get("/phones?pageIndex={pageIndex}&pageSize={pageSize}")]
    Task<IApiResponse<GetPhonesResponse>> GetPhones(int? pageIndex = 0, int? pageSize = 10);

    [Get("/phones/{id}")]
    Task<IApiResponse<GetPhoneByIdResponse>> GetPhone(Guid id);

    [Get("/phones/counterparty/{id}")]
    Task<IApiResponse<GetPhonesByCounterpartydResponse>> GetPhonesByCounterparty(Guid id);

    [Post("/phones")]
    Task<IApiResponse<CreatePhoneResponse>> CreatePhone(CreatePhoneRequest request);

    [Put("/phones")]
    Task<IApiResponse<UpdatePhoneResponse>> UpdatePhone(UpdatePhoneRequest request);

    [Delete("/phones/{id}")]
    Task<IApiResponse<DeletePhoneResponse>> DeletePhone(Guid id);
}