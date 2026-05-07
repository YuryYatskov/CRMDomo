namespace WebServer.API.Endpoints.Phones.GetPhonesByCounterparty;

public record GetPhonesByCounterpartyResponse(PaginatedResult<PhoneDto> Phones);

public class GetPhonesByCounterparty : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/phones/counterparty/{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new GetPhonesByCounterpartyQuery(id));

            var response = result.Adapt<GetPhonesByCounterpartyResponse>();

            return Results.Ok(response);
        })
        
        .WithName("GetPhoneByCounterparty")
        .Produces<GetPhonesByCounterpartyResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get phone By Counterparty")
        .WithDescription("Get phone By Counterparty");
    }
}
