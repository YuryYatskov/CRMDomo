namespace WebServer.API.Endpoints.Phones.GetPhonesByCounterparty;

public record GetPhonesByCounterpartyQuery(Guid CounterpartyId)
    : IQuery<GetPhonesByCounterpartyResult>;

public record GetPhonesByCounterpartyResult(PaginatedResult<PhoneDto> Phones);

public class GetPhonesByCounterpartyHandler(ApplicationDbContext dbContext)
    : IQueryHandler<GetPhonesByCounterpartyQuery, GetPhonesByCounterpartyResult>
{
    public async Task<GetPhonesByCounterpartyResult> Handle(GetPhonesByCounterpartyQuery query, CancellationToken cancellationToken)
    {
        var phones = await dbContext.Phones.AsNoTracking()
            .Where(x => x.CounterpartyId == query.CounterpartyId)
            .OrderBy(x => x.Number)
            .ToListAsync(cancellationToken);

        var phonesResult = new GetPhonesByCounterpartyResult(
            new PaginatedResult<PhoneDto>(
                0,
                int.MaxValue,
                phones.Count,
                phones.ToPhonesDtoList()));

        return phonesResult;
    }
}