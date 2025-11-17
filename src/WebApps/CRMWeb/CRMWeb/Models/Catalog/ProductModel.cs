using CRMWeb.Helpers.Pagination;

namespace CRMWeb.Models.Catalog;

public class ProductModel : ProductWithoutIdModel
{
    public Guid Id { get; set; }
}

public class ProductWithoutIdModel
{
    public string Name { get; set; } = default!;

    public List<string> Category { get; set; } = [];

    public string Description { get; set; } = default!;

    public string ImageFile { get; set; } = default!;

    public decimal Price { get; set; }
}

// Wrapper classes.
public record GetProductsResponse(PaginatedResult<ProductModel> Products);
public record GetProductByCategoryResponse(IEnumerable<ProductModel> Products);
public record GetProductByIdResponse(ProductModel Product);
public record CreateProductResponse(ProductModel Product);
public record UpdateProductResponse(ProductModel Product);
public record DeleteProductResponse(Guid Id);

public record CreateProductRequest(
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price);
