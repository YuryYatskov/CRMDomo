using CRMWeb.Models.Catalog;
using Refit;

namespace CRMWeb.Services.Catalog;

public interface ICatalogService
{
    [Get("/products?pageIndex={pageIndex}&pageSize={pageSize}")]
    Task<IApiResponse<GetProductsResponse>> GetProducts(int? pageIndex = 0, int? pageSize = 10);

    [Get("/products/{id}")]
    Task<IApiResponse<GetProductByIdResponse>> GetProduct(Guid id);

    [Get("/products/category/{category}")]
    Task<IApiResponse<GetProductByCategoryResponse>> GetProductsByCategory(string category);

    [Post("/products")]
    Task<IApiResponse<CreateProductResponse>> CreateProduct(ProductModel product);

    [Put("/products")]
    Task<IApiResponse<UpdateProductResponse>> UpdateProduct(ProductModel product);

    [Delete("/products/{id}")]
    Task<IApiResponse<DeleteProductResponse>> DeleteProduct(Guid id);
}
