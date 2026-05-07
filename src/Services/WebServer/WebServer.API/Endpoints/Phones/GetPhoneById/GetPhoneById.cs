namespace WebServer.API.Endpoints.Phones.GetPhoneById;

public record GetPhoneByIdResponse(PhoneDto Phone);

public class GetPhoneById : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/phones/{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new GetPhoneByIdQuery(id));

            var response = result.Adapt<GetPhoneByIdResponse>();

            return Results.Ok(response);
        })
        
        .WithName("GetPhoneById")
        .Produces<GetPhoneByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get phone By Id")
        .WithDescription("Get phone By Id");
    }
}
