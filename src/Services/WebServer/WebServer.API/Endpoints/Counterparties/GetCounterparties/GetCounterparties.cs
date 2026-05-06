namespace WebServer.API.Endpoints.Counterparties.GetCounterparties;

public record GetCounterpartiesResponse(PaginatedResult<CounterpartyDto> Counterparties);

public class GetCounterparties : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/counterparties", async (
            [AsParameters] PaginationRequest request,
            ISender sender) =>
        {
            var query = new GetCounterpartiesQuery(request);

            var result = await sender.Send(query);

            var response = result.Adapt<GetCounterpartiesResponse>();

            return Results.Ok(response);
        })
        .RequireAuthorization()
        .WithName("GetCounterparties")
        .Produces<GetCounterpartiesResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Counterparties")
        .WithDescription("Get Counterparties");
    }
}
