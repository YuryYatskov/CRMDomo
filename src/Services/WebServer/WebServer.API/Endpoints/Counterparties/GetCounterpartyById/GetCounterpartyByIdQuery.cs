namespace WebServer.API.Endpoints.Counterparties.GetCounterpartyById;

public record GetCounterpartyByIdQuery(Guid CounterpartyId)
    : IQuery<GetCounterpartyByIdResult>;

public record GetCounterpartyByIdResult(CounterpartyFullDto Counterparty);

public class GetCounterpartyByIdHandler(ApplicationDbContext dbContext)
    : IQueryHandler<GetCounterpartyByIdQuery, GetCounterpartyByIdResult>
{
    public async Task<GetCounterpartyByIdResult> Handle(GetCounterpartyByIdQuery query, CancellationToken cancellationToken)
    {
        var counterparty = await dbContext.Counterparties.AsNoTracking()
            .Where(x => x.Id == query.CounterpartyId)
            .Include(c => c.Phones)
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new CounterpartyNotFoundException(query.CounterpartyId);

        return new GetCounterpartyByIdResult(counterparty.ToCounterpartyFullDto());
    }
}