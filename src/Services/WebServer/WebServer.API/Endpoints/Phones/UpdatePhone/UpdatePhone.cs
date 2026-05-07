namespace WebServer.API.Endpoints.Phones.UpdatePhone;

public record UpdatePhoneRequest(PhoneDto Phone);

public record UpdatePhoneResponse(bool IsSuccess);

public class UpdatePhone : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/phones", async (UpdatePhoneRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdatePhoneCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdatePhoneResponse>();

            return Results.Ok(response);
        })
        
        .WithName("UpdatePhone")
        .Produces<UpdatePhoneResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update phone")
        .WithDescription("Update phone");
    }
}