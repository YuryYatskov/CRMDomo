namespace WebServer.API.Endpoints.Counterparties.GetCounterpartyById;

public record GetCounterpartyByIdResponse(CounterpartyFullDto Counterparty);

public class GetCounterpartyById : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/counterparties/{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new GetCounterpartyByIdQuery(id));

            var response = result.Adapt<GetCounterpartyByIdResponse>();

            return Results.Ok(response);
        })
        .RequireAuthorization()
        .WithName("GetCounterpartyById")
        .Produces<GetCounterpartyByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Counterparty By Id")
        .WithDescription("Get Counterparty By Id");
    }
}
