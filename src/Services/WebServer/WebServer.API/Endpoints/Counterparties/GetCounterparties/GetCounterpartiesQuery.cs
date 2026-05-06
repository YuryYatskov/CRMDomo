namespace WebServer.API.Endpoints.Counterparties.GetCounterparties;

public record GetCounterpartiesQuery(PaginationRequest PaginationRequest)
    : IQuery<GetCounterpartiesResult>;

public record GetCounterpartiesResult(PaginatedResult<CounterpartyDto> Counterparties);

public class GetCounterpartiesHandler(ApplicationDbContext dbContext)
    : IQueryHandler<GetCounterpartiesQuery, GetCounterpartiesResult>
{
    public async Task<GetCounterpartiesResult> Handle(GetCounterpartiesQuery query, CancellationToken cancellationToken)
    {
        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        var totalCount = await dbContext.Counterparties.AsNoTracking()

            .LongCountAsync(cancellationToken);

        var counterparties = await dbContext.Counterparties.AsNoTracking()
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        var counterpartiesResult = new GetCounterpartiesResult(
            new PaginatedResult<CounterpartyDto>(
                pageIndex,
                pageSize,
                totalCount,
                counterparties.ToCounterpartiesDtoList()));

        return counterpartiesResult;
    }
}
