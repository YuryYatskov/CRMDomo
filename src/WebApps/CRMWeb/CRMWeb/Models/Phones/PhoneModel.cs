using BuildingBlocks.DTO.Dtos;
using CRMWeb.Helpers.Pagination;

namespace CRMWeb.Models.Phones;

public class PhoneModel : PhoneDto;

// Wrapper classes.
public record GetPhonesResponse(PaginatedResult<PhoneModel> Phones);
public record GetPhoneByIdResponse(PhoneModel Phone);
public record GetPhonesByCounterpartydResponse(PaginatedResult<PhoneModel> Phones);

public record CreatePhoneResponse(Guid Id);
public record CreatePhoneRequest(PhoneModel Phone);


public record UpdatePhoneResponse(bool IsSuccess);
public record UpdatePhoneRequest(PhoneModel Phone);

public record DeletePhoneResponse(Guid Id);
