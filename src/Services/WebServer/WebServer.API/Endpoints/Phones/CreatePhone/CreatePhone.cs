namespace WebServer.API.Endpoints.Phones.CreatePhone;

public record CreatePhoneRequest(PhoneDto Phone);

public record CreatePhoneResponse(Guid Id);

public class CreatePhone : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/phones", async (CreatePhoneRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreatePhoneCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<CreatePhoneResponse>();

            return Results.Created($"/phones/{response.Id}", response);
        })
       .RequireAuthorization()
       .WithName("CreatePhone")
       .Produces<CreatePhoneResponse>(StatusCodes.Status201Created)
       .ProducesProblem(StatusCodes.Status400BadRequest)
       .WithSummary("Create phone")
       .WithDescription("Create phone");
    }
}
