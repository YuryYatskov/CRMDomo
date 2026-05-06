namespace WebServer.API.Endpoints.Phones.GetPhoneById;

public record GetPhoneByIdQuery(Guid PhoneId)
    : IQuery<GetPhoneByIdResult>;

public record GetPhoneByIdResult(PhoneDto Phone);

public class GetPhoneByIdHandler(ApplicationDbContext dbContext)
    : IQueryHandler<GetPhoneByIdQuery, GetPhoneByIdResult>
{
    public async Task<GetPhoneByIdResult> Handle(GetPhoneByIdQuery query, CancellationToken cancellationToken)
    {
        var phone = await dbContext.Phones.AsNoTracking()
            //.Where(x => x.SeparatorId == SeparatorId.Of(query.SeparatorId))
            .Where(x => x.Id == query.PhoneId)
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new PhoneNotFoundException(query.PhoneId);

        return new GetPhoneByIdResult(phone.ToPhoneDto());
    }
}