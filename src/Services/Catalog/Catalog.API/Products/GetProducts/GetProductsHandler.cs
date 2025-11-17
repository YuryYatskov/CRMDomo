namespace Catalog.API.Products.GetProducts;

public record GetProductsQuery(PaginationRequest PaginationRequest)
    : IQuery<GetProductsResult>;

public record GetProductsResult(PaginatedResult<Product> Products);

internal class GetProductsQueryHandler(ApplicationDbContext context)
        : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {

        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        var totalCount = await context.Products.LongCountAsync(cancellationToken);

        var products = await context.Products
            .OrderBy(o => o.Name)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new GetProductsResult(new PaginatedResult<Product>(
                pageIndex,
                pageSize,
                totalCount,
                products));
    }
}
