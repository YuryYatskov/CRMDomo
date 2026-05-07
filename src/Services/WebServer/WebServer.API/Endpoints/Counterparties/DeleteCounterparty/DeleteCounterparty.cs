namespace WebServer.API.Endpoints.Counterparties.DeleteCounterparty;

public record DeleteCounterpartyResponse(bool IsSuccess);

public class DeleteCounterparty : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/counterparties/{id}", async (Guid Id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteCounterpartyCommand(Id));

            var response = result.Adapt<DeleteCounterpartyResponse>();

            return Results.Ok(response);
        })
        
        .WithName("DeleteCounterparty")
        .Produces<DeleteCounterpartyResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Delete Counterparty")
        .WithDescription("Delete Counterparty");
    }
}
