using BuildingBlocks.DTO.Dtos;
using CRMWeb.Helpers.Pagination;

namespace CRMWeb.Models.Counterparties;

public class CounterpartyLiteModel : CounterpartyLiteDto;

public class CounterpartyModel : CounterpartyDto;

public class CounterpartyFullModel : CounterpartyFullDto;

// Wrapper classes.
public record GetCounterpartiesResponse(PaginatedResult<CounterpartyModel> Counterparties);

public record GetCounterpartyByIdResponse(CounterpartyFullModel Counterparty);

public record CreateCounterpartyResponse(Guid Id);
public record CreateCounterpartyRequest(CounterpartyFullModel Counterparty);

public record UpdateCounterpartyResponse(bool IsSuccess);
public record UpdateCounterpartyRequest(CounterpartyFullModel Counterparty);

public record DeleteCounterpartyResponse(Guid Id);