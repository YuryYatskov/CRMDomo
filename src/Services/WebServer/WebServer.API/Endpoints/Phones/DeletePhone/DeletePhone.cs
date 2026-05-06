namespace WebServer.API.Endpoints.Phones.DeletePhone;

public record DeletePhoneResponse(bool IsSuccess);

public class DeletePhone : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/phones/{id}", async (Guid Id, ISender sender) =>
        {
            var result = await sender.Send(new DeletePhoneCommand(Id));

            var response = result.Adapt<DeletePhoneResponse>();

            return Results.Ok(response);
        })
        .RequireAuthorization()
        .WithName("DeletePhone")
        .Produces<DeletePhoneResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Delete phone")
        .WithDescription("Delete phone");
    }
}
