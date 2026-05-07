using CRMWeb.Extensions;
using CRMWeb.Models.Counterparties;
using Syncfusion.Blazor;

namespace CRMWeb.Services.Counterparties;

public class CounterpartyFullAdaptor : DataAdaptor
{
    private readonly ICounterpartyService _counterpartyService;

    public CounterpartyFullAdaptor()
    {
        _counterpartyService = SelectiveServices.CounterpartyService!;
    }

    public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
    {
        var idParam = dataManagerRequest.Params?.FirstOrDefault(p => p.Key == "CounterpartyId").Value?.ToString();
        _ = Guid.TryParse(idParam, out Guid counterpartyId);

        var response = await _counterpartyService.GetCounterparty(counterpartyId);

        if (response.IsSuccessStatusCode)
        {
            CounterpartyFullModel counterparty = response.Content!.Counterparty;
            return new List<CounterpartyFullModel> { counterparty };
        }
        else
        {
            Console.WriteLine($"API Error (read): {response.StatusCode} - {response.Error?.Message} - {response.Error?.Content}");
            throw new Exception(response.Error?.Message, response.Error);
        }
    }
}