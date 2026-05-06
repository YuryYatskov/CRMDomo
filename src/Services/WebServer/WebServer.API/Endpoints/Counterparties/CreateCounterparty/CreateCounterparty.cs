namespace WebServer.API.Endpoints.Counterparties.CreateCounterparty;

public record CreateCounterpartyRequest(CounterpartyFullDto Counterparty);

public record CreateCounterpartyResponse(Guid Id);

public class CreateCounterparty : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/counterparties", async (CreateCounterpartyRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateCounterpartyCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<CreateCounterpartyResponse>();

            return Results.Created($"/counterparties/{response.Id}", response);
        })
       .RequireAuthorization()
       .WithName("CreateCounterparty")
       .Produces<CreateCounterpartyResponse>(StatusCodes.Status201Created)
       .ProducesProblem(StatusCodes.Status400BadRequest)
       .WithSummary("Create Counterparty")
       .WithDescription("Create Counterparty");
    }
}