namespace WebServer.API.Endpoints.Counterparties.UpdateCounterparty;

public record UpdateCounterpartyRequest(CounterpartyFullDto Counterparty);

public record UpdateCounterpartyResponse(bool IsSuccess);

public class UpdateCounterparty : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/counterparties", async (UpdateCounterpartyRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateCounterpartyCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateCounterpartyResponse>();

            return Results.Ok(response);
        })
        
        .WithName("UpdateCounterparty")
        .Produces<UpdateCounterpartyResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Counterparty")
        .WithDescription("Update Counterparty");
    }
}