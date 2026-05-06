namespace WebServer.API.Extensions;

public static class CounterpartyLiteExtensions
{
    public static IEnumerable<CounterpartyLiteDto> ToCounterpartiesLite1DtoList(this IEnumerable<Counterparty> counterparties)
        => counterparties.Select(counterparty => DtoFromCounterpartyLite(counterparty));

    public static CounterpartyLiteDto ToCounterpartyLiteDto(this Counterparty counterparty)
        => DtoFromCounterpartyLite(counterparty);

    private static CounterpartyLiteDto DtoFromCounterpartyLite(Counterparty counterparty) => new()
    {
        Id = counterparty.Id,
        Name = counterparty.Name
    };
}

public static class CounterpartyExtensions
{
    public static IEnumerable<CounterpartyDto> ToCounterpartiesDtoList(this IEnumerable<Counterparty> counterparties)
        => counterparties.Select(counterparty => DtoFromCounterparty(counterparty));

    public static CounterpartyDto ToCounterpartyDto(this Counterparty counterparty)
        => DtoFromCounterparty(counterparty);

    private static CounterpartyDto DtoFromCounterparty(Counterparty counterparty) => new()
    {
        Id = counterparty.Id,
        Name = counterparty.Name,
        Supplier = counterparty.Supplier,
        Seller = counterparty.Seller
    };
}

public static class CounterpartyFullExtensions
{
    public static IEnumerable<CounterpartyFullDto> ToCounterpartieFullDtoList(this IEnumerable<Counterparty> counterparties)
        => counterparties.Select(counterparty => DtoFromCounterpartyFull(counterparty));

    public static CounterpartyFullDto ToCounterpartyFullDto(this Counterparty counterparty)
        => DtoFromCounterpartyFull(counterparty);

    private static CounterpartyFullDto DtoFromCounterpartyFull(Counterparty counterparty)
        => new()
        {
            Id = counterparty.Id,
            Name = counterparty.Name,
            FullName = counterparty.FullName,
            Supplier = counterparty.Supplier,
            Seller = counterparty.Seller,
            FormOfOwnership = counterparty.FormOfOwnership,
            Edrpou = counterparty.Edrpou,
            Tin = counterparty.Tin,
            Description = counterparty.Description,
            Phones = counterparty.Phones?.Select(phone => phone.ToPhoneLiteDto()).ToList()
        };
}
