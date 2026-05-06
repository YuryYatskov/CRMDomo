namespace WebServer.API.Endpoints.Phones.GetPhones;

public record GetPhonesResponse(PaginatedResult<PhoneDto> Phones);

public class GetPhones : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/phones", async (
            [AsParameters] PaginationRequest request,
            ISender sender) =>
        {
            var query = new GetPhonesQuery(request);

            var result = await sender.Send(query);

            var response = result.Adapt<GetPhonesResponse>();

            return Results.Ok(response);
        })
        .RequireAuthorization()
        .WithName("GetPhones")
        .Produces<GetPhonesResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get phones")
        .WithDescription("Get phones");
    }
}