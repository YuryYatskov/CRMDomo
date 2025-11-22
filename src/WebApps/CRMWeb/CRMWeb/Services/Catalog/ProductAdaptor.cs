using CRMWeb.Exceptions;
using CRMWeb.Extensions;
using CRMWeb.Models.Catalog;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Data;
using System.Collections;

namespace CRMWeb.Services.Catalog;

public class ProductAdaptor : DataAdaptor
{
    private readonly ICatalogService _catalogService;

    public ProductAdaptor()
    {
        _catalogService = SelectiveServices.CatalogService!;
    }

    public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
    {
        var pageSize = dataManagerRequest.Take;
        var pageIndex = dataManagerRequest.Skip == 0 ? 0 : pageSize / dataManagerRequest.Skip;

        var response = await _catalogService.GetProducts(pageIndex, pageSize);

        if (response.IsSuccessStatusCode)
        {
            IEnumerable<ProductModel> dataSource = response.Content!.Products.Data;

            // Handling Searching in CustomAdaptor.
            if (dataManagerRequest.Search != null && dataManagerRequest.Search.Count > 0)
            {
                // Searching
                dataSource = DataOperations.PerformSearching(dataSource, dataManagerRequest.Search);
            }

            // Handling Filtering in CustomAdaptor.
            if (dataManagerRequest.Where != null && dataManagerRequest.Where.Count > 0)
            {
                // Filtering
                dataSource = DataOperations.PerformFiltering(dataSource, dataManagerRequest.Where, dataManagerRequest.Where[0].Operator);
            }

            // Handling Sorting in CustomAdaptor.
            if (dataManagerRequest.Sorted != null && dataManagerRequest.Sorted.Count > 0)
            {
                // Sorting
                dataSource = DataOperations.PerformSorting(dataSource, dataManagerRequest.Sorted);
            }

            int count = dataSource.Cast<ProductModel>().Count();

            // Handling Aggregates in CustomAdaptor.
            IDictionary<string, object>? aggregates = null;
            if (dataManagerRequest.Aggregates != null) // Aggregation
            {
                aggregates = DataUtil.PerformAggregation(dataSource, dataManagerRequest.Aggregates);
            }

            // Handling Paging in CustomAdaptor. For example, Skip is 0 and Take is equal to page size for first page.
            if (dataManagerRequest.Skip != 0)
            {
                //Paging
                dataSource = DataOperations.PerformSkip(dataSource, dataManagerRequest.Skip);
            }

            if (dataManagerRequest.Take != 0)
            {
                dataSource = DataOperations.PerformTake(dataSource, dataManagerRequest.Take);
            }

            // Handling Grouping in CustomAdaptor.
            DataResult dataObject = new DataResult();
            if (dataManagerRequest.Group != null)
            {
                IEnumerable resultData = dataSource.ToList();
                // Grouping
                foreach (var group in dataManagerRequest.Group)
                {
                    resultData = DataUtil.Group<ProductModel>(resultData, group, dataManagerRequest.Aggregates, 0, dataManagerRequest.GroupByFormatter);
                }
                dataObject.Result = resultData;
                dataObject.Count = count;

                //If both Grouping and Aggregate is enabled
                if (dataManagerRequest.Aggregates != null)
                {
                    dataObject.Aggregates = aggregates;
                }

                //Here RequiresCount is passed from the control side itself, where ever the on-demand data fetching is needed then the RequiresCount is set as true in component side itself.
                // In the above case we are using paging so datas are loaded in on-demand bases whenever the next page is clicked in Blazor DataGrid side.
                return dataManagerRequest.RequiresCounts ? dataObject : (object)resultData;
            }

            //Here RequiresCount is passed from the control side itself, where ever the on-demand data fetching is needed then the RequiresCount is set as true in component side itself.
            // In the above case we are using paging so datas are loaded in on-demand bases whenever the next page is clicked in Blazor DataGrid side.
            return dataManagerRequest.RequiresCounts ? new DataResult() { Result = dataSource, Count = count, Aggregates = aggregates } : (object)dataSource;
        }
        else
        {
            Console.WriteLine($"API Error (read): {response.StatusCode} - {response.Error?.Message} - {response.Error?.Content}");
            throw new Exception(response.Error?.Message, response.Error);
        }
    }

    public override async Task<object?> InsertAsync(DataManager dataManager, object data, string key)
    {
        ProductModel? product = data as ProductModel;
        CreateProductResponse createProductResponse;

        var response = await _catalogService.CreateProduct(product!);

        if (response.IsSuccessStatusCode)
        {
            createProductResponse = response.Content!;
            return createProductResponse;
        }
        else
        {
            Console.WriteLine($"API Error (insert): {response.StatusCode} - {response.Error?.Message} - {response.Error?.Content}");
            throw new DialogException(response.Error?.Content, response.Error, true);
        }
    }

    public override async Task<object> UpdateAsync(DataManager dataManager, object data, string keyField, string key)
    {
        return await _catalogService.UpdateProduct((ProductModel)data);
    }

    public override async Task<object> RemoveAsync(DataManager dataManager, object data, string keyField, string key)
    {
        var id = (Guid)data;
        await _catalogService.DeleteProduct(id);
        return id;
    }
}
